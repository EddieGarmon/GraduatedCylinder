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

}