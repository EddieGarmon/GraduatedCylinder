using System;

namespace GraduatedCylinder.Geo
{
    public static class GeoComparer
    {
        static GeoComparer() {
            DefaultPrecision = GeoComparerPrecision.Decimeter;
        }

        public static GeoComparerPrecision DefaultPrecision { get; set; }

        public static bool AreEqual(Latitude left, Latitude right) {
            return AreEqual(left, right, DefaultPrecision);
        }

        public static bool AreEqual(Latitude left, Latitude right, GeoComparerPrecision precision) {
            double tolerance = GetTolerance(precision);
            return Math.Abs(left.Value - right.Value) < tolerance;
        }

        public static bool AreEqual(Longitude left, Longitude right) {
            return AreEqual(left, right, DefaultPrecision);
        }

        public static bool AreEqual(Longitude left, Longitude right, GeoComparerPrecision precision) {
            double tolerance = GetTolerance(precision);
            return Math.Abs(left.Value - right.Value) < tolerance;
        }

        private static double GetTolerance(GeoComparerPrecision precision) {
            switch (precision) {
                case GeoComparerPrecision.Meter:
                    return 0.00001;
                case GeoComparerPrecision.Decimeter:
                    return 0.000001;
                case GeoComparerPrecision.Centimeter:
                    return 0.0000001;
                case GeoComparerPrecision.Millimeter:
                    return 0.00000001;
                default:
                    throw new ArgumentOutOfRangeException("precision");
            }
        }
    }
}