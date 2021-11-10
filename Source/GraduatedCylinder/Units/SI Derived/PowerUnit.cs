using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum PowerUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Watts,

    [UnitAbbreviation("W")]
    [Scale(1.0)]
    Watts = 0,

    [UnitAbbreviation("Nm/s")]
    [Scale(1.0)]
    NewtonMetersPerSecond = 1,

    [UnitAbbreviation("cal/h")]
    [Scale(0.001163)]
    CaloriesPerHour = 2,

    [UnitAbbreviation("J/h")]
    [Scale(1.0f / 3600.0)]
    JoulesPerHour = 3,

    [UnitAbbreviation("cal/min")]
    [Scale(0.06978)]
    CaloriesPerMinute = 4,

    [UnitAbbreviation("J/min")]
    [Scale(1.0f / 60.0)]
    JoulesPerMinute = 5,

    [UnitAbbreviation("J/s")]
    [Scale(1.0)]
    JoulesPerSecond = 6,

    [UnitAbbreviation("cal/s")]
    [Scale(4.1868)]
    CaloriesPerSecond = 7,

    [UnitAbbreviation("kW")]
    [Scale(1000.0)]
    Kilowatts = 8,

    [UnitAbbreviation("MW")]
    [Scale(1000000.0)]
    Megawatts = 9,

    [UnitAbbreviation("hp")]
    [Scale(0.7457e3)]
    Horsepower = 10

}