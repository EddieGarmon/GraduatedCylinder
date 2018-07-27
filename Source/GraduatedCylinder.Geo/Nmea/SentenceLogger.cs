using System;
using System.IO;

namespace GraduatedCylinder.Nmea
{
    public class SentenceLogger : IProvideSentences
    {
        private readonly string _filename;
        private readonly IProvideSentences _source;
        private TextWriter _writer;

        public SentenceLogger(IProvideSentences source, string logFileName) {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _filename = logFileName;
            _source.SentenceReceived += sentence => {
                                            var handler = SentenceReceived;
                                            handler?.Invoke(sentence);
                                            _writer.WriteLine("{0}\t{1}", 0, sentence);
                                        };
        }

        public bool IsOpen => _source.IsOpen;

        public event Action<Sentence> SentenceReceived;

        public void Close() {
            _writer.Close();
            _source.Close();
        }

        public void Open() {
            //todo: capture log start time for relative timestamps
            _writer = new StreamWriter(File.OpenWrite(_filename));
            _source.Open();
        }
    }
}