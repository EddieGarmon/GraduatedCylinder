namespace GraduatedCylinder
{
    /// <summary>
    ///     This is a list of all currently supported measurement types.
    /// </summary>
    public enum DimensionType : long
    {
        [UnitsType(typeof(UnknownUnit))]
        Unknown = 0,

        [UnitsType(typeof(AccelerationUnit))]
        Acceleration,

        [UnitsType(typeof(AmountOfSubstanceUnit))]
        AmountOfSubstance,

        [UnitsType(typeof(AngleUnit))]
        Angle,

        [UnitsType(typeof(AngularAccelerationUnit))]
        AngularAcceleration,

        [UnitsType(typeof(AreaUnit))]
        Area,

        [UnitsType(typeof(ElectricCurrentUnit))]
        ElectricCurrent,

        [UnitsType(typeof(ElectricPotentialUnit))]
        ElectricPotential,

        [UnitsType(typeof(ElectricResistanceUnit))]
        ElectricResistance,

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

        [UnitsType(typeof(LuminousIntensityUnit))]
        LuminousIntensity,

        [UnitsType(typeof(MassUnit))]
        Mass,

        [UnitsType(typeof(MassDensityUnit))]
        MassDensity,

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

        [UnitsType(typeof(VolumeUnit))]
        Volume,

        [UnitsType(typeof(VolumetricFlowRateUnit))]
        VolumetricFlowRate
    }
}