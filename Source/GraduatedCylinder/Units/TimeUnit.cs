using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Time))]
public enum TimeUnit : short
{

    Unspecified = short.MinValue,

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

    [UnitAbbreviation("µs")]
    [Scale(1e-6)]
    MicroSecond = -6,

    [UnitAbbreviation("ms")]
    [Scale(1e-3)]
    [Extension("MilliSeconds")]
    MilliSecond = -3,

    [UnitAbbreviation("cs")]
    [Scale(1e-2)]
    CentiSecond = -2,

    [UnitAbbreviation("ds")]
    [Scale(1e-1)]
    DeciSecond = -1,

    [UnitAbbreviation("s")]
    [Scale(1.0)]
    [Extension("Seconds")]
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
    [Extension("Minutes")]
    Minutes = 110,

    [UnitAbbreviation("h")]
    [Scale(3600.0)]
    [Extension("Hours")]
    Hours = 111,

    [UnitAbbreviation("d")]
    [Scale(86400.0)]
    [Extension("Days")]
    Days = 112,

    [UnitAbbreviation("week")]
    [Scale(604800)]
    [Extension("Weeks")]
    Weeks = 113,

    [UnitAbbreviation("month")]
    [Scale(2629746)]
    [Extension("Months")]
    Months = 114,

    [UnitAbbreviation("year")]
    [Scale(3.154e+7)]
    [Extension("Years")]
    Years = 115,

    BaseUnit = Second

}