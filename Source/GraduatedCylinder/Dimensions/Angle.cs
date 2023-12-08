#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Angle : IDimension<Angle, AngleUnit>
{

    public static AngularSpeed operator /(Angle angle, Time time) {
        angle = angle.In(AngleUnit.Radian);
        time = time.In(TimeUnit.Second);
        return new AngularSpeed(angle.Value / time.Value, AngularSpeedUnit.RadiansPerSecond);
    }

}