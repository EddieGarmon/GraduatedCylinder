namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Mass Flow Rate that are currently supported, Kilograms/Second is the Base Unit.
    /// </summary>
    public enum MassFlowRateUnit
    {
        /// <summary>
        ///     Kilograms/Second, This is the Base Unit
        /// </summary>
        BaseUnit = KilogramsPerSecond,

        /// <summary>
        ///     Kilograms/Second, This is the Base Unit
        /// </summary>
        [UnitAbbreviation("kg/s")]
        [Scale(1.0)]
        KilogramsPerSecond = 0,

        /// <summary>
        ///     Grams/Second
        /// </summary>
        [UnitAbbreviation("g/s")]
        [Scale(1e-3)]
        GramsPerSecond = 1,

        /// <summary>
        ///     Kilograms/Minute
        /// </summary>
        [UnitAbbreviation("kg/min")]
        [Scale(1.0 / 60.0)]
        KilogramsPerMinute = 2,

        /// <summary>
        ///     Kilograms/Hour
        /// </summary>
        [UnitAbbreviation("kg/h")]
        [Scale(1.0 / 3600.0)]
        KilogramsPerHour = 3,

        /// <summary>
        ///     Pounds/Second
        /// </summary>
        [UnitAbbreviation("lbs/s")]
        [Scale(0.45359237)]
        PoundsPerSecond = 4,
    }
}