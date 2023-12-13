#if GraduatedCylinder
namespace GraduatedCylinder.Calculators;
#endif
#if Pipette
namespace Pipette.Calculators;
#endif

public static class MotionCalculator
{

    public static Acceleration ComputeConstantAcceleration(Speed startSpeed, Speed endSpeed, Length distance) {
        startSpeed = startSpeed.In(SpeedUnit.MeterPerSecond);
        endSpeed = endSpeed.In(SpeedUnit.MeterPerSecond);
        distance = distance.In(LengthUnit.Meter);

        return new Acceleration((endSpeed.Value * endSpeed.Value - startSpeed.Value * startSpeed.Value) / (2 * distance.Value),
                                AccelerationUnit.MeterPerSquareSecond);
    }

}