using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AbsoluteHumidityUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = GramsPerCubicMeter,

        [UnitAbbreviation("g/m^3")]
        [Scale(1e-24f)]
        GramsPerCubicMeter = 0,

        [UnitAbbreviation("kg/m^3")]
        [Scale(1000f)]
        KilogramsPerCubicMeter,

    }
}