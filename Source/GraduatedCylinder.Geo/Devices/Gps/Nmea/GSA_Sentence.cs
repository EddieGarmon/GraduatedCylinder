using System.Collections.Generic;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class GSA_Sentence
    {
        private static readonly List<string> ValidIds = new List<string> {
            "$GPGSA",
            "$GNGSA",
            "$GLGSA",
            "$BDGSA"
        };

        public static Decoded Parse(Sentence sentence) {
            // $__GSA,<1>,<2>,<3>,<4>, ... ,<13>,<14>,<15>,<16>,<17>*<CS><CR><LF>
            // 0)  Sentence Id
            // 1)  Mode 1, M = manual, A = automatic.
            // 2)  Mode 2, Fix type, 1 = no fix, 2 = 2D, 3 = 3D.
            // 3)  PRN number, 01 to 32, of satellite used on channel 1
            // 4)  PRN number, 01 to 32, of satellite used on channel 2
            // 5)  PRN number, 01 to 32, of satellite used on channel 3
            // 6)  PRN number, 01 to 32, of satellite used on channel 4
            // 7)  PRN number, 01 to 32, of satellite used on channel 5
            // 8)  PRN number, 01 to 32, of satellite used on channel 6
            // 9)  PRN number, 01 to 32, of satellite used on channel 7
            // 10) PRN number, 01 to 32, of satellite used on channel 8
            // 11) PRN number, 01 to 32, of satellite used on channel 9
            // 12) PRN number, 01 to 32, of satellite used on channel 10
            // 13) PRN number, 01 to 32, of satellite used on channel 11
            // 14) PRN number, 01 to 32, of satellite used on channel 12
            // 15) PDOP-Position dilution of precision, 0.5 to 99.9.
            // 16) HDOP-Horizontal dilution of precision, 0.5 to 99.9.
            // 17) VDOP-Vertical di1ution of precision, 0.5 to 99.9.
            // *<CS>) Checksum.
            // <CR><LF>) Sentence terminator

            if (!ValidIds.Contains(sentence.Id)) {
                return null;
            }
            if (sentence.Parts.Length != 18) {
                return null;
            }

            GpsFixType fixType;
            switch (sentence.Parts[2]) {
                case "3":
                    fixType = GpsFixType.ThreeD;
                    break;
                case "2":
                    fixType = GpsFixType.TwoD;
                    break;
                default:
                    fixType = GpsFixType.None;
                    break;
            }

            int[] satellites = new int[12];
            for (int i = 0; i < 12; i++) {
                int satId;
                if (int.TryParse(sentence.Parts[i + 3], out satId)) {
                    satellites[i] = satId;
                }
            }

            double positionDop, horizontalDop, verticalDop;
            double.TryParse(sentence.Parts[15], out positionDop);
            double.TryParse(sentence.Parts[16], out horizontalDop);
            double.TryParse(sentence.Parts[17], out verticalDop);

            return new Decoded(fixType, satellites, positionDop, horizontalDop, verticalDop);
        }

        public class Decoded : IProvideFixType,
                               IProvideActiveSatellites,
                               IProvideDilutionOfPrecision
        {
            public Decoded(GpsFixType currentFix,
                           int[] activeSatellitePrns,
                           double positionDop,
                           double horizontalDop,
                           double verticalDop) {
                CurrentFix = currentFix;
                ActiveSatellitePrns = activeSatellitePrns;
                PositionDop = positionDop;
                HorizontalDop = horizontalDop;
                VerticalDop = verticalDop;
            }

            public int[] ActiveSatellitePrns { get; private set; }

            public GpsFixType CurrentFix { get; private set; }

            public double HorizontalDop { get; private set; }

            public double PositionDop { get; private set; }

            public double VerticalDop { get; private set; }
        }
    }
}