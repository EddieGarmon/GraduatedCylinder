namespace Nmea.Core0183;

public class SentenceRecord
{

    public SentenceRecord(double secondsFromStart, Sentence sentence)
        : this(TimeSpan.FromSeconds(secondsFromStart), sentence) { }

    public SentenceRecord(TimeSpan secondsFromStart, Sentence sentence) {
        SecondsFromStart = secondsFromStart;
        Sentence = sentence;
    }

    public TimeSpan SecondsFromStart { get; }

    public Sentence Sentence { get; }

    public override string ToString() {
        return $"{SecondsFromStart.TotalSeconds:F8}\t{Sentence}";
    }

    private static readonly char[] _separator = { '\t' };

    public static SentenceRecord Parse(string input) {
        string[] parts = input.Split(_separator, 2);
        TimeSpan fromStart = TimeSpan.FromSeconds(double.Parse(parts[0]));
        Sentence? sentence = Sentence.Parse(parts[1]);
        if (sentence is null) {
            throw new Exception($"Invalid sentence: {input}");
        }
        return new SentenceRecord(fromStart, sentence);
    }

}