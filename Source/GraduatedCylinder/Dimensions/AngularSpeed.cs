using GraduatedCylinder.Calculators;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct AngularSpeed : IDimension<AngularSpeed, AngularSpeedUnit>
{

    public readonly Time GetPeriod() {
        AngularSpeed angularSpeed = In(AngularSpeedUnit.RadiansPerSecond);
        return new Time(Constants.TwoPi / angularSpeed.Value, TimeUnit.Second);
    }

    public static AngularAcceleration operator /(AngularSpeed speed, Time time) {
        speed = speed.In(AngularSpeedUnit.RadiansPerSecond);
        time = time.In(TimeUnit.Second);
        return new AngularAcceleration(speed.Value / time.Value, AngularAccelerationUnit.RadiansPerSquareSecond);
    }

    public static implicit operator Frequency(AngularSpeed angularSpeed) {
        angularSpeed = angularSpeed.In(AngularSpeedUnit.RadiansPerSecond);
        return new Frequency(angularSpeed.Value / Constants.TwoPi, FrequencyUnit.Hertz);
    }

    public static Angle operator *(AngularSpeed speed, Time time) {
        speed = speed.In(AngularSpeedUnit.RadiansPerSecond);
        time = time.In(TimeUnit.Second);
        return new Angle(speed.Value * time.Value, AngleUnit.Radian);
    }

}