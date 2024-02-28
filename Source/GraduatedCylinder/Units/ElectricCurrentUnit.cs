using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(ElectricCurrent))]
public enum ElectricCurrentUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("yA")]
    [Scale(1e-24)]
    YoctoAmpere = -24,

    [UnitAbbreviation("zA")]
    [Scale(1e-21)]
    ZeptoAmpere = -21,

    [UnitAbbreviation("aA")]
    [Scale(1e-18)]
    AttoAmpere = -18,

    [UnitAbbreviation("fA")]
    [Scale(1e-15)]
    FemtoAmpere = -15,

    [UnitAbbreviation("pA")]
    [Scale(1e-12)]
    PicoAmpere = -12,

    [UnitAbbreviation("nA")]
    [Scale(1e-9)]
    NanoAmpere = -9,

    [UnitAbbreviation("µA")]
    [Scale(1e-6)]
    MicroAmpere = -6,

    [UnitAbbreviation("mA")]
    [Scale(1e-3)]
    [Extension("MilliAmps")]
    MilliAmpere = -3,

    [UnitAbbreviation("cA")]
    [Scale(1e-2)]
    CentiAmpere = -2,

    [UnitAbbreviation("dA")]
    [Scale(1e-1)]
    DeciAmpere = -1,

    [UnitAbbreviation("A")]
    [Scale(1.0)]
    [Extension("Amps")]
    Ampere = 0,

    [UnitAbbreviation("daA")]
    [Scale(10)]
    DekaAmpere = 1,

    [UnitAbbreviation("hA")]
    [Scale(100)]
    HectoAmpere = 2,

    [UnitAbbreviation("kA")]
    [Scale(1e3)]
    KiloAmpere = 3,

    [UnitAbbreviation("MA")]
    [Scale(1e6)]
    MegaAmpere = 6,

    [UnitAbbreviation("GA")]
    [Scale(1e9)]
    GigaAmpere = 9,

    [UnitAbbreviation("TA")]
    [Scale(1e12)]
    TeraAmpere = 12,

    [UnitAbbreviation("PA")]
    [Scale(1e15)]
    PetaAmpere = 15,

    [UnitAbbreviation("EA")]
    [Scale(1e18)]
    ExaAmpere = 18,

    [UnitAbbreviation("ZA")]
    [Scale(1e21)]
    ZettaAmpere = 21,

    [UnitAbbreviation("YA")]
    [Scale(1e24)]
    YottaAmpere = 24,

    BaseUnit = Ampere

}