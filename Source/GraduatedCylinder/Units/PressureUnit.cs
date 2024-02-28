using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Pressure))]
public enum PressureUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("Pa")]
    [Scale(1.0)]
    Pascals = 0,

    [UnitAbbreviation("mBar")]
    [Scale(1e2)]
    MilliBars = 2,

    [UnitAbbreviation("kPa")]
    [Scale(1e3)]
    [Extension("KiloPascals")]
    KiloPascals = 3,

    [UnitAbbreviation("bar")]
    [Scale(1e5)]
    [Extension("Bars")]
    Bars = 5,

    [UnitAbbreviation("MPa")]
    [Scale(1e6)]
    MegaPascals = 6,

    [UnitAbbreviation("N/m²")]
    [Scale(1.0)]
    NewtonsPerSquareMeter = -100,

    [UnitAbbreviation("in Hg")]
    [Scale(3386)]
    InchesOfMercury = 100,

    [UnitAbbreviation("kgf/m²")]
    [Scale(9.80665)]
    KiloGramForcePerSquareMeter = 101,

    [UnitAbbreviation("psi")]
    [Scale(6894.76)]
    [Extension("PoundsPerSquareInch")]
    PoundsPerSquareInch = 102,

    BaseUnit = Pascals

}