namespace GraduatedCylinder;

public partial struct Time : IDimension<Time, TimeUnit>
{

    public static implicit operator Time(TimeSpan source) {
        return new Time((float)source.TotalSeconds, TimeUnit.Second);
    }

    public static implicit operator TimeSpan(Time source) {
        return new TimeSpan(Convert.ToInt64(source.In(TimeUnit.Ticks)));
    }

    public static Acceleration operator *(Time time, Jerk jerk) {
        time = time.In(TimeUnit.Second);
        jerk = jerk.In(JerkUnit.MetersPerSecondCubed);
        return new Acceleration(time.Value * jerk.Value, AccelerationUnit.MeterPerSquareSecond);
    }

    public static Speed operator *(Time time, Acceleration acceleration) {
        time = time.In(TimeUnit.Second);
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        return new Speed(time.Value * acceleration.Value, SpeedUnit.MeterPerSecond);
    }

    public static Length operator *(Time time, Speed speed) {
        time = time.In(TimeUnit.Second);
        speed = speed.In(SpeedUnit.MeterPerSecond);
        return new Length(time.Value * speed.Value, LengthUnit.Meter);
    }

    public static AngularSpeed operator *(Time time, AngularAcceleration acceleration) {
        time = time.In(TimeUnit.Second);
        acceleration = acceleration.In(AngularAccelerationUnit.RadiansPerSquareSecond);
        return new AngularSpeed(time.Value * acceleration.Value, AngularSpeedUnit.RadiansPerSecond);
    }

    public static Angle operator *(Time time, AngularSpeed speed) {
        speed = speed.In(AngularSpeedUnit.RadiansPerSecond);
        time = time.In(TimeUnit.Second);
        return new Angle(time.Value * speed.Value, AngleUnit.Radian);
    }

    public static Energy operator *(Time time, Power power) {
        time = time.In(TimeUnit.Second);
        power = power.In(PowerUnit.NewtonMetersPerSecond);
        return new Energy(time.Value * power.Value, EnergyUnit.NewtonMeters);
    }

    public static Momentum operator *(Time time, Force force) {
        time = time.In(TimeUnit.Second);
        force = force.In(ForceUnit.Newtons);
        return new Momentum(time.Value * force.Value, MomentumUnit.KiloGramMetersPerSecond);
    }

    public static Mass operator *(Time time, MassFlowRate massFlowRate) {
        time = time.In(TimeUnit.Second);
        massFlowRate = massFlowRate.In(MassFlowRateUnit.KiloGramsPerSecond);
        return new Mass(time.Value * massFlowRate.Value, MassUnit.KiloGram);
    }

    public static Volume operator *(Time time, VolumetricFlowRate volumetricFlowRate) {
        time = time.In(TimeUnit.Second);
        volumetricFlowRate = volumetricFlowRate.In(VolumetricFlowRateUnit.CubicMetersPerSecond);
        return new Volume(time.Value * volumetricFlowRate.Value, VolumeUnit.CubicMeters);
    }

}