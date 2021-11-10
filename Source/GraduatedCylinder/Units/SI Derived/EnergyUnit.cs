using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum EnergyUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Joules,

    [UnitAbbreviation("J")]
    [Scale(1.0)]
    Joules = 0,

    [UnitAbbreviation("Nm")]
    [Scale(1.0)]
    NewtonMeters = 1,

    [UnitAbbreviation("Ws")]
    [Scale(1.0)]
    WattSeconds = 2,

    [UnitAbbreviation("cal")]
    [Scale(4.1868)]
    Calories = 3,

    [UnitAbbreviation("kgfm")]
    [Scale(9.80665)]
    KilogramForceMeters = 4,

    [UnitAbbreviation("kJ")]
    [Scale(1000.0)]
    Kilojoules = 5,

    [UnitAbbreviation("Wh")]
    [Scale(3600.0)]
    WattHours = 6,

    [UnitAbbreviation("kcal")]
    [Scale(4186.8)]
    KiloCalories = 7,

    [UnitAbbreviation("kWh")]
    [Scale(3600000.0)]
    KilowattHours = 8,

    [UnitAbbreviation("BTU")]
    [Scale(1055.056)]
    BritishThermalUnit = 9

}