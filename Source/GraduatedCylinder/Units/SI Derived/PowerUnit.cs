using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum PowerUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Watts,

        [UnitAbbreviation("W")]
        [Scale(1.0f)]
        Watts = 0,

        [UnitAbbreviation("Nm/s")]
        [Scale(1.0f)]
        NewtonMetersPerSecond = 1,

        [UnitAbbreviation("cal/h")]
        [Scale(0.001163f)]
        CaloriesPerHour = 2,

        [UnitAbbreviation("J/h")]
        [Scale(1.0f / 3600.0f)]
        JoulesPerHour = 3,

        [UnitAbbreviation("cal/min")]
        [Scale(0.06978f)]
        CaloriesPerMinute = 4,

        [UnitAbbreviation("J/min")]
        [Scale(1.0f / 60.0f)]
        JoulesPerMinute = 5,

        [UnitAbbreviation("J/s")]
        [Scale(1.0f)]
        JoulesPerSecond = 6,

        [UnitAbbreviation("cal/s")]
        [Scale(4.1868f)]
        CaloriesPerSecond = 7,

        [UnitAbbreviation("kW")]
        [Scale(1000.0f)]
        Kilowatts = 8,

        [UnitAbbreviation("MW")]
        [Scale(1000000.0f)]
        Megawatts = 9,

        [UnitAbbreviation("hp")]
        [Scale(0.7457e3f)]
        Horsepower = 10

    }
}