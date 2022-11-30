namespace GraduatedCylinder;

public partial struct Acceleration : IDimension<Acceleration, AccelerationUnit>
{

    public static Acceleration Gravity => new(9.80665f, AccelerationUnit.MeterPerSquareSecond);

    public static Time operator /(Acceleration acceleration, Jerk jerk) {
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        jerk = jerk.In(JerkUnit.MetersPerSecondCubed);
        return new Time(acceleration.Value / jerk.Value, TimeUnit.Second);
    }

    public static Jerk operator /(Acceleration acceleration, Time time) {
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        time = time.In(TimeUnit.Second);
        return new Jerk(acceleration.Value / time.Value, JerkUnit.MetersPerSecondCubed);
    }

    public static Frequency operator /(Acceleration acceleration, Speed speed) {
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        speed = speed.In(SpeedUnit.MeterPerSecond);
        return new Frequency(acceleration.Value / speed.Value, FrequencyUnit.Hertz);
    }

    public static Speed operator /(Acceleration acceleration, Frequency frequency) {
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        frequency = frequency.In(FrequencyUnit.Hertz);
        return new Speed(acceleration.Value / frequency.Value, SpeedUnit.MeterPerSecond);
    }

    public static Force operator *(Acceleration acceleration, Mass mass) {
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        mass = mass.In(MassUnit.KiloGram);
        return new Force(acceleration.Value * mass.Value, ForceUnit.Newtons);
    }

    public static Power operator *(Acceleration acceleration, Momentum momentum) {
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        momentum = momentum.In(MomentumUnit.KiloGramMetersPerSecond);
        return new Power(acceleration.Value * momentum.Value, PowerUnit.Watts);
    }

    public static Speed operator *(Acceleration acceleration, Time time) {
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        time = time.In(TimeUnit.Second);
        return new Speed(acceleration.Value * time.Value, SpeedUnit.MeterPerSecond);
    }

    public static Jerk operator *(Acceleration acceleration, Frequency frequency) {
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        frequency = frequency.In(FrequencyUnit.Hertz);
        return new Jerk(acceleration.Value * frequency.Value, JerkUnit.MetersPerSecondCubed);
    }

}