namespace GraduatedCylinder.Calculators;

public class MotionCalculator
{

    public static Acceleration ComputeConstantAcceleration(Speed startSpeed, Speed endSpeed, Length distance) {
        startSpeed = startSpeed.In(SpeedUnit.MeterPerSecond);
        endSpeed = endSpeed.In(SpeedUnit.MeterPerSecond);
        distance = distance.In(LengthUnit.Meter);

        double value = ((endSpeed.Value * endSpeed.Value) - (startSpeed.Value * startSpeed.Value)) / (2 * distance.Value);
        return new Acceleration(value, AccelerationUnit.MeterPerSquareSecond);
    }

}