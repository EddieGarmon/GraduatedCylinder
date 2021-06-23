using System;
using System.Diagnostics;
using GraduatedCylinder.Devices.Laser.Nmea;
using Nmea.Core0183;

namespace GraduatedCylinder.Devices.Laser
{
    public class TruPulse360 : IDisposable
    {

        private readonly IProvideSentences _nmeaProvider;
        private readonly LaserParser _parser = new LaserParser();

        public TruPulse360(IProvideSentences nmeaProvider) {
            _nmeaProvider = nmeaProvider;
            _nmeaProvider.SentenceReceived += sentence => {
                                                  Message message = _parser.Parse(sentence);
                                                  if (message == null) {
                                                      return;
                                                  }

                                                  Debug.WriteLine(message.Sentence);
                                              };
            _nmeaProvider.Open();
        }

        void IDisposable.Dispose() {
            _nmeaProvider.Close();
        }

    }
}