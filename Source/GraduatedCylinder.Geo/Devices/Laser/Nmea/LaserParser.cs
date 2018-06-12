using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Laser.Nmea
{
    internal class LaserParser : NmeaParser
    {
        public LaserParser()
            : base(VectorSentence.ParseDirect, VectorSentence.ParseMissing, HeightSentence.Parse, DeviceInfoSentence.Parse) { }
    }
}