using Nmea.Core0183;

namespace GraduatedCylinder.Geo.Gps.Nmea;

public class GLL_Sentence
{

    private static IList<string> ValidIds { get; } = new List<string> { "$GPGLL", "$GNGLL" };

    public static Decoded? Parse(Sentence sentence) {
        // $__GLL,<1>,<2>,<3>,<4>,<5>,<6>,<7>*<CS><CR><LF>
        // 0) Sentence Id
        // 1) Latitude, ddmm.mmmm format.
        // 2) Latitude hemisphere, N or S.
        // 3) Longitude, dddmT1.mmmm format.
        // 4) Longitude hemisphere, E or W.
        // 5) UTC time of position fix, hhmmss format.
        // 6) Status, A = data active or V = data void.
        // *<CS>) Checksum.
        // <CR><LF>) Sentence terminator

        if (!ValidIds.Contains(sentence.Id)) {
            return null;
        }
        if (sentence.WordCount != 6) {
            return null;
        }
        if (sentence[6] != "A") {
            return null;
        }

        Latitude latitude = SentenceHelper.ParseLatitude(sentence[1], sentence[2]);
        Longitude longitude = SentenceHelper.ParseLongitude(sentence[3], sentence[4]);
        DateTimeOffset fixTime = NmeaClock.GetDateTime(SentenceHelper.ParseUtcTime(sentence[5]));

        return new Decoded(fixTime, new GeoPosition(latitude, longitude));
    }

    public class Decoded : IProvideGeoPosition, IProvideTime
    {

        public Decoded(DateTimeOffset currentTime, GeoPosition currentLocation) {
            CurrentLocation = currentLocation;
            CurrentTime = currentTime;
        }

        public GeoPosition CurrentLocation { get; private set; }

        public DateTimeOffset CurrentTime { get; private set; }

    }

}