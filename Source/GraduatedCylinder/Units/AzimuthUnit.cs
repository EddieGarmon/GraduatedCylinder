using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(Azimuth))]
public enum AzimuthUnit : short
{

    Unspecified = short.MinValue,

    [BaseUnit]
    [UnitAbbreviation("°")]
    [Scale(1.0)]
    Degree = 0

}