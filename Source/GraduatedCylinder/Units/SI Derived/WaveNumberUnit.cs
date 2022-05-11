using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum WaveNumberUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = ReciprocalMeter,

    [UnitAbbreviation("1/cm")]
    [Scale(1e-2)]
    ReciprocalCentiMeter=-2,

    [UnitAbbreviation("1/m")]
    [Scale(1.0)]
    ReciprocalMeter = 0,

    [UnitAbbreviation("1/km")]
    [Scale(1e3)]
    ReciprocalKiloMeter = 3,

}