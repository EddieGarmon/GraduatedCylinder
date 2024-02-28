using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Torque))]
public enum TorqueUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("Nm")]
    [Scale(1.0)]
    NewtonMeters = 0,

    [UnitAbbreviation("kgf-m")]
    [Scale(9.81)]
    KiloGramForceMeters = 1,

    [UnitAbbreviation("ft-lbs")]
    [Scale(1.35581795)]
    FootPounds = 2,

    BaseUnit = NewtonMeters

}