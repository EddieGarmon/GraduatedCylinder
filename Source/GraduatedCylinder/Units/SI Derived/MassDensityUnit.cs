using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum MassDensityUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = KilogramsPerCubicMeter,

        [UnitAbbreviation("kg/m³")]
        [Scale(1.0f)]
        KilogramsPerCubicMeter = 0,

        [UnitAbbreviation("kg/l")]
        [Scale(1000f)]
        KilogramsPerLiter = 1,

        [UnitAbbreviation("g/l")]
        [Scale(1.0f)]
        GramsPerLiter = 2,

        [UnitAbbreviation("g/ml")]
        [Scale(1000f)]
        GramsPerMilliliter = 3,

        [UnitAbbreviation("g/cm³")]
        [Scale(1000f)]
        GramsPerCubicCentimeter = 4,

        [UnitAbbreviation("lb/ft³")]
        [Scale(16.018463f)]
        PoundsPerCubicFeet = 5

    }
}