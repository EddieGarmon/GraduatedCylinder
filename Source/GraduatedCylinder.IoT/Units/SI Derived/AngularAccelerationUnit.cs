using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AngularAccelerationUnit : short
    {

        Unspecified = short.MinValue,

        //todo: convert to rad/s^2 as the base
        BaseUnit = RadiansPerSecondSquared,

        [UnitAbbreviation("rad/s^2")]
        [Scale(1.0f)]
        RadiansPerSecondSquared = 0,

        [UnitAbbreviation("rad/min^2")]
        [Scale(3600.0f)]
        RadiansPerMinuteSquared,

        [UnitAbbreviation("rev/s^2")]
        [Scale(0.1591549431f)]
        RevolutionsPerSecondSquared,

        [UnitAbbreviation("rev/min/s")]
        [Scale(9.549296586f)]
        RevolutionsPerMinutePerSecond,

    }
}