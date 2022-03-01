using System.Diagnostics;
using GraduatedCylinder.Geo.Laser.Nmea;
using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser;

public class LaserUnit : IDisposable
{

    private readonly IProvideSentences _nmeaProvider;
    private readonly OutputParser _outputParser = new OutputParser();

    public LaserUnit(IProvideSentences nmeaProvider) {
        _nmeaProvider = nmeaProvider;
        _nmeaProvider.SentenceReceived += sentence => {
                                              Message? message = _outputParser.Parse(sentence);
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