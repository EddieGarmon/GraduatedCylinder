using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum TimeUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Second,

    [UnitAbbreviation("ys")]
    [Scale(1e-24)]
    Yoctosecond = -24,

    [UnitAbbreviation("zs")]
    [Scale(1e-21)]
    Zeptosecond = -21,

    [UnitAbbreviation("as")]
    [Scale(1e-18)]
    Attosecond = -18,

    [UnitAbbreviation("fs")]
    [Scale(1e-15)]
    Femtosecond = -15,

    [UnitAbbreviation("ps")]
    [Scale(1e-12)]
    Picosecond = -12,

    [UnitAbbreviation("ns")]
    [Scale(1e-9)]
    Nanosecond = -9,

    [UnitAbbreviation("µs")]
    [Scale(1e-6)]
    MicroSecond = -6,

    [UnitAbbreviation("ms")]
    [Scale(1e-3)]
    MilliSecond = -3,

    [UnitAbbreviation("cs")]
    [Scale(1e-2)]
    Centisecond = -2,

    [UnitAbbreviation("ds")]
    [Scale(1e-1)]
    Decisecond = -1,

    [UnitAbbreviation("s")]
    [Scale(1.0)]
    Second = 0,

    [UnitAbbreviation("das")]
    [Scale(10)]
    Dekasecond = 1,

    [UnitAbbreviation("hs")]
    [Scale(100)]
    Hectosecond = 2,

    [UnitAbbreviation("ks")]
    [Scale(1e3)]
    Kilosecond = 3,

    [UnitAbbreviation("Ms")]
    [Scale(1e6)]
    Megasecond = 6,

    [UnitAbbreviation("Gs")]
    [Scale(1e9)]
    Gigasecond = 9,

    [UnitAbbreviation("Ts")]
    [Scale(1e12)]
    Terasecond = 12,

    [UnitAbbreviation("Ps")]
    [Scale(1e15)]
    Petasecond = 15,

    [UnitAbbreviation("Es")]
    [Scale(1e18)]
    Exasecond = 18,

    [UnitAbbreviation("Zs")]
    [Scale(1e21)]
    Zettasecond = 21,

    [UnitAbbreviation("Ys")]
    [Scale(1e24)]
    Yottasecond = 24,

    [UnitAbbreviation("min")]
    [Scale(60.0)]
    Minutes = 103,

    [UnitAbbreviation("h")]
    [Scale(3600.0)]
    Hours = 104,

    [UnitAbbreviation("d")]
    [Scale(86400.0)]
    Days = 105,

    //Weeks = 106,
    //Months = 107,
    //Years = 108,

    [UnitAbbreviation("ticks")]
    [Scale(1e-7)]
    Ticks = 110

}