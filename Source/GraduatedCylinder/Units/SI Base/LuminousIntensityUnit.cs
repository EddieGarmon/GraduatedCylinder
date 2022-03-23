using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum LuminousIntensityUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Candela,

    [UnitAbbreviation("ycd")]
    [Scale(1e-24)]
    YoctoCandela = -24,

    [UnitAbbreviation("zcd")]
    [Scale(1e-21)]
    ZeptoCandela = -21,

    [UnitAbbreviation("acd")]
    [Scale(1e-18)]
    AttoCandela = -18,

    [UnitAbbreviation("fcd")]
    [Scale(1e-15)]
    FemtoCandela = -15,

    [UnitAbbreviation("pcd")]
    [Scale(1e-12)]
    PicoCandela = -12,

    [UnitAbbreviation("ncd")]
    [Scale(1e-9)]
    NanoCandela = -9,

    [UnitAbbreviation("µcd")]
    [Scale(1e-6)]
    MicroCandela = -6,

    [UnitAbbreviation("mcd")]
    [Scale(1e-3)]
    MilliCandela = -3,

    [UnitAbbreviation("ccd")]
    [Scale(1e-2)]
    CentiCandela = -2,

    [UnitAbbreviation("dcd")]
    [Scale(1e-1)]
    DeciCandela = -1,

    [UnitAbbreviation("cd")]
    [Scale(1.0)]
    Candela = 0,

    [UnitAbbreviation("dacd")]
    [Scale(10)]
    DekaCandela = 1,

    [UnitAbbreviation("hcd")]
    [Scale(1e2)]
    HectoCandela = 2,

    [UnitAbbreviation("kcd")]
    [Scale(1e3)]
    KiloCandela = 3,

    [UnitAbbreviation("Mcd")]
    [Scale(1e6)]
    MegaCandela = 6,

    [UnitAbbreviation("Gcd")]
    [Scale(1e9)]
    GigaCandela = 9,

    [UnitAbbreviation("Tcd")]
    [Scale(1e12)]
    TeraCandela = 12,

    [UnitAbbreviation("Pcd")]
    [Scale(1e15)]
    PetaCandela = 15,

    [UnitAbbreviation("Ecd")]
    [Scale(1e18)]
    ExaCandela = 18,

    [UnitAbbreviation("Zcd")]
    [Scale(1e21)]
    ZettaCandela = 21,

    [UnitAbbreviation("Ycd")]
    [Scale(1e24)]
    YottaCandela = 24

}