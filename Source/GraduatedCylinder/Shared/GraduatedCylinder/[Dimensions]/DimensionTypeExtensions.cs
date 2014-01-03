using System;

namespace GraduatedCylinder
{
    internal static class DimensionTypeExtensions
    {
        public static void ShouldBe(this DimensionType actual, DimensionType expected) {
            if (actual != expected) {
                throw new Exception(string.Format("Cannot convert '{0}Unit' to '{1}Unit'.", actual, expected));
            }
        }
    }
}