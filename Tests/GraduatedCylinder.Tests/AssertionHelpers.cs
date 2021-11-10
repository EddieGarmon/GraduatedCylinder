namespace GraduatedCylinder;

internal static class AssertionHelpers
{

    //shrink this to increase required precision
    internal const double Tolerance = 1e-4;

    public static void ShouldBeWithinToleranceOf(this double value, double expectedValue) {
        double delta = value < expectedValue ? expectedValue - value : value - expectedValue;
        if (delta > Tolerance) {
            throw new ToleranceException(value, expectedValue, delta);
        }
    }

}