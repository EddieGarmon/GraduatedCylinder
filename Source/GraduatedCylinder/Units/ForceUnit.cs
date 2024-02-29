using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Force))]
public enum ForceUnit : short
{

    Unspecified = short.MinValue,

    [BaseUnit]
    [UnitAbbreviation("N")]
    [Scale(1.0)]
    [Extension("Newtons")]
    Newtons = 0,

    [UnitAbbreviation("lbf")]
    [Scale(4.44822)]
    [Extension("PoundForce")]
    PoundForce = 1,

    [UnitAbbreviation("kgf")]
    [Scale(9.81)]
    KiloGramForce = 2

}