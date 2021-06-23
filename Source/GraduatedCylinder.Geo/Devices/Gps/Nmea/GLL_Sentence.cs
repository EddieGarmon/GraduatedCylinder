using System;
using System.Collections.Generic;
using GraduatedCylinder.Geo;
using Nmea.Core0183;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GLL_Sentence
    {

        private static readonly List<string> ValidIds = new List<string> { "$GPGLL", "$GNGLL" };

        public static Decoded Parse(Sentence sentence) {
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
            if (sentence.Parts.Length != 6) {
                return null;
            }
            if (sentence.Parts[6] != "A") {
                return null;
            }

            Latitude latitude = SentenceHelper.ParseLatitude(sentence.Parts[1], sentence.Parts[2]);
            Longitude longitude = SentenceHelper.ParseLongitude(sentence.Parts[3], sentence.Parts[4]);
            DateTimeOffset fixTime = NmeaClock.GetDateTime(SentenceHelper.ParseUtcTime(sentence.Parts[5]));

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
}