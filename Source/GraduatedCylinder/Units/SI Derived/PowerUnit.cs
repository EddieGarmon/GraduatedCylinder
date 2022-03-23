using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum PowerUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Watts,

    [UnitAbbreviation("mW")]
    [Scale(0.001)]
    MilliWatts = -3,

    [UnitAbbreviation("W")]
    [Scale(1.0)]
    Watts = 0,

    [UnitAbbreviation("kW")]
    [Scale(1000.0)]
    KiloWatts = 3,

    [UnitAbbreviation("MW")]
    [Scale(1000000.0)]
    MegaWatts = 6,

    [UnitAbbreviation("Nm/s")]
    [Scale(1.0)]
    NewtonMetersPerSecond = -100,

    [UnitAbbreviation("cal/s")]
    [Scale(4.1868)]
    CaloriesPerSecond = 100,

    [UnitAbbreviation("cal/min")]
    [Scale(0.06978)]
    CaloriesPerMinute = 101,

    [UnitAbbreviation("cal/h")]
    [Scale(0.001163)]
    CaloriesPerHour = 102,

    [UnitAbbreviation("J/s")]
    [Scale(1.0)]
    JoulesPerSecond = -101,

    [UnitAbbreviation("J/min")]
    [Scale(1.0f / 60.0)]
    JoulesPerMinute = 103,

    [UnitAbbreviation("J/h")]
    [Scale(1.0f / 3600.0)]
    JoulesPerHour = 104,

    [UnitAbbreviation("hp")]
    [Scale(0.7457e3)]
    Horsepower = 105

}