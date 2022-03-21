using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Gps.Nmea;

public class GGA_Sentence
{

    private static IList<string> ValidIds { get; } = new List<string> { "$GPGGA", "$GNGGA" };

    public static Decoded? Parse(Sentence sentence) {
        // $__GGA,<1>,<2>,<3>,<4>,<5>,<6>,<7>,<8>,<9>,M,<11>,M,<13>,<14>*<CS><CR><LF>
        // 0)  Sentence Id
        // 1)  UTC time of position fix, hhmmss.sss format
        // 2)  Latitude, ddmm.mmmm format.
        // 3)  Latitude hemisphere, N or S.
        // 4)  Longitude, dddmm.mmmm format.
        // 5)  Longitude hemisphere, E or W.
        // 6)  Position Fix Indicator,
        //		0 = Invalid fix.
        //      1 = GPS fix (SPS)
        //      2 = DGPS fix
        //      3 = PPS fix
        //      4 = Real Time Kinematic
        //      5 = Float RTK
        //      6 = estimated (dead reckoning) (2.3 feature)
        //      7 = Manual input mode
        //      8 = Simulation mode
        // 7)  Number of sate1lites in use, 00 to 12.
        // 8)  Horizontal Dilution of Precision, 0.5 to 99.9.
        // 9)  MSL Altitude, -9999.9 to 99999.9 meters.
        // 10) Altitude units - M for meters
        // 11) Geoid separation in meters according to WGS-84 ellipsoid, -999.9 to 9999.9 meters.
        // 12) Separation units - M for meters
        // 13) Differential GPS (RTCM SC-104) data age, number of seconds since last valid RTCM transmission (nu1l if non-DGPS).
        // 14) Differential Reference Station ID, 0000 to 1023. (null if non-DGPS)
        // *<CS>) Checksum.
        // <CR><LF>) Sentence terminator

        if (!ValidIds.Contains(sentence.Id)) {
            return null;
        }
        if (sentence.WordCount != 15) {
            return null;
        }

        int.TryParse(sentence[6], out int fixIndicator);
        if (fixIndicator == 0) {
            return null;
        }

        DateTimeOffset fixTime = NmeaClock.GetDateTime(SentenceHelper.ParseUtcTime(sentence[1]));
        Latitude latitude = SentenceHelper.ParseLatitude(sentence[2], sentence[3]);
        Longitude longitude = SentenceHelper.ParseLongitude(sentence[4], sentence[5]);

        int.TryParse(sentence[7], out int numberOfSatellites);
        double.TryParse(sentence[8], out double horizontalDop);

        Length altitude = SentenceHelper.ParseLength(sentence[9], sentence[10]);
        Length heightOfGeoid = SentenceHelper.ParseLength(sentence[11], sentence[12]);

        int.TryParse(sentence[13], out int dgpsAge);

        string dgpsStationId = sentence[14];

        return new Decoded(fixTime, new GeoPosition(latitude, longitude, altitude));
    }

    public class Decoded : IProvideGeoPosition, IProvideTime
    {

        public Decoded(DateTimeOffset currentTime, GeoPosition currentLocation) {
            CurrentLocation = currentLocation;
            CurrentTime = currentTime;
        }

        public GeoPosition CurrentLocation { get; }

        public DateTimeOffset CurrentTime { get; }

    }

}