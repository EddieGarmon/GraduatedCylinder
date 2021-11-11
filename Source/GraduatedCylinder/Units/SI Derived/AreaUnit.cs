using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AreaUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = SquareMeter,

    [UnitAbbreviation("ym²")]
    [Scale(1e-48)]
    SquareYoctometer = -48,

    [UnitAbbreviation("zm²")]
    [Scale(1e-42)]
    SquareZeptometer = -42,

    [UnitAbbreviation("am²")]
    [Scale(1e-36)]
    SquareAttometer = -36,

    [UnitAbbreviation("fm²")]
    [Scale(1e-30)]
    SquareFemtometer = -30,

    [UnitAbbreviation("pm²")]
    [Scale(1e-24)]
    SquarePicometer = -24,

    [UnitAbbreviation("nm²")]
    [Scale(1e-18)]
    SquareNanometer = -18,

    [UnitAbbreviation("µm²")]
    [Scale(1e-12)]
    SquareMicrometer = -12,

    [UnitAbbreviation("mm²")]
    [Scale(1e-6)]
    SquareMillimeter = -6,

    [UnitAbbreviation("cm²")]
    [Scale(1e-4)]
    SquareCentimeter = -4,

    [UnitAbbreviation("dm²")]
    [Scale(1e-2)]
    SquareDecimeter = -2,

    [UnitAbbreviation("m²")]
    [Scale(1.0)]
    SquareMeter = 0,

    [UnitAbbreviation("dam²")]
    [Scale(1e2)]
    SquareDekameter = 2,

    [UnitAbbreviation("hm²")]
    [Scale(1e4)]
    SquareHectometer = 4,

    [UnitAbbreviation("km²")]
    [Scale(1e6)]
    SquareKilometer = 6,

    [UnitAbbreviation("Mm²")]
    [Scale(1e12)]
    SquareMegameter = 12,

    [UnitAbbreviation("Gm²")]
    [Scale(1e18)]
    SquareGigameter = 18,

    [UnitAbbreviation("Tm²")]
    [Scale(1e24)]
    SquareTerameter = 24,

    [UnitAbbreviation("Pm²")]
    [Scale(1e30)]
    SquarePetameter = 30,

    [UnitAbbreviation("Em²")]
    [Scale(1e36)]
    SquareExameter = 36,

    [UnitAbbreviation("Zm²")]
    [Scale(1e42)]
    SquareZettameter = 42,

    [UnitAbbreviation("Ym²")]
    [Scale(1e48)]
    SquareYottameter = 48,

    [UnitAbbreviation("in²")]
    [Scale(0.00064516)]
    SquareInch = 101,

    [UnitAbbreviation("ft²")]
    [Scale(0.09290304)]
    SquareFoot = 102,

    [UnitAbbreviation("yd²")]
    [Scale(0.83612736)]
    SquareYard = 103,

    [UnitAbbreviation("ac")]
    [Scale(4046.8564224)]
    Acres = 104,

    [UnitAbbreviation("mi²")]
    [Scale(2589988.110336)]
    SquareMiles = 105

}