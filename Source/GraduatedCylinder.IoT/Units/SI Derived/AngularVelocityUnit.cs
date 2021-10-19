using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AngularVelocityUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnits = RadiansPerSecond,

        [UnitAbbreviation("rad/s")]
        [Scale(1.0f)]
        RadiansPerSecond = 0,

        [UnitAbbreviation("rad/min")]
        [Scale(60.0f)]
        RadiansPerMinute,

        [UnitAbbreviation("°/s")]
        [Scale(57.2958f)]
        DegreesPerSecond,

        [UnitAbbreviation("°/min")]
        [Scale(3437.75f)]
        DegreesPerMinute,

        [UnitAbbreviation("rps")]
        [Scale(0.159155f)]
        RevolutionsPerSecond,

        [UnitAbbreviation("rpm")]
        [Scale(9.5493f)]
        RevolutionsPerMinute,

    }
}