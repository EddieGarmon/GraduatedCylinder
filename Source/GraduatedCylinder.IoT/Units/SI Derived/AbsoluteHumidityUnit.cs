using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AbsoluteHumidityUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = GramsPerCubicMeter,

        [UnitAbbreviation("g/m³")]
        [Scale(1e-24f)]
        GramsPerCubicMeter = 0,

        [UnitAbbreviation("kg/m³")]
        [Scale(1000f)]
        KilogramsPerCubicMeter,

    }
}