using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(MassDensity))]
public enum MassDensityUnit : short
{

    Unspecified = short.MinValue,

    [BaseUnit]
    [UnitAbbreviation("kg/m�")]
    [Scale(1.0)]
    KiloGramsPerCubicMeter = 0,

    [UnitAbbreviation("kg/l")]
    [Scale(1000)]
    KiloGramsPerLiter = 1,

    [UnitAbbreviation("g/l")]
    [Scale(1.0)]
    GramsPerLiter = -100,

    [UnitAbbreviation("g/ml")]
    [Scale(1000)]
    GramsPerMilliLiter = 3,

    [UnitAbbreviation("g/cm�")]
    [Scale(1000)]
    GramsPerCubicCentiMeter = 4,

    [UnitAbbreviation("lb/ft�")]
    [Scale(16.018463)]
    PoundsPerCubicFoot = 5,

    [UnitAbbreviation("lb/in�")]
    [Scale(27679.90)]
    PoundsPerCubicInch = 6

}