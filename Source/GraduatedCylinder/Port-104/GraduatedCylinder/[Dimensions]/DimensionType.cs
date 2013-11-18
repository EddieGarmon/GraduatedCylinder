namespace GraduatedCylinder
{
    /// <summary>
    ///     This is a list of all currently supported measurement types.
    /// </summary>
    public enum DimensionType
    {
        [UnitsType(typeof(UnknownUnit))]
        Unknown = 0,

        [UnitsType(typeof(AccelerationUnit))]
        Acceleration,

        [UnitsType(typeof(AngleUnit))]
        Angle,

        [UnitsType(typeof(AngularAccelerationUnit))]
        AngularAcceleration,

        [UnitsType(typeof(AngularVelocityUnit))]
        AngularVelocity,

        [UnitsType(typeof(AreaUnit))]
        Area,

        [UnitsType(typeof(CurrentUnit))]
        Current,

        [UnitsType(typeof(DensityUnit))]
        Density,

        [UnitsType(typeof(EnergyUnit))]
        Energy,

        [UnitsType(typeof(ForceUnit))]
        Force,

        [UnitsType(typeof(FrequencyUnit))]
        Frequency,

        [UnitsType(typeof(JerkUnit))]
        Jerk,

        [UnitsType(typeof(LengthUnit))]
        Length,

        [UnitsType(typeof(MassUnit))]
        Mass,

        [UnitsType(typeof(MassFlowRateUnit))]
        MassFlowRate,

        [UnitsType(typeof(MomentumUnit))]
        Momentum,

        [UnitsType(typeof(NumericUnit))]
        Numeric,

        [UnitsType(typeof(PowerUnit))]
        Power,

        [UnitsType(typeof(PressureUnit))]
        Pressure,

        [UnitsType(typeof(ResistanceUnit))]
        Resistance,

        [UnitsType(typeof(SpeedUnit))]
        Speed,

        [UnitsType(typeof(SpeedSquaredUnit))]
        SpeedSquared,

        [UnitsType(typeof(TemperatureUnit))]
        Temperature,

        [UnitsType(typeof(TimeUnit))]
        Time,

        [UnitsType(typeof(TorqueUnit))]
        Torque,

        [UnitsType(typeof(VoltageUnit))]
        Voltage,

        [UnitsType(typeof(VolumeUnit))]
        Volume,

        [UnitsType(typeof(VolumetricFlowRateUnit))]
        VolumetricFlowRate,
    }
}