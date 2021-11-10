using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AngularAccelerationUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = RadiansPerSquareSecond,

    [UnitAbbreviation("rad/s�")]
    [Scale(1.0)]
    RadiansPerSquareSecond = 0,

    [UnitAbbreviation("rad/min�")]
    [Scale(2.7777777777777777777777777777778e-4)]
    RadiansPerSquareMinute = 1,

    [UnitAbbreviation("rad/hr�")]
    [Scale(7.716049382716049382716049382716e-8)]
    RadiansPerSquareHour = 2,

    [UnitAbbreviation("rev/s�")]
    [Scale(6.283185307179586476925286766559)]
    RevolutionsPerSquareSecond = 100,

    [UnitAbbreviation("rev/min�")]
    [Scale(0.00174532925199432957692369076849)]
    RevolutionsPerSquareMinute = 101,

    [UnitAbbreviation("rev/hr�")]
    [Scale(4.8481368110953599358991410235795e-7)]
    RevolutionsPerSquareHour = 102,

}