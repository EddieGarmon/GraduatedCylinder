using System;
using GraduatedCylinder.Geo;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GPGLL_Sentence
    {
        public static Decoded Parse(Sentence sentence) {
            // $GPGLL,<1>,<2>,<3>,<4>,<5>,<6>,<7>*<CS><CR><LF>
            // 0) Sentence Id
            // 1) Latitude, ddmm.mmmm format.
            // 2) Latitude hemisphere, N or S.
            // 3) Longitude, dddmT1.mmmm format.
            // 4) Longitude hemisphere, E or W.
            // 5) UTC time of position fix, hhmmss format.
            // 6) Status, A = data active or V = data void.
            // *<CS>) Checksum.
            // <CR><LF>) Sentence terminator

            if (sentence.Id != "$GPGLL") {
                return null;
            }
            if (sentence.Parts.Length != 6) {
                return null;
            }
            if (sentence.Parts[6] != "A") {
                return null;
            }

            var latitude = SentenceHelper.ParseLatitude(sentence.Parts[1], sentence.Parts[2]);
            var longitude = SentenceHelper.ParseLongitude(sentence.Parts[3], sentence.Parts[4]);
            var fixTime = NmeaClock.GetTime()
                                   .Date;
            fixTime += SentenceHelper.ParseUtcTime(sentence.Parts[5]);

            return new Decoded(new GeoPosition(latitude, longitude), fixTime);
        }

        public class Decoded : IProvideGeoPosition,
                               IProvideTime
        {
            public Decoded(GeoPosition currentLocation, DateTime currentTime) {
                CurrentLocation = currentLocation;
                CurrentTime = currentTime;
            }

            public GeoPosition CurrentLocation { get; private set; }

            public DateTime CurrentTime { get; private set; }
        }
    }
}