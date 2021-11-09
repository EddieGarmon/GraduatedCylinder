using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum VolumetricFlowRateUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = LitersPerSecond,

        [UnitAbbreviation("L/s")]
        [Scale(1.0f)]
        LitersPerSecond = 0,

        [UnitAbbreviation("L/min")]
        [Scale(1.0f / 60.0f)]
        LitersPerMinute = 1,

        [UnitAbbreviation("L/h")]
        [Scale(1.0f / 3600.0f)]
        LitersPerHour = 2,

        [UnitAbbreviation("m³/s")]
        [Scale(1e3f)]
        CubicMetersPerSecond = 3,

        [UnitAbbreviation("gal/s")]
        [Scale(3.785411784f)]
        GallonsUsPerSecond = 4,

        [UnitAbbreviation("gal/h")]
        [Scale(3.785411784f / 3600.0f)]
        GallonsUsPerHour = 5

    }
}