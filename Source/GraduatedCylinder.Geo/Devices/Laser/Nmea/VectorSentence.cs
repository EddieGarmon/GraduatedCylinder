using System;
using GraduatedCylinder.Geo;
using GraduatedCylinder.Nmea;

namespace GraduatedCylinder.Devices.Laser.Nmea
{
    public static class VectorSentence
    {
        // "$PLTIT,HV,{hValue},{hUnits: F,Y,M},{azValue},{azUnits: D},{incValue},{incUnits: D},{sdValue},{sdUnits: F,Y,M}*{check}"
        //  0      1  2        3               4         5            6          7             8         9
        public static GeoVector ParseDirect(Sentence sentence) {
            if (sentence.Parts[0] != "$PLTIT") {
                return null;
            }
            if (sentence.Parts[1] != "HV") {
                return null;
            }
            GeoVector direct = ParseVector(sentence);
            return direct;
        }

        // there will be 2 HV sentences then the ML sentence
        // "$PLTIT,ML,{hValue},{hUnits: F,Y,M},{azValue},{azUnits: D},{incValue},{incUnits: D},{sdValue},{sdUnits: F,Y,M}*{check}"
        //  0      1  2        3               
        public static MissingLine ParseMissing(Sentence sentence) {
            if (sentence.Parts[0] != "$PLTIT") {
                return null;
            }
            if (sentence.Parts[1] != "ML") {
                return null;
            }
            GeoVector missing = ParseVector(sentence);
            return new MissingLine(null, null, missing);
        }

        private static AngleUnit GetAngleUnit(string value) {
            switch (value) {
                case "D":
                    return AngleUnit.Degree;
                default:
                    throw new Exception("unknown angle unit: " + value);
            }
        }

        private static LengthUnit GetLengthUnit(string value) {
            switch (value) {
                case "F":
                    return LengthUnit.Foot;
                case "Y":
                    return LengthUnit.Yard;
                case "M":
                    return LengthUnit.Meter;
                default:
                    throw new Exception("unknown length unit: " + value);
            }
        }

        private static GeoVector ParseVector(Sentence sentence) {
            bool highQuality = true;

            //horizontal distance
            Length horizontal = null;
            string measurement = sentence.Parts[2];
            if (!string.IsNullOrEmpty(measurement)) {
                highQuality = measurement.EndsWith("0");
                measurement = measurement.Substring(0, measurement.Length - 1);
                LengthUnit units = GetLengthUnit(sentence.Parts[3]);
                horizontal = new Length(double.Parse(measurement), units);
            }

            //azimuth angle
            Angle azimuth = null;
            measurement = sentence.Parts[4];
            if (!string.IsNullOrEmpty(measurement)) {
                measurement = measurement.Substring(0, measurement.Length - 1);
                AngleUnit units = GetAngleUnit(sentence.Parts[5]);
                azimuth = new Angle(double.Parse(measurement), units);
            }

            //inclination angle
            Angle inclination = null;
            measurement = sentence.Parts[6];
            if (!string.IsNullOrEmpty(measurement)) {
                measurement = measurement.Substring(0, measurement.Length - 1);
                AngleUnit units = GetAngleUnit(sentence.Parts[7]);
                inclination = new Angle(double.Parse(measurement), units);
            }

            //slope distance
            Length slope = null;
            measurement = sentence.Parts[8];
            if (!string.IsNullOrEmpty(measurement)) {
                measurement = measurement.Substring(0, measurement.Length - 1);
                LengthUnit units = GetLengthUnit(sentence.Parts[9]);
                slope = new Length(double.Parse(measurement), units);
            }

            return new GeoVector(horizontal, azimuth, inclination, slope, highQuality);
        }
    }
}