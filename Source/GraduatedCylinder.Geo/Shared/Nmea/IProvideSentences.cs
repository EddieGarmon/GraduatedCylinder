using System;

namespace GraduatedCylinder.Nmea
{
    public interface IProvideSentences
    {
        bool IsOpen { get; }

        event Action<Sentence> SentenceReceived;

        void Close();

        void Open();
    }
}