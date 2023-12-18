namespace Pipette;

public static class CloseTo
{

    public static void ShouldBeCloseTo(this float value, float target) {
        if (Math.Abs(value - target) >= Equality.Tolerance) {
            throw new Exception($"{value} is not close to {target}.");
        }
    }

}