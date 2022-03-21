namespace GraduatedCylinder;

public partial struct Momentum : IDimension<Momentum, MomentumUnit>
{

    public static Force operator /(Momentum momentum, Time time) {
        momentum = momentum.In(MomentumUnit.KilogramMetersPerSecond);
        time = time.In(TimeUnit.Second);
        return new Force(momentum.Value / time.Value, ForceUnit.Newtons);
    }

    public static Mass operator /(Momentum momentum, Speed speed) {
        momentum = momentum.In(MomentumUnit.KilogramMetersPerSecond);
        speed = speed.In(SpeedUnit.MeterPerSecond);
        return new Mass(momentum.Value / speed.Value, MassUnit.Kilogram);
    }

    public static Speed operator /(Momentum momentum, Mass mass) {
        momentum = momentum.In(MomentumUnit.KilogramMetersPerSecond);
        mass = mass.In(MassUnit.Kilogram);
        return new Speed(momentum.Value / mass.Value, SpeedUnit.MeterPerSecond);
    }

    public static Time operator /(Momentum momentum, Force force) {
        momentum = momentum.In(MomentumUnit.KilogramMetersPerSecond);
        force = force.In(ForceUnit.Newtons);
        return new Time(momentum.Value / force.Value, TimeUnit.Second);
    }

}