using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Laser.Nmea;

internal class OutputParser : NmeaParser
{

    public OutputParser()
        : base(VectorSentence.ParseDirect, VectorSentence.ParseMissing, HeightSentence.Parse, DeviceInfoSentence.Parse) { }

}