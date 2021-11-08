using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Units of Force that are currently supported, Newtons is the Base Unit.
    /// </summary>
    public enum ForceUnit : short
    {

        Unspecified = short.MinValue,

        /// <summary>
        ///     Newtons, This is the Base Unit
        /// </summary>
        BaseUnit = Newtons,

        /// <summary>
        ///     Newtons, This is the Base Unit
        /// </summary>
        [UnitAbbreviation("N")]
        [Scale(1.0f)]
        Newtons = 0,

        /// <summary>
        ///     Pound Force
        /// </summary>
        [UnitAbbreviation("lbf")]
        [Scale(4.44822f)]
        PoundForce = 1,

        /// <summary>
        ///     Kilogram Force
        /// </summary>
        [UnitAbbreviation("kgf")]
        [Scale(9.81f)]
        KilogramForce = 2

    }
}