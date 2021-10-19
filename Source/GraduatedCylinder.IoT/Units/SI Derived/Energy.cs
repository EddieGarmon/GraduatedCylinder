namespace GraduatedCylinder
{
    public readonly partial struct Energy : IDimension<Energy, EnergyUnit>
    {

        public static Force operator /(Energy energy, Length length) {
            energy = energy.In(EnergyUnit.NewtonMeters);
            length = length.In(LengthUnit.Meter);
            return new Force(energy.Value / length.Value, ForceUnit.Newtons);
        }

        public static Length operator /(Energy energy, Force force) {
            energy = energy.In(EnergyUnit.NewtonMeters);
            force = force.In(ForceUnit.Newtons);
            return new Length(energy.Value / force.Value, LengthUnit.Meter);
        }

        public static Momentum operator /(Energy energy, Speed speed) {
            energy = energy.In(EnergyUnit.NewtonMeters);
            speed = speed.In(SpeedUnit.MeterPerSecond);
            return new Momentum(energy.Value / speed.Value, MomentumUnit.KilogramMetersPerSecond);
        }

        public static Power operator /(Energy energy, Time time) {
            energy = energy.In(EnergyUnit.NewtonMeters);
            time = time.In(TimeUnit.Second);
            return new Power(energy.Value / time.Value, PowerUnit.Watts);
        }

        public static Speed operator /(Energy energy, Momentum momentum) {
            energy = energy.In(EnergyUnit.NewtonMeters);
            momentum = momentum.In(MomentumUnit.KilogramMetersPerSecond);
            return new Speed(energy.Value / momentum.Value, SpeedUnit.MeterPerSecond);
        }

        public static Time operator /(Energy energy, Power power) {
            energy = energy.In(EnergyUnit.Joules);
            power = power.In(PowerUnit.Watts);
            return new Time(energy.Value / power.Value, TimeUnit.Second);
        }

    }
}