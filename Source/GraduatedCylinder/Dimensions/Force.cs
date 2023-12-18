#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Force : IDimension<Force, ForceUnit>
{

    public static Acceleration operator /(Force force, Mass mass) {
        force = force.In(ForceUnit.Newtons);
        mass = mass.In(MassUnit.KiloGram);
        return new Acceleration(force.Value / mass.Value, AccelerationUnit.MeterPerSquareSecond);
    }

    public static Area operator /(Force force, Pressure pressure) {
        force = force.In(ForceUnit.Newtons);
        pressure = pressure.In(PressureUnit.NewtonsPerSquareMeter);
        return new Area(force.Value / pressure.Value, AreaUnit.SquareMeter);
    }

    public static Mass operator /(Force force, Acceleration acceleration) {
        force = force.In(ForceUnit.Newtons);
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        return new Mass(force.Value / acceleration.Value, MassUnit.KiloGram);
    }

    public static Pressure operator /(Force force, Area area) {
        force = force.In(ForceUnit.Newtons);
        area = area.In(AreaUnit.SquareMeter);
        return new Pressure(force.Value / area.Value, PressureUnit.NewtonsPerSquareMeter);
    }

    public static Energy operator *(Force force, Length length) {
        force = force.In(ForceUnit.Newtons);
        length = length.In(LengthUnit.Meter);
        return new Energy(force.Value * length.Value, EnergyUnit.NewtonMeters);
    }

    public static Momentum operator *(Force force, Time time) {
        force = force.In(ForceUnit.Newtons);
        time = time.In(TimeUnit.Second);
        return new Momentum(force.Value * time.Value, MomentumUnit.KiloGramMetersPerSecond);
    }

    public static Power operator *(Force force, Speed speed) {
        force = force.In(ForceUnit.Newtons);
        speed = speed.In(SpeedUnit.MeterPerSecond);
        return new Power(force.Value * speed.Value, PowerUnit.Watts);
    }

}