using System;

namespace GraduatedCylinder.Nmea
{
    public class Message
    {
        public Message(Sentence sentence, object value) {
            Sentence = sentence;
            Value = value;
            Created = NmeaClock.GetTime();
        }

        public DateTime Created { get; private set; }

        public Sentence Sentence { get; private set; }

        public object Value { get; private set; }

        public T ValueAs<T>() where T : class {
            if (Value is T) {
                return (T)Value;
            }
            return null;
        }
    }
}