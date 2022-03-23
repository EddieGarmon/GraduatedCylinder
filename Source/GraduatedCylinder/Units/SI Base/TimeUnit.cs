using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum TimeUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Second,

    [UnitAbbreviation("ys")]
    [Scale(1e-24)]
    YoctoSecond = -24,

    [UnitAbbreviation("zs")]
    [Scale(1e-21)]
    ZeptoSecond = -21,

    [UnitAbbreviation("as")]
    [Scale(1e-18)]
    AttoSecond = -18,

    [UnitAbbreviation("fs")]
    [Scale(1e-15)]
    FemtoSecond = -15,

    [UnitAbbreviation("ps")]
    [Scale(1e-12)]
    PicoSecond = -12,

    [UnitAbbreviation("ns")]
    [Scale(1e-9)]
    NanoSecond = -9,

    [UnitAbbreviation("ticks")]
    [Scale(1e-7)]
    Ticks = -7,

    [UnitAbbreviation("�s")]
    [Scale(1e-6)]
    MicroSecond = -6,

    [UnitAbbreviation("ms")]
    [Scale(1e-3)]
    MilliSecond = -3,

    [UnitAbbreviation("cs")]
    [Scale(1e-2)]
    CentiSecond = -2,

    [UnitAbbreviation("ds")]
    [Scale(1e-1)]
    DeciSecond = -1,

    [UnitAbbreviation("s")]
    [Scale(1.0)]
    Second = 0,

    [UnitAbbreviation("das")]
    [Scale(10)]
    DekaSecond = 1,

    [UnitAbbreviation("hs")]
    [Scale(100)]
    HectoSecond = 2,

    [UnitAbbreviation("ks")]
    [Scale(1e3)]
    KiloSecond = 3,

    [UnitAbbreviation("Ms")]
    [Scale(1e6)]
    MegaSecond = 6,

    [UnitAbbreviation("Gs")]
    [Scale(1e9)]
    GigaSecond = 9,

    [UnitAbbreviation("Ts")]
    [Scale(1e12)]
    TeraSecond = 12,

    [UnitAbbreviation("Ps")]
    [Scale(1e15)]
    PetaSecond = 15,

    [UnitAbbreviation("Es")]
    [Scale(1e18)]
    ExaSecond = 18,

    [UnitAbbreviation("Zs")]
    [Scale(1e21)]
    ZettaSecond = 21,

    [UnitAbbreviation("Ys")]
    [Scale(1e24)]
    YottaSecond = 24,

    [UnitAbbreviation("min")]
    [Scale(60.0)]
    Minutes = 110,

    [UnitAbbreviation("h")]
    [Scale(3600.0)]
    Hours = 111,

    [UnitAbbreviation("d")]
    [Scale(86400.0)]
    Days = 112,

    [UnitAbbreviation("week")]
    [Scale(604800)]
    Weeks = 113,

}