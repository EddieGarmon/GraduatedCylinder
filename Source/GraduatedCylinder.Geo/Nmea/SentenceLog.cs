using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace GraduatedCylinder.Nmea
{
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
        private Thread _thread;

        public SentenceLog(string filename, PlaybackRate rate = PlaybackRate.AsRecorded, bool loopEnd = false) {
            if (!File.Exists(filename)) {
                string message = string.Format("The NMEA log file '{0}' cannot be found.", filename);
                throw new ArgumentException(message);
            }
            _filename = filename;
            _rate = rate;
            _loopEnd = loopEnd;
        }

        public bool IsOpen => _thread != null;

        public bool PlaybackComplete { get; private set; }

        public event Action<Sentence> SentenceReceived;

        public void Close() {
            if (_thread != null) {
                _thread.Abort();
                _thread = null;
            }
        }

        public void Open() {
            if (_thread != null) {
                throw new InvalidOperationException("Log file is already open for reading.");
            }
            _thread = new Thread(ReadAndBroadcast);
            _thread.Start();
        }

        private void RaiseSentenceRecieved(Sentence sentence) {
            var handler = SentenceReceived;
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
                var record = records[index];

                switch (_rate) {
                    case PlaybackRate.AsRecorded:
                        Time currentTime = DateTime.Now - startTime;
                        Task.Delay(record.Occurance - currentTime)
                            .ContinueWith(_ => RaiseSentenceRecieved(record.Sentence));
                        break;

                    case PlaybackRate.AsFastAsPossible:
                        RaiseSentenceRecieved(record.Sentence);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                index++;
                if (index == records.Count && _loopEnd) {
                    index = 0;
                }
            }

            PlaybackComplete = true;
        }
    }
}