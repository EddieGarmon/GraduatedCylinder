using DigitalHammer.Testing;

namespace GraduatedCylinder
{
    internal static class TestConstants
    {
        internal const double Epsilon = 1e-4; //shrink this to increase required precision

        public static void ShouldBeWithinEpsilonOf(this double value, double expectedValue) {
            (expectedValue - value).ShouldBeLessThanOrEqualTo(Epsilon);
            (value - expectedValue).ShouldBeLessThanOrEqualTo(Epsilon);
        }
    }
}