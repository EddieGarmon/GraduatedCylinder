using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum ElectricPotentialUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Volt,

    [UnitAbbreviation("yV")]
    [Scale(1e-24)]
    Yoctovolt = -24,

    [UnitAbbreviation("zV")]
    [Scale(1e-21)]
    Zeptovolt = -21,

    [UnitAbbreviation("aV")]
    [Scale(1e-18)]
    Attovolt = -18,

    [UnitAbbreviation("fV")]
    [Scale(1e-15)]
    Femtovolt = -15,

    [UnitAbbreviation("pV")]
    [Scale(1e-12)]
    Picovolt = -12,

    [UnitAbbreviation("nV")]
    [Scale(1e-9)]
    Nanovolt = -9,

    [UnitAbbreviation("µV")]
    [Scale(1e-6)]
    Microvolt = -6,

    [UnitAbbreviation("mV")]
    [Scale(1e-3)]
    Millivolt = -3,

    [UnitAbbreviation("cV")]
    [Scale(1e-2)]
    Centivolt = -2,

    [UnitAbbreviation("dV")]
    [Scale(1e-1)]
    Decivolt = -1,

    [UnitAbbreviation("V")]
    [Scale(1.0)]
    Volt = 0,

    [UnitAbbreviation("daV")]
    [Scale(10)]
    Dekavolt = 1,

    [UnitAbbreviation("hV")]
    [Scale(1e2)]
    Hectovolt = 2,

    [UnitAbbreviation("kV")]
    [Scale(1e3)]
    Kilovolt = 3,

    [UnitAbbreviation("MV")]
    [Scale(1e6)]
    Megavolt = 6,

    [UnitAbbreviation("GV")]
    [Scale(1e9)]
    Gigavolt = 9,

    [UnitAbbreviation("TV")]
    [Scale(1e12)]
    Teravolt = 12,

    [UnitAbbreviation("PV")]
    [Scale(1e15)]
    Petavolt = 15,

    [UnitAbbreviation("EV")]
    [Scale(1e18)]
    Exavolt = 18,

    [UnitAbbreviation("ZV")]
    [Scale(1e21)]
    Zettavolt = 21,

    [UnitAbbreviation("YV")]
    [Scale(1e24)]
    Yottavolt = 24

}