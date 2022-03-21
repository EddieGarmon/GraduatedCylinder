namespace GraduatedCylinder;

public static class CloseTo
{

    public static void ShouldBeCloseTo(this double value, double target) {
        if (Math.Abs(value - target) >= Equality.Tolerance) {
            throw new Exception($"{value} is not close to {target}.");
        }
    }

}