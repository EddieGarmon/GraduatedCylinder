using CodeGeneration.Attributes;

#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

[UnitsFor(typeof(WaveNumber))]
public enum WaveNumberUnit : short
{

    Unspecified = short.MinValue,

    [UnitAbbreviation("1/cm")]
    [Scale(1e-2)]
    ReciprocalCentiMeter = -2,

    [BaseUnit]
    [UnitAbbreviation("1/m")]
    [Scale(1.0)]
    ReciprocalMeter = 0,

    [UnitAbbreviation("1/km")]
    [Scale(1e3)]
    ReciprocalKiloMeter = 3

}