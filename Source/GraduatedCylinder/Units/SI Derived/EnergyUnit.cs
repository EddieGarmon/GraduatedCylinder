using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum EnergyUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Joules,

        [UnitAbbreviation("J")]
        [Scale(1.0f)]
        Joules = 0,

        [UnitAbbreviation("Nm")]
        [Scale(1.0f)]
        NewtonMeters = 1,

        [UnitAbbreviation("Ws")]
        [Scale(1.0f)]
        WattSeconds = 2,

        [UnitAbbreviation("cal")]
        [Scale(4.1868f)]
        Calories = 3,

        [UnitAbbreviation("kgfm")]
        [Scale(9.80665f)]
        KilogramForceMeters = 4,

        [UnitAbbreviation("kJ")]
        [Scale(1000.0f)]
        Kilojoules = 5,

        [UnitAbbreviation("Wh")]
        [Scale(3600.0f)]
        WattHours = 6,

        [UnitAbbreviation("kcal")]
        [Scale(4186.8f)]
        KiloCalories = 7,

        [UnitAbbreviation("kWh")]
        [Scale(3600000.0f)]
        KilowattHours = 8,

        [UnitAbbreviation("BTU")]
        [Scale(1055.056f)]
        BritishThermalUnit = 9

    }
}