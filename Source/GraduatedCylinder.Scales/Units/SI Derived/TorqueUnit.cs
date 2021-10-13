using GraduatedCylinder.Scales;

namespace GraduatedCylinder.Units
{
    /// <summary>
    ///     Units of Torque that are currently supported, Newton x Meters is the Base Unit.
    /// </summary>
    public enum TorqueUnit : short
    {

        Unspecified = short.MinValue,

        /// <summary>
        ///     Newton x Meters, This is the Base Unit
        /// </summary>
        BaseUnit = NewtonMeters,

        /// <summary>
        ///     Newton x Meters
        /// </summary>
        [UnitAbbreviation("Nm")]
        [Scale(1.0f)]
        NewtonMeters = 0,

        /// <summary>
        ///     Kilogram Force x Meters
        /// </summary>
        [UnitAbbreviation("kgf-m")]
        [Scale(9.81f)]
        KilogramForceMeters = 1,

        /// <summary>
        ///     Foot x Pounds
        /// </summary>
        [UnitAbbreviation("ft-lbs")]
        [Scale(1.35581795f)]
        FootPounds = 2

    }
}