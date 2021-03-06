﻿using System.Collections.Generic;
using GraduatedCylinder.Geo;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    public class VTG_Sentence
    {
        private static readonly List<string> ValidIds = new List<string> {
            "$GPVTG",
            "$GNVTG"
        };

        public static Decoded Parse(Sentence sentence) {
            // $__VTG,<1>,T,<3>,M,<5>,N,<7>,K*<CS><CR><LF>
            // 0) Sentence Id
            // 1) True course over ground, 000 to 359 degrees.
            // 2) T for true course
            // 3) Magnetic course over ground, 000 to 359 degrees.
            // 4) M for magnetic course
            // 5) horizontal speed over ground, 00.0 to 999.9 knots.
            // 6) N for knots
            // 7) Speed over ground, 00.0 to 1851.8 ko/hr.
            // 8) K for km/p
            // *<CS>) Checksum.
            // <CR><LF>) Sentence terminator

            if (!ValidIds.Contains(sentence.Id)) {
                return null;
            }
            if (sentence.Parts.Length != 9) {
                return null;
            }

            double trueCourse;
            if (!double.TryParse(sentence.Parts[1], out trueCourse)) {
                trueCourse = double.NaN;
            }

            double magneticCourse;
            double.TryParse(sentence.Parts[3], out magneticCourse);

            double speedInKnots;
            double.TryParse(sentence.Parts[5], out speedInKnots);

            return new Decoded(trueCourse, magneticCourse, new Speed(speedInKnots, SpeedUnit.NauticalMilesPerHour));
        }

        public class Decoded : IProvideTrajectory
        {
            public Decoded(Heading currentHeading, Heading magneticCourse, Speed currentSpeed) {
                CurrentHeading = currentHeading;
                MagneticCourse = magneticCourse;
                CurrentSpeed = currentSpeed;
            }

            public Heading CurrentHeading { get; private set; }

            public Speed CurrentSpeed { get; private set; }

            public Heading MagneticCourse { get; private set; }
        }
    }
}