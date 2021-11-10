using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum LuminousIntensityUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Candela,

    [UnitAbbreviation("ycd")]
    [Scale(1e-24)]
    Yoctocandela = -24,

    [UnitAbbreviation("zcd")]
    [Scale(1e-21)]
    Zeptocandela = -21,

    [UnitAbbreviation("acd")]
    [Scale(1e-18)]
    Attocandela = -18,

    [UnitAbbreviation("fcd")]
    [Scale(1e-15)]
    Femtocandela = -15,

    [UnitAbbreviation("pcd")]
    [Scale(1e-12)]
    Picocandela = -12,

    [UnitAbbreviation("ncd")]
    [Scale(1e-9)]
    Nanocandela = -9,

    [UnitAbbreviation("µcd")]
    [Scale(1e-6)]
    Microcandela = -6,

    [UnitAbbreviation("mcd")]
    [Scale(1e-3)]
    Millicandela = -3,

    [UnitAbbreviation("ccd")]
    [Scale(1e-2)]
    Centicandela = -2,

    [UnitAbbreviation("dcd")]
    [Scale(1e-1)]
    Decicandela = -1,

    [UnitAbbreviation("cd")]
    [Scale(1.0)]
    Candela = 0,

    [UnitAbbreviation("dacd")]
    [Scale(10)]
    Dekacandela = 1,

    [UnitAbbreviation("hcd")]
    [Scale(1e2)]
    Hectocandela = 2,

    [UnitAbbreviation("kcd")]
    [Scale(1e3)]
    Kilocandela = 3,

    [UnitAbbreviation("Mcd")]
    [Scale(1e6)]
    Megacandela = 6,

    [UnitAbbreviation("Gcd")]
    [Scale(1e9)]
    Gigacandela = 9,

    [UnitAbbreviation("Tcd")]
    [Scale(1e12)]
    Teracandela = 12,

    [UnitAbbreviation("Pcd")]
    [Scale(1e15)]
    Petacandela = 15,

    [UnitAbbreviation("Ecd")]
    [Scale(1e18)]
    Exacandela = 18,

    [UnitAbbreviation("Zcd")]
    [Scale(1e21)]
    Zetacandela = 21,

    [UnitAbbreviation("Ycd")]
    [Scale(1e24)]
    Yottacandela = 24

}