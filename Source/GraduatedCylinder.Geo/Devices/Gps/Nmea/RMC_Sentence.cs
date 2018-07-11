using System;
using System.Collections.Generic;
using GraduatedCylinder.Geo;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class RMC_Sentence

    {
        private static readonly List<string> ValidIds = new List<string> {
            "$GPRMC",
            "$GNRMC"
        };

        public static Decoded Parse(Sentence sentence) {
            // $__RMC,<1>,<2>,<3>,<4>,<5>,<6>,<7>,<8>,<9>,<10>,<11>*<CS><CR><LF>
            // 0)  Sentence Id
            // 1)  UTC time of position fix, hhmmss.sss format.
            // 2)  Status, A = data valid, V = data not valid.
            // 3)  Latitude, ddmm.mmmm format.
            // 4)  Latitude hemisphere, N or S.
            // 5)  Longitude, dddmmm.mmmm format.
            // 6)  Longitude hemisphere, E or W.
            // 7)  Speed over ground, 0.0 to 1851.8 knots.
            // 8)  Course over ground, 000.0 to 359.9 degrees, true.
            // 9)  UTC Date, ddmmyy format.
            // 10) Magnetic variation, 000.0 to 180.O degrees
            // 11) Magnetic variation, E = East, W = West
            // 12) (Optional) Fix mode indicator , A=autonomous, D=differential, E=Estimated, N=not valid, S=Simulator
            // *<CS>) Checksum.
            // <CR><LF>) Sentence terminator

            if (!ValidIds.Contains(sentence.Id)) {
                return null;
            }
            if (sentence.Parts.Length != 12 && sentence.Parts.Length != 13) {
                return null;
            }
            if (sentence.Parts[2] != "A") {
                return null;
            }

            DateTime fixDate = SentenceHelper.ParseUtcDate(sentence.Parts[9]);
            NmeaClock.GetDate = () => fixDate;
            DateTimeOffset fixTime = NmeaClock.GetDateTime(SentenceHelper.ParseUtcTime(sentence.Parts[1]));
            Latitude latitude = SentenceHelper.ParseLatitude(sentence.Parts[3], sentence.Parts[4]);
            Longitude longitude = SentenceHelper.ParseLongitude(sentence.Parts[5], sentence.Parts[6]);

            double.TryParse(sentence.Parts[7], out double speed);
            if (!double.TryParse(sentence.Parts[8], out double heading)) {
                heading = double.NaN;
            }

            //todo: magnetic variation

            if (sentence.Parts.Length == 13) {
                if (sentence.Parts[12] != "A" && sentence.Parts[12] != "D") {
                    return null;
                }
            }

            return new Decoded(fixTime,
                               new GeoPosition(latitude, longitude),
                               heading,
                               new Speed(speed, SpeedUnit.NauticalMilesPerHour));
        }

        public class Decoded : IProvideGeoPosition,
                               IProvideTime,
                               IProvideTrajectory
        {
            public Decoded(DateTimeOffset currentTime,
                           GeoPosition currentLocation,
                           Heading currentHeading,
                           Speed currentSpeed) {
                CurrentLocation = currentLocation;
                CurrentTime = currentTime;
                CurrentHeading = currentHeading;
                CurrentSpeed = currentSpeed;
            }

            public Heading CurrentHeading { get; private set; }

            public GeoPosition CurrentLocation { get; private set; }

            public Speed CurrentSpeed { get; private set; }

            public DateTimeOffset CurrentTime { get; private set; }
        }
    }
}