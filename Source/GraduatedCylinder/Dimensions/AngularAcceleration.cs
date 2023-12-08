#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct AngularAcceleration : IDimension<AngularAcceleration, AngularAccelerationUnit>
{

    public static AngularSpeed operator *(AngularAcceleration acceleration, Time time) {
        acceleration = acceleration.In(AngularAccelerationUnit.RadiansPerSquareSecond);
        time = time.In(TimeUnit.Second);
        return new AngularSpeed(acceleration.Value * time.Value, AngularSpeedUnit.RadiansPerSecond);
    }

}