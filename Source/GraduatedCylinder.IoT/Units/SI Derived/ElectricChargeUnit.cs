using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    //todo:
   public enum ElectricChargeUnit:short
    {
        Unspecified = short.MinValue,

        BaseUnit = Coulomb,

        [UnitAbbreviation("C")]
        [Scale(1.0f)]
        Coulomb = 0,
        AmpereSecond = 0,

        [UnitAbbreviation("mAh")]
        [Scale(3.6f)]
        MilliAmpereHour,

        [UnitAbbreviation("Ah")]
        [Scale(3600f)]
        AmpereHour,

    }
}