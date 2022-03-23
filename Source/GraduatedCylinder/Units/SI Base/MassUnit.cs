using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum MassUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = KiloGram,

    [UnitAbbreviation("yg")]
    [Scale(1e-27)]
    YoctoGram = -24,

    [UnitAbbreviation("zg")]
    [Scale(1e-24)]
    ZeptoGram = -21,

    [UnitAbbreviation("ag")]
    [Scale(1e-21)]
    AttoGram = -18,

    [UnitAbbreviation("fg")]
    [Scale(1e-18)]
    FemtoGram = -15,

    [UnitAbbreviation("pg")]
    [Scale(1e-15)]
    PicoGram = -12,

    [UnitAbbreviation("ng")]
    [Scale(1e-12)]
    NanoGram = -9,

    [UnitAbbreviation("µg")]
    [Scale(1e-9)]
    MicroGram = -6,

    [UnitAbbreviation("mg")]
    [Scale(1e-6)]
    MilliGram = -3,

    [UnitAbbreviation("cg")]
    [Scale(1e-5)]
    CentiGram = -2,

    [UnitAbbreviation("dg")]
    [Scale(1e-4)]
    DeciGram = -1,

    [UnitAbbreviation("g")]
    [Scale(1e-3)]
    Gram = 0,

    [UnitAbbreviation("dag")]
    [Scale(1e-2)]
    DekaGram = 1,

    [UnitAbbreviation("hg")]
    [Scale(1e-1)]
    HectoGram = 2,

    [UnitAbbreviation("kg")]
    [Scale(1.0)]
    KiloGram = 3,

    [UnitAbbreviation("Mg")]
    [Scale(1e3)]
    MegaGram = 6,

    [UnitAbbreviation("Gg")]
    [Scale(1e6)]
    GigaGram = 9,

    [UnitAbbreviation("Tg")]
    [Scale(1e9)]
    TeraGram = 12,

    [UnitAbbreviation("Pg")]
    [Scale(1e12)]
    PetaGram = 15,

    [UnitAbbreviation("Eg")]
    [Scale(1e15)]
    ExaGram = 18,

    [UnitAbbreviation("Zg")]
    [Scale(1e18)]
    ZettaGram = 21,

    [UnitAbbreviation("Yg")]
    [Scale(1e21)]
    YottaGram = 24,

    [UnitAbbreviation("CD")]
    [Scale(0.0002)]
    Carats = 101,

    [UnitAbbreviation("ozt")]
    [Scale(0.0311034768)]
    OuncesTroy = 102,

    [UnitAbbreviation("lbs")]
    [Scale(0.45359237)]
    Pounds = 103,

    [UnitAbbreviation("T")]
    [Scale(907.18474)]
    TonsUS = 104,

    [UnitAbbreviation("t")]
    [Scale(1016.0469088)]
    TonsUK = 105

}