using GraduatedCylinder.Scales;

namespace GraduatedCylinder.Units
{
    /// <summary>
    ///     Units of Energy that are currently supported, Joules is the Base Unit.
    /// </summary>
    public enum EnergyUnit : short
    {

        Unspecified = short.MinValue,

        /// <summary>
        ///     Joules, This is the Base Unit
        /// </summary>
        BaseUnit = Joules,

        /// <summary>
        ///     Joules, This is the Base Unit
        /// </summary>
        [UnitAbbreviation("J")]
        [Scale(1.0f)]
        Joules = 0,

        /// <summary>
        ///     Newton x Meters
        /// </summary>
        [UnitAbbreviation("Nm")]
        [Scale(1.0f)]
        NewtonMeters = 1,

        /// <summary>
        ///     Watt x Seconds
        /// </summary>
        [UnitAbbreviation("Ws")]
        [Scale(1.0f)]
        WattSeconds = 2,

        /// <summary>
        ///     Calories
        /// </summary>
        [UnitAbbreviation("cal")]
        [Scale(4.1868f)]
        Calories = 3,

        /// <summary>
        ///     Kilogram Force x Meters
        /// </summary>
        [UnitAbbreviation("kgfm")]
        [Scale(9.80665f)]
        KilogramForceMeters = 4,

        /// <summary>
        ///     KiloJoules, 1000 Joules
        /// </summary>
        [UnitAbbreviation("kJ")]
        [Scale(1000.0f)]
        Kilojoules = 5,

        /// <summary>
        ///     Watts x Hours
        /// </summary>
        [UnitAbbreviation("Wh")]
        [Scale(3600.0f)]
        WattHours = 6,

        /// <summary>
        ///     KiloCalories, 1000 Calories
        /// </summary>
        [UnitAbbreviation("kcal")]
        [Scale(4186.8f)]
        KiloCalories = 7,

        /// <summary>
        ///     KiloWatt x Hours
        /// </summary>
        [UnitAbbreviation("kWh")]
        [Scale(3600000.0f)]
        KilowattHours = 8,

        /// <summary>
        ///     British Thermal Units
        /// </summary>
        [UnitAbbreviation("BTU")]
        [Scale(1055.056f)]
        BritishThermalUnit = 9

    }
}