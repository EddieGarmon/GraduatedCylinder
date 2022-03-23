using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AreaUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = SquareMeter,

    [UnitAbbreviation("ym�")]
    [Scale(1e-48)]
    SquareYoctoMeter = -48,

    [UnitAbbreviation("zm�")]
    [Scale(1e-42)]
    SquareZeptoMeter = -42,

    [UnitAbbreviation("am�")]
    [Scale(1e-36)]
    SquareAttoMeter = -36,

    [UnitAbbreviation("fm�")]
    [Scale(1e-30)]
    SquareFemtoMeter = -30,

    [UnitAbbreviation("pm�")]
    [Scale(1e-24)]
    SquarePicoMeter = -24,

    [UnitAbbreviation("nm�")]
    [Scale(1e-18)]
    SquareNanoMeter = -18,

    [UnitAbbreviation("�m�")]
    [Scale(1e-12)]
    SquareMicroMeter = -12,

    [UnitAbbreviation("mm�")]
    [Scale(1e-6)]
    SquareMilliMeter = -6,

    [UnitAbbreviation("cm�")]
    [Scale(1e-4)]
    SquareCentiMeter = -4,

    [UnitAbbreviation("dm�")]
    [Scale(1e-2)]
    SquareDeciMeter = -2,

    [UnitAbbreviation("m�")]
    [Scale(1.0)]
    SquareMeter = 0,

    [UnitAbbreviation("dam�")]
    [Scale(1e2)]
    SquareDekaMeter = 2,

    [UnitAbbreviation("hm�")]
    [Scale(1e4)]
    SquareHectoMeter = 4,

    [UnitAbbreviation("km�")]
    [Scale(1e6)]
    SquareKiloMeter = 6,

    [UnitAbbreviation("Mm�")]
    [Scale(1e12)]
    SquareMegaMeter = 12,

    [UnitAbbreviation("Gm�")]
    [Scale(1e18)]
    SquareGigaMeter = 18,

    [UnitAbbreviation("Tm�")]
    [Scale(1e24)]
    SquareTeraMeter = 24,

    [UnitAbbreviation("Pm�")]
    [Scale(1e30)]
    SquarePetaMeter = 30,

    [UnitAbbreviation("Em�")]
    [Scale(1e36)]
    SquareExaMeter = 36,

    [UnitAbbreviation("Zm�")]
    [Scale(1e42)]
    SquareZettaMeter = 42,

    [UnitAbbreviation("Ym�")]
    [Scale(1e48)]
    SquareYottaMeter = 48,

    [UnitAbbreviation("in�")]
    [Scale(0.00064516)]
    SquareInch = 101,

    [UnitAbbreviation("ft�")]
    [Scale(0.09290304)]
    SquareFoot = 102,

    [UnitAbbreviation("yd�")]
    [Scale(0.83612736)]
    SquareYard = 103,

    [UnitAbbreviation("ac")]
    [Scale(4046.8564224)]
    Acres = 104,

    [UnitAbbreviation("mi�")]
    [Scale(2589988.110336)]
    SquareMiles = 105

}