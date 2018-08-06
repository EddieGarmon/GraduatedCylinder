using System;

namespace GraduatedCylinder.Nmea
{
    public class SentenceRecord
    {
        public SentenceRecord(double secondsFromStart, Sentence sentence)
            : this(new Time(secondsFromStart, TimeUnit.Second), sentence) { }

        public SentenceRecord(TimeSpan secondsFromStart, Sentence sentence)
            : this(new Time(secondsFromStart.TotalSeconds, TimeUnit.Second), sentence) { }

        public SentenceRecord(Time secondsFromStart, Sentence sentence) {
            Occurance = secondsFromStart;
            Sentence = sentence;
        }

        public Time Occurance { get; }

        public Sentence Sentence { get; }

        public override string ToString() {
            return string.Format("{0:F8}\t{1}", Occurance.In(TimeUnit.Second), Sentence);
        }

        public static SentenceRecord Parse(string input) {
            string[] parts = input.Split('\t');
            Time occurance = double.Parse(parts[0]).Seconds();
            Sentence sentence = Sentence.Parse(parts[1]);
            return new SentenceRecord(occurance, sentence);
        }
    }
}