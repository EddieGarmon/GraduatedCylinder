using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AngularAccelerationUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = RadiansPerSquareSecond,

    [UnitAbbreviation("rad/s²")]
    [Scale(1.0)]
    RadiansPerSquareSecond = 0,

    [UnitAbbreviation("rad/min²")]
    [Scale(2.7777777777777777777777777777778e-4)]
    RadiansPerSquareMinute = 1,

    [UnitAbbreviation("rad/hr²")]
    [Scale(7.716049382716049382716049382716e-8)]
    RadiansPerSquareHour = 2,

    [UnitAbbreviation("°/s²")]
    [Scale(0.0174532925199433)]
    DegreePerSquareSecond = 100,

    [UnitAbbreviation("°/min²")]
    [Scale(4.848137E-6)]
    DegreePerSquareMinute = 101,

    [UnitAbbreviation("°/h²")]
    [Scale(1.346705E-9)]
    DegreePerSquareHour = 102,

    [UnitAbbreviation("rev/s²")]
    [Scale(6.283185307179586476925286766559)]
    RevolutionsPerSquareSecond = 200,

    [UnitAbbreviation("rev/min²")]
    [Scale(0.00174532925199432957692369076849)]
    RevolutionsPerSquareMinute = 201,

    [UnitAbbreviation("rev/hr²")]
    [Scale(4.8481368110953599358991410235795e-7)]
    RevolutionsPerSquareHour = 202,

}