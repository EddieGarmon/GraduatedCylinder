using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum PressureUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Pascals,

    [UnitAbbreviation("Pa")]
    [Scale(1.0)]
    Pascals = 0,

    [UnitAbbreviation("MPa")]
    [Scale(1e6)]
    MegaPascals = 1,

    [UnitAbbreviation("N/m²")]
    [Scale(1.0)]
    NewtonsPerSquareMeter = 2,

    [UnitAbbreviation("in Hg")]
    [Scale(3386)]
    InchesOfMercury = 3,

    [UnitAbbreviation("kgf/m²")]
    [Scale(9.80665)]
    KilogramForcePerSquareMeter = 4,

    [UnitAbbreviation("kPa")]
    [Scale(1e3)]
    KiloPascals = 5,

    [UnitAbbreviation("mBar")]
    [Scale(1e2)]
    MilliBars = 6,

    [UnitAbbreviation("bar")]
    [Scale(1e5)]
    Bars = 7,

    [UnitAbbreviation("psi")]
    [Scale(6894.76)]
    PoundsPerSquareInch = 8

}