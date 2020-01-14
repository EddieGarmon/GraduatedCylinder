using System;

namespace GraduatedCylinder.Geo
{
    public static class GreatArc
    {
        private static readonly Length EarthsRadius = new Length(6371, LengthUnit.Kilometer);

        //http://www.movable-type.co.uk/scripts/latlong.html
        public static Length Distance(GeoPosition start, GeoPosition stop) {
            var phi1 = new Angle(start.Latitude, AngleUnit.Degree) {
                Units = AngleUnit.Radian
            };
            var phi2 = new Angle(stop.Latitude, AngleUnit.Degree) {
                Units = AngleUnit.Radian
            };
            var deltaPhi = new Angle(stop.Latitude - start.Latitude, AngleUnit.Degree) {
                Units = AngleUnit.Radian
            };
            var deltaLong = new Angle(stop.Longitude - start.Longitude, AngleUnit.Degree) {
                Units = AngleUnit.Radian
            };

            var sinOfHalfPhi = Math.Sin(deltaPhi.Value / 2);
            var sinOfHalfLong = Math.Sin(deltaLong.Value / 2);

            var a = sinOfHalfPhi * sinOfHalfPhi
                    + Math.Cos(phi1.Value) * Math.Cos(phi2.Value) * sinOfHalfLong * sinOfHalfLong;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthsRadius * c;
        }
    }
}