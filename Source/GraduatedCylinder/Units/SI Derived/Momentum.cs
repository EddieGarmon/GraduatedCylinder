namespace GraduatedCylinder;

public partial struct Momentum : IDimension<Momentum, MomentumUnit>
{

    public static Force operator /(Momentum momentum, Time time) {
        momentum = momentum.In(MomentumUnit.KiloGramMetersPerSecond);
        time = time.In(TimeUnit.Second);
        return new Force(momentum.Value / time.Value, ForceUnit.Newtons);
    }

    public static Mass operator /(Momentum momentum, Speed speed) {
        momentum = momentum.In(MomentumUnit.KiloGramMetersPerSecond);
        speed = speed.In(SpeedUnit.MeterPerSecond);
        return new Mass(momentum.Value / speed.Value, MassUnit.KiloGram);
    }

    public static Speed operator /(Momentum momentum, Mass mass) {
        momentum = momentum.In(MomentumUnit.KiloGramMetersPerSecond);
        mass = mass.In(MassUnit.KiloGram);
        return new Speed(momentum.Value / mass.Value, SpeedUnit.MeterPerSecond);
    }

    public static Time operator /(Momentum momentum, Force force) {
        momentum = momentum.In(MomentumUnit.KiloGramMetersPerSecond);
        force = force.In(ForceUnit.Newtons);
        return new Time(momentum.Value / force.Value, TimeUnit.Second);
    }

    public static Power operator *(Momentum momentum, Acceleration acceleration) {
        momentum = momentum.In(MomentumUnit.KiloGramMetersPerSecond);
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        return new Power(momentum.Value * acceleration.Value, PowerUnit.Watts);
    }

}