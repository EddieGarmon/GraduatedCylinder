using GraduatedCylinder.Scales;

namespace GraduatedCylinder.Units
{
    /// <summary>
    ///     Units of Mass Flow Rate that are currently supported, Kilograms/Second is the Base Unit.
    /// </summary>
    public enum MassFlowRateUnit : short
    {

        Unspecified = short.MinValue,

        /// <summary>
        ///     Kilograms/Second, This is the Base Unit
        /// </summary>
        BaseUnit = KilogramsPerSecond,

        /// <summary>
        ///     Kilograms/Second, This is the Base Unit
        /// </summary>
        [UnitAbbreviation("kg/s")]
        [Scale(1.0f)]
        KilogramsPerSecond = 0,

        /// <summary>
        ///     Grams/Second
        /// </summary>
        [UnitAbbreviation("g/s")]
        [Scale(1e-3f)]
        GramsPerSecond = 1,

        /// <summary>
        ///     Kilograms/Minute
        /// </summary>
        [UnitAbbreviation("kg/min")]
        [Scale(1.0f / 60.0f)]
        KilogramsPerMinute = 2,

        /// <summary>
        ///     Kilograms/Hour
        /// </summary>
        [UnitAbbreviation("kg/h")]
        [Scale(1.0f / 3600.0f)]
        KilogramsPerHour = 3,

        /// <summary>
        ///     Pounds/Second
        /// </summary>
        [UnitAbbreviation("lbs/s")]
        [Scale(0.45359237f)]
        PoundsPerSecond = 4

    }
}