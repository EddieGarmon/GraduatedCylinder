using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum EnergyUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Joules,

    [UnitAbbreviation("mJ")]
    [Scale(0.001)]
    Millijoules = -3,

    [UnitAbbreviation("J")]
    [Scale(1.0)]
    Joules = 0,

    [UnitAbbreviation("kJ")]
    [Scale(1000.0)]
    Kilojoules = 3,

    [UnitAbbreviation("Nm")]
    [Scale(1.0)]
    NewtonMeters = -100,

    [UnitAbbreviation("Ws")]
    [Scale(1.0)]
    WattSeconds = -101,

    [UnitAbbreviation("cal")]
    [Scale(4.1868)]
    Calories = 100,

    [UnitAbbreviation("kcal")]
    [Scale(4186.8)]
    KiloCalories = 101,

    [UnitAbbreviation("kgfm")]
    [Scale(9.80665)]
    KilogramForceMeters = 102,

    [UnitAbbreviation("Wh")]
    [Scale(3600.0)]
    WattHours = 103,

    [UnitAbbreviation("kWh")]
    [Scale(3600000.0)]
    KilowattHours = 104,

    [UnitAbbreviation("BTU")]
    [Scale(1055.056)]
    BritishThermalUnit = 105

}