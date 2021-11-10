using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Nmea.Core0183;

public class SentenceLog : IProvideSentences
{

    public enum PlaybackRate
    {

        AsRecorded,
        AsFastAsPossible

    }

    private readonly string _filename;
    private readonly bool _loopEnd;
    private readonly PlaybackRate _rate;
    private CancellationTokenSource _cancel;
    private Task _playback;

    public SentenceLog(string filename, PlaybackRate rate = PlaybackRate.AsRecorded, bool loopEnd = false) {
        if (!File.Exists(filename)) {
            string message = string.Format("The NMEA log file '{0}' cannot be found.", filename);
            throw new ArgumentException(message);
        }
        _filename = filename;
        _rate = rate;
        _loopEnd = loopEnd;
    }

    public bool IsOpen => _playback != null;

    public bool PlaybackComplete { get; private set; }

    public event Action<Sentence> SentenceReceived;

    public void Close() {
        if (_playback != null) {
            _cancel.Cancel();
            _playback.Wait();
            _playback.Dispose();
            _playback = null;
        }
    }

    public void Open() {
        if (_playback != null) {
            throw new InvalidOperationException("Log file is already open for reading.");
        }
        PlaybackComplete = false;
        _cancel = new CancellationTokenSource();
        _playback = Task.Run(() => ReadAndBroadcast(), _cancel.Token);
    }

    private void RaiseSentenceReceived(Sentence sentence) {
        Action<Sentence> handler = SentenceReceived;
        handler?.Invoke(sentence);
    }

    private void ReadAndBroadcast() {
        //open file and parse/cache the log
        List<SentenceRecord> records = new List<SentenceRecord>();
        using (StreamReader reader = File.OpenText(_filename)) {
            while (!reader.EndOfStream) {
                string line = reader.ReadLine();
                records.Add(SentenceRecord.Parse(line));
            }
        }

        //capture start playback time
        DateTime startTime = DateTime.Now;

        int index = 0;
        while (index < records.Count) {
            if (_cancel.IsCancellationRequested) {
                break;
            }

            var record = records[index];

            switch (_rate) {
                case PlaybackRate.AsRecorded:
                    TimeSpan elapsedTime = DateTime.Now - startTime;
                    TimeSpan waitTime = record.SecondsFromStart - elapsedTime;
                    if (waitTime > TimeSpan.Zero) {
                        Thread.Sleep(waitTime);
                    }
                    RaiseSentenceReceived(record.Sentence);
                    break;

                case PlaybackRate.AsFastAsPossible:
                    RaiseSentenceReceived(record.Sentence);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            index++;
            if (index == records.Count && _loopEnd) {
                index = 0;
                startTime = DateTime.Now;
            }
        }

        PlaybackComplete = true;
    }

}