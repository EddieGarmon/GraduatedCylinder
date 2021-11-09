using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Jerk that are currently supported, Meters/Seconds³ is the Base Unit.
    /// </summary>
    public enum JerkUnit : short
    {

        Unspecified = short.MinValue,

        /// <summary>
        ///     Meters/Seconds³, This is the Base Unit
        /// </summary>
        BaseUnit = MetersPerSecondCubed,

        /// <summary>
        ///     Meters/Seconds³
        /// </summary>
        [UnitAbbreviation("m/s³")]
        [Scale(1.0f)]
        MetersPerSecondCubed = 0,

        /// <summary>
        ///     Kilometers/Seconds³
        /// </summary>
        [UnitAbbreviation("km/s³")]
        [Scale(1e3f)]
        KiloMetersPerSecondCubed = 1,

        /// <summary>
        ///     Miles/Second³
        /// </summary>
        [UnitAbbreviation("miles/s³")]
        [Scale(1609.344f)]
        MilesPerSecondCubed = 2

    }
}