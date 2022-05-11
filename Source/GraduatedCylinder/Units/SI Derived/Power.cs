namespace GraduatedCylinder;

public partial struct Power : IDimension<Power, PowerUnit>
{

    public static Acceleration operator /(Power power, Momentum momentum) {
        power = power.In(PowerUnit.Watts);
        momentum = momentum.In(MomentumUnit.KiloGramMetersPerSecond);
        return new Acceleration(power.Value / momentum.Value, AccelerationUnit.MeterPerSquareSecond);
    }

    public static Momentum operator /(Power power, Acceleration acceleration) {
        power = power.In(PowerUnit.Watts);
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        return new Momentum(power.Value / acceleration.Value, MomentumUnit.KiloGramMetersPerSecond);
    }

    public static Force operator /(Power power, Speed speed) {
        power = power.In(PowerUnit.Watts);
        speed = speed.In(SpeedUnit.MeterPerSecond);
        return new Force(power.Value / speed.Value, ForceUnit.Newtons);
    }

    public static Speed operator /(Power power, Force force) {
        power = power.In(PowerUnit.Watts);
        force = force.In(ForceUnit.Newtons);
        return new Speed(power.Value / force.Value, SpeedUnit.MeterPerSecond);
    }

    public static Frequency operator /(Power power, Torque torque) {
        power = power.In(PowerUnit.Watts);
        torque = torque.In(TorqueUnit.NewtonMeters);
        return new Frequency(power.Value / torque.Value, FrequencyUnit.RevolutionsPerMinute);
    }

    public static Torque operator /(Power power, Frequency angularVelocity) {
        power = power.In(PowerUnit.Watts);
        angularVelocity = angularVelocity.In(FrequencyUnit.RevolutionPerSecond);
        return new Torque(power.Value / angularVelocity.Value, TorqueUnit.NewtonMeters);
    }

    public static ElectricCurrent operator /(Power power, ElectricPotential voltage) {
        power = power.In(PowerUnit.Watts);
        voltage = voltage.In(ElectricPotentialUnit.Volt);
        return new ElectricCurrent(power.Value / voltage.Value, ElectricCurrentUnit.Ampere);
    }

    public static ElectricPotential operator /(Power power, ElectricCurrent current) {
        power = power.In(PowerUnit.Watts);
        current = current.In(ElectricCurrentUnit.Ampere);
        return new ElectricPotential(power.Value / current.Value, ElectricPotentialUnit.Volt);
    }

}