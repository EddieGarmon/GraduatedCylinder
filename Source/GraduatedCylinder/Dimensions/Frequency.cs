using GraduatedCylinder.Calculators;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Frequency : IDimension<Frequency, FrequencyUnit>
{

    public readonly Time GetPeriod() {
        Frequency frequency = In(FrequencyUnit.Hertz);
        return new Time(1 / frequency.Value, TimeUnit.Second);
    }

    public static implicit operator AngularSpeed(Frequency frequency) {
        frequency = frequency.In(FrequencyUnit.Hertz);
        return new AngularSpeed(frequency.Value * Constants.TwoPi, AngularSpeedUnit.RadiansPerSecond);
    }

}