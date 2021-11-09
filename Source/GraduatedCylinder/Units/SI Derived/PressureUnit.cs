using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum PressureUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = Pascals,

        [UnitAbbreviation("Pa")]
        [Scale(1.0f)]
        Pascals = 0,

        [UnitAbbreviation("MPa")]
        [Scale(1e6f)]
        MegaPascals = 1,

        [UnitAbbreviation("N/m²")]
        [Scale(1.0f)]
        NewtonsPerSquareMeter = 2,

        [UnitAbbreviation("in Hg")]
        [Scale(3386f)]
        InchesOfMercury = 3,

        [UnitAbbreviation("kgf/m²")]
        [Scale(9.80665f)]
        KilogramForcePerSquareMeter = 4,

        [UnitAbbreviation("kPa")]
        [Scale(1e3f)]
        KiloPascals = 5,

        [UnitAbbreviation("mBar")]
        [Scale(1e2f)]
        MilliBars = 6,

        [UnitAbbreviation("bar")]
        [Scale(1e5f)]
        Bars = 7,

        [UnitAbbreviation("psi")]
        [Scale(6894.76f)]
        PoundsPerSquareInch = 8

    }
}