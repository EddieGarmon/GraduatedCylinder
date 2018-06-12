using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GpsParser : NmeaParser
    {
        public GpsParser()
            : base(
                GPGSA_Sentence.Parse,
                GPGSV_Sentence.Parse,
                GPVTG_Sentence.Parse,
                GPGGA_Sentence.Parse,
                GPRMC_Sentence.Parse,
                GPGLL_Sentence.Parse) { }
    }
}