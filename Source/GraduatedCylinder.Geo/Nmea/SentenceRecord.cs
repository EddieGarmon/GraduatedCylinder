namespace GraduatedCylinder.Nmea
{
    public class SentenceRecord
    {
        public SentenceRecord(double secondsFromStart, Sentence sentence)
            : this(new Time(secondsFromStart, TimeUnit.Second), sentence) { }

        public SentenceRecord(Time occurance, Sentence sentence) {
            Occurance = occurance;
            Sentence = sentence;
        }

        public Time Occurance { get; }

        public Sentence Sentence { get; }
    }
}