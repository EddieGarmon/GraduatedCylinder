using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Volumetric Flow Rate that are currently supported, Liters/Second is the Base Unit.
    /// </summary>
    public enum VolumetricFlowRateUnit : short
    {

        Unspecified = short.MinValue,

        /// <summary>
        ///     Liters/Second, This is the Base Unit
        /// </summary>
        BaseUnit = LitersPerSecond,

        /// <summary>
        ///     Liters/Second, this is the Base Unit
        /// </summary>
        [UnitAbbreviation("L/s")]
        [Scale(1.0f)]
        LitersPerSecond = 0,

        /// <summary>
        ///     Liters/Minute
        /// </summary>
        [UnitAbbreviation("L/min")]
        [Scale(1.0f / 60.0f)]
        LitersPerMinute = 1,

        /// <summary>
        ///     Liters/Hour
        /// </summary>
        [UnitAbbreviation("L/h")]
        [Scale(1.0f / 3600.0f)]
        LitersPerHour = 2,

        /// <summary>
        ///     Meters³/Second
        /// </summary>
        [UnitAbbreviation("m³/s")]
        [Scale(1e3f)]
        CubicMetersPerSecond = 3,

        /// <summary>
        ///     US Gallons/Second
        /// </summary>
        [UnitAbbreviation("gal/s")]
        [Scale(3.785411784f)]
        GallonsUsPerSecond = 4,

        /// <summary>
        ///     US Gallons/Hour
        /// </summary>
        [UnitAbbreviation("gal/h")]
        [Scale(3.785411784f / 3600.0f)]
        GallonsUsPerHour = 5

    }
}