namespace GraduatedCylinder
{
    public readonly partial struct Acceleration : IDimension<Acceleration, AccelerationUnit>
    {

        public static Acceleration Gravity => new Acceleration(9.80665f, AccelerationUnit.MeterPerSecondSquared);

        public static Acceleration Zero => new Acceleration(0, AccelerationUnit.MeterPerSecondSquared);

        public static Time operator /(Acceleration acceleration, Jerk jerk) {
            acceleration = acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            jerk = jerk.In(JerkUnit.MetersPerSecondCubed);
            return new Time(acceleration.Value / jerk.Value, TimeUnit.Second);
        }

        public static Jerk operator /(Acceleration acceleration, Time time) {
            acceleration = acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            time = time.In(TimeUnit.Second);
            return new Jerk(acceleration.Value / time.Value, JerkUnit.MetersPerSecondCubed);
        }

        public static Force operator *(Acceleration acceleration, Mass mass) {
            acceleration = acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            mass = mass.In(MassUnit.Kilogram);
            return new Force(acceleration.Value * mass.Value, ForceUnit.Newtons);
        }

        public static Power operator *(Acceleration acceleration, Momentum momentum) {
            acceleration = acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            momentum = momentum.In(MomentumUnit.KilogramMetersPerSecond);
            return new Power(acceleration.Value * momentum.Value, PowerUnit.Watts);
        }

        public static Speed operator *(Acceleration acceleration, Time time) {
            acceleration = acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            time = time.In(TimeUnit.Second);
            return new Speed(acceleration.Value * time.Value, SpeedUnit.MeterPerSecond);
        }

    }
}