using DigitalHammer.Testing;

namespace GraduatedCylinder
{
    internal static class AssertionHelpers
    {

        //shrink this to increase required precision
        internal const float Tolerance32 = 1e-4f;
        internal const double Tolerance64 = 1e-4;

        public static void ShouldBeWithinToleranceOf(this float value, float expectedValue) {
            (expectedValue - value).ShouldBeLessThanOrEqualTo(Tolerance32);
            (value - expectedValue).ShouldBeLessThanOrEqualTo(Tolerance32);
        }

        public static void ShouldBeWithinToleranceOf(this double value, double expectedValue) {
            (expectedValue - value).ShouldBeLessThanOrEqualTo(Tolerance64);
            (value - expectedValue).ShouldBeLessThanOrEqualTo(Tolerance64);
        }

    }
}