using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GpsParser : NmeaParser
    {
        //todo: add a --ZDA sentence parser
        public GpsParser()
            : base(GSA_Sentence.Parse,
                   GSV_Sentence.Parse,
                   VTG_Sentence.Parse,
                   GGA_Sentence.Parse,
                   RMC_Sentence.Parse,
                   GLL_Sentence.Parse) { }
    }
}