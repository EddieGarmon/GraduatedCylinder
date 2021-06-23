using System;

namespace GraduatedCylinder.Devices.Laser.Nmea
{
    internal class CommandSentence
    {

        internal CommandSentence(string text) {
            CommandText = text;
        }

        public string CommandText { get; set; }

        public string GetCommand() {
            return string.Format("${0}\r\n", CommandText);
        }

    }

    internal class CommandSentence<T> : CommandSentence
    {

        internal CommandSentence(string text)
            : base(text) { }

        public T Decode(string line) {
            throw new NotImplementedException();
        }

        public string GetSetCommand(T newValue) {
            return string.Format("${0},{1}\r\n", CommandText, Convert.ToInt32(newValue));
        }

    }
}