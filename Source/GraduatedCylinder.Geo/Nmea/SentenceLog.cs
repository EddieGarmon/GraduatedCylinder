using System;
using System.IO;
using System.Threading;

namespace GraduatedCylinder.Nmea
{
    public class SentenceLog : IProvideSentences
    {
        public enum PlaybackRate
        {
            AsRecorded,
            _60Hertz,
            _100Hertz,
            AsFastAsPossible
        }

        public enum PlaybackTime
        {
            Historic,
            Current
        }

        private readonly string _filename;
        private SentenceRecord _currentRecord;
        private bool _loopEnd;
        private SentenceRecord _nextRecord;
        private PlaybackRate _rate;
        private StreamReader _reader;
        private Thread _thread;
        private PlaybackTime _time;

        public SentenceLog(string filename,
                           PlaybackTime time,
                           PlaybackRate rate = PlaybackRate.AsRecorded,
                           bool loopEnd = false) {
            if (!File.Exists(filename)) {
                string message = string.Format("The file NMEA log '{0}' cannot be found.", filename);
                throw new ArgumentException(message);
            }
            _filename = filename;
            _time = time;
            _rate = rate;
            _loopEnd = loopEnd;
        }

        public bool IsOpen => _thread != null;

        public event Action<Sentence> SentenceReceived;

        public void Close() {
            if (_reader != null) {
                _reader.Close();
                _reader = null;
            }
            if (_thread != null) {
                _thread.Abort();
                _thread = null;
            }
        }

        public void Open() {
            if (_reader != null) {
                throw new InvalidOperationException("Log file is already open for reading.");
            }
            _reader = File.OpenText(_filename);
            _thread = new Thread(ReadAndBroadcast);
            _thread.Start();
        }

        private void ReadAndBroadcast() {
            //capture start playback time

            throw new NotImplementedException();
        }
    }
}