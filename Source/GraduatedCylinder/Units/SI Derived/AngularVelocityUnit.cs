using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AngularVelocityUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = RadiansPerSecond,

    [UnitAbbreviation("rad/s")]
    [Scale(1.0)]
    RadiansPerSecond = 0,

    [UnitAbbreviation("rad/min")]
    [Scale(60.0)]
    RadiansPerMinute,

    [UnitAbbreviation("°/s")]
    [Scale(57.2958)]
    DegreesPerSecond,

    [UnitAbbreviation("°/min")]
    [Scale(3437.75)]
    DegreesPerMinute,

    [UnitAbbreviation("rps")]
    [Scale(0.159155)]
    RevolutionsPerSecond,

    [UnitAbbreviation("rpm")]
    [Scale(9.5493)]
    RevolutionsPerMinute,

}