using GraduatedCylinder.Scales;

namespace GraduatedCylinder.Units
{
    /// <summary>
    ///     Units of Pressure that are currently supported, Pascals is the Base Unit.
    /// </summary>
    public enum PressureUnit : short
    {

        Unspecified = short.MinValue,

        /// <summary>
        ///     Pascals, This is the Base Unit
        /// </summary>
        BaseUnit = Pascals,

        /// <summary>
        ///     Pascals, this is the Base Unit
        /// </summary>
        [UnitAbbreviation("Pa")]
        [Scale(1.0f)]
        Pascals = 0,

        /// <summary>
        ///     MegaPascals
        /// </summary>
        [UnitAbbreviation("MPa")]
        [Scale(1e6f)]
        MegaPascals = 1,

        /// <summary>
        ///     Newtons/Meters^2
        /// </summary>
        [UnitAbbreviation("N/m^2")]
        [Scale(1.0f)]
        NewtonsPerSquareMeter = 2,

        /// <summary>
        ///     Inches of Mercury
        /// </summary>
        [UnitAbbreviation("in Hg")]
        [Scale(3386f)]
        InchesOfMercury = 3,

        /// <summary>
        ///     Kilogram Force/Meters^2
        /// </summary>
        [UnitAbbreviation("kgf/m^2")]
        [Scale(9.80665f)]
        KilogramForcePerSquareMeter = 4,

        /// <summary>
        ///     Kilopascals
        /// </summary>
        [UnitAbbreviation("kPa")]
        [Scale(1e3f)]
        KiloPascals = 5,

        /// <summary>
        ///     MilliBars
        /// </summary>
        [UnitAbbreviation("mBar")]
        [Scale(1e2f)]
        MilliBars = 6,

        /// <summary>
        ///     Bars
        /// </summary>
        [UnitAbbreviation("bar")]
        [Scale(1e5f)]
        Bars = 7,

        /// <summary>
        ///     Pounds/Inch^2
        /// </summary>
        [UnitAbbreviation("psi")]
        [Scale(6894.76f)]
        PoundsPerSquareInch = 8

    }
}