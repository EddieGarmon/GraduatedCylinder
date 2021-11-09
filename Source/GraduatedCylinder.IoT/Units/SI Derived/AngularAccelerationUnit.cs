using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AngularAccelerationUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = RadiansPerSecondSquared,

        [UnitAbbreviation("rad/s�")]
        [Scale(1.0f)]
        RadiansPerSecondSquared = 0,

        [UnitAbbreviation("rad/min�")]
        [Scale(0.00028f)]
        RadiansPerMinuteSquared = 1,

        [UnitAbbreviation("rev/s�")]
        [Scale(6.33345f)]
        RevolutionsPerSecondSquared = 100,

        [UnitAbbreviation("rev/min/s")]
        [Scale(0.10556f)]
        RevolutionsPerMinutePerSecond = 101,

        [UnitAbbreviation("rev/min�")]
        [Scale(0.00176f)]
        RevolutionsPerSquareMinute = 102

    }
}