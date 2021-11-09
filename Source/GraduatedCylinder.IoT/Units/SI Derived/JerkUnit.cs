using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Jerk that are currently supported, Meters/Seconds� is the Base Unit.
    /// </summary>
    public enum JerkUnit : short
    {

        Unspecified = short.MinValue,

        /// <summary>
        ///     Meters/Seconds�, This is the Base Unit
        /// </summary>
        BaseUnit = MetersPerSecondCubed,

        /// <summary>
        ///     Meters/Seconds�
        /// </summary>
        [UnitAbbreviation("m/s�")]
        [Scale(1.0f)]
        MetersPerSecondCubed = 0,

        /// <summary>
        ///     Kilometers/Seconds�
        /// </summary>
        [UnitAbbreviation("km/s�")]
        [Scale(1e3f)]
        KiloMetersPerSecondCubed = 1,

        /// <summary>
        ///     Miles/Second�
        /// </summary>
        [UnitAbbreviation("miles/s�")]
        [Scale(1609.344f)]
        MilesPerSecondCubed = 2

    }
}