using System;

namespace Nmea.Core0183;

public class Message
{

    public Message(Sentence sentence, object value) {
        Sentence = sentence;
        Value = value;
        Created = DateTimeOffset.Now;
    }

    public DateTimeOffset Created { get; }

    public Sentence Sentence { get; }

    public object Value { get; }

    public T ValueAs<T>()
        where T : class {
        if (Value is T variable) {
            return variable;
        }
        return null;
    }

}