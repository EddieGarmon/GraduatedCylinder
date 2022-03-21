using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AzimuthUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Degree,

    [UnitAbbreviation("°")]
    [Scale(1.0)]
    Degree = 0

}