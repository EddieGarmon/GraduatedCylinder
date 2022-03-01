namespace Nmea.Core0183;

public interface IProvideSentences
{

    bool IsOpen { get; }

    event Action<Sentence> SentenceReceived;

    void Close();

    void Open();

}