using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Extensions;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum ElectricPotentialUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Volt,

    [UnitAbbreviation("yV")]
    [Scale(1e-24)]
    YoctoVolt = -24,

    [UnitAbbreviation("zV")]
    [Scale(1e-21)]
    ZeptoVolt = -21,

    [UnitAbbreviation("aV")]
    [Scale(1e-18)]
    AttoVolt = -18,

    [UnitAbbreviation("fV")]
    [Scale(1e-15)]
    FemtoVolt = -15,

    [UnitAbbreviation("pV")]
    [Scale(1e-12)]
    PicoVolt = -12,

    [UnitAbbreviation("nV")]
    [Scale(1e-9)]
    NanoVolt = -9,

    [UnitAbbreviation("µV")]
    [Scale(1e-6)]
    MicroVolt = -6,

    [UnitAbbreviation("mV")]
    [Scale(1e-3)]
    MilliVolt = -3,

    [UnitAbbreviation("cV")]
    [Scale(1e-2)]
    CentiVolt = -2,

    [UnitAbbreviation("dV")]
    [Scale(1e-1)]
    DeciVolt = -1,

    [UnitAbbreviation("V")]
    [Scale(1.0)]
    [Extension("Volts")]
    Volt = 0,

    [UnitAbbreviation("daV")]
    [Scale(10)]
    DekaVolt = 1,

    [UnitAbbreviation("hV")]
    [Scale(1e2)]
    HectoVolt = 2,

    [UnitAbbreviation("kV")]
    [Scale(1e3)]
    KiloVolt = 3,

    [UnitAbbreviation("MV")]
    [Scale(1e6)]
    MegaVolt = 6,

    [UnitAbbreviation("GV")]
    [Scale(1e9)]
    GigaVolt = 9,

    [UnitAbbreviation("TV")]
    [Scale(1e12)]
    TeraVolt = 12,

    [UnitAbbreviation("PV")]
    [Scale(1e15)]
    PetaVolt = 15,

    [UnitAbbreviation("EV")]
    [Scale(1e18)]
    ExaVolt = 18,

    [UnitAbbreviation("ZV")]
    [Scale(1e21)]
    ZettaVolt = 21,

    [UnitAbbreviation("YV")]
    [Scale(1e24)]
    YottaVolt = 24

}