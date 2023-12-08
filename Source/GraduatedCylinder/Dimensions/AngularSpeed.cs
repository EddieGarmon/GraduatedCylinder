#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct AngularSpeed : IDimension<AngularSpeed, AngularSpeedUnit>
{

    public static AngularAcceleration operator /(AngularSpeed speed, Time time) {
        speed = speed.In(AngularSpeedUnit.RadiansPerSecond);
        time = time.In(TimeUnit.Second);
        return new AngularAcceleration(speed.Value / time.Value, AngularAccelerationUnit.RadiansPerSquareSecond);
    }

    public static Angle operator *(AngularSpeed speed, Time time) {
        speed = speed.In(AngularSpeedUnit.RadiansPerSecond);
        time = time.In(TimeUnit.Second);
        return new Angle(speed.Value * time.Value, AngleUnit.Radian);
    }

}