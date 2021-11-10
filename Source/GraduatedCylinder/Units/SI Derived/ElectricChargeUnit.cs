using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

//todo:
public enum ElectricChargeUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Coulomb,

    [UnitAbbreviation("C")]
    [Scale(1.0)]
    Coulomb = 0,

    [UnitAbbreviation("As")]
    [Scale(1.0)]
    AmpereSecond = 1,

    [UnitAbbreviation("mAh")]
    [Scale(3.6)]
    MilliAmpereHour,

    [UnitAbbreviation("Ah")]
    [Scale(3600)]
    AmpereHour,

}