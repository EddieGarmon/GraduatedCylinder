using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

//todo:
public enum ElectricChargeUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = Coulomb,

    [UnitAbbreviation("mC")]
    [Scale(0.001)]
    Millicoulomb = -3,

    [UnitAbbreviation("C")]
    [Scale(1.0)]
    Coulomb = 0,

    [UnitAbbreviation("kC")]
    [Scale(1000)]
    Kilocoulomb = 3,

    [UnitAbbreviation("MC")]
    [Scale(1E6)]
    Megacoulomb = 6,

    [UnitAbbreviation("As")]
    [Scale(1.0)]
    AmpereSecond = -100,

    [UnitAbbreviation("mAh")]
    [Scale(3.6)]
    MilliampereHour,

    [UnitAbbreviation("Ah")]
    [Scale(3600)]
    AmpereHour,

}