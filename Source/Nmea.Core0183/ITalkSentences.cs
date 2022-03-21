namespace Nmea.Core0183;

public interface ITalkSentences : IProvideSentences
{

    void Send(Sentence sentence);

}