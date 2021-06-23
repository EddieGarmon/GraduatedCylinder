using System;
using System.IO;

namespace Nmea.Core0183
{
    public class SentenceLogger : IProvideSentences
    {

        private readonly string _filename;
        private readonly IProvideSentences _source;
        private DateTime _logStart;

        public SentenceLogger(IProvideSentences source, string logFileName) {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _filename = logFileName ?? throw new ArgumentNullException(nameof(logFileName));
            _source.SentenceReceived += sentence => {
                                            SentenceReceived?.Invoke(sentence);
                                            TimeSpan timeSpan = DateTime.Now - _logStart;
                                            using (StreamWriter writer = File.AppendText(_filename)) {
                                                writer.Write(new SentenceRecord(timeSpan, sentence));
                                            }
                                        };
        }

        public bool IsOpen => _source.IsOpen;

        public event Action<Sentence> SentenceReceived;

        public void Close() {
            _source.Close();
        }

        public void Open() {
            _logStart = DateTime.Now;
            Directory.CreateDirectory(Path.GetDirectoryName(_filename));
            _source.Open();
        }

    }
}