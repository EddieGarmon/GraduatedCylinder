using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum MassFlowRateUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = KilogramsPerSecond,

        [UnitAbbreviation("kg/s")]
        [Scale(1.0f)]
        KilogramsPerSecond = 0,

        [UnitAbbreviation("g/s")]
        [Scale(1e-3f)]
        GramsPerSecond = 1,

        [UnitAbbreviation("kg/min")]
        [Scale(1.0f / 60.0f)]
        KilogramsPerMinute = 2,

        [UnitAbbreviation("kg/h")]
        [Scale(1.0f / 3600.0f)]
        KilogramsPerHour = 3,

        [UnitAbbreviation("lbs/s")]
        [Scale(0.45359237f)]
        PoundsPerSecond = 4

    }
}