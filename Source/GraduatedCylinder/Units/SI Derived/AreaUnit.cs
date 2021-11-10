using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum AreaUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = MeterSquared,

    [UnitAbbreviation("ym²")]
    [Scale(1e-48)]
    YoctometerSquared = -24,

    [UnitAbbreviation("zm²")]
    [Scale(1e-42)]
    ZeptometerSquared = -21,

    [UnitAbbreviation("am²")]
    [Scale(1e-36)]
    AttometerSquared = -18,

    [UnitAbbreviation("fm²")]
    [Scale(1e-30)]
    FemtometerSquared = -15,

    [UnitAbbreviation("pm²")]
    [Scale(1e-24)]
    PicometerSquared = -12,

    [UnitAbbreviation("nm²")]
    [Scale(1e-18)]
    NanometerSquared = -9,

    [UnitAbbreviation("µm²")]
    [Scale(1e-12)]
    MicrometerSquared = -6,

    [UnitAbbreviation("mm²")]
    [Scale(1e-6)]
    MillimeterSquared = -3,

    [UnitAbbreviation("cm²")]
    [Scale(1e-4)]
    CentimeterSquared = -2,

    [UnitAbbreviation("dm²")]
    [Scale(1e-2)]
    DecimeterSquared = -1,

    [UnitAbbreviation("m²")]
    [Scale(1.0)]
    MeterSquared = 0,

    [UnitAbbreviation("dam²")]
    [Scale(1e2)]
    DekameterSquared = 1,

    [UnitAbbreviation("hm²")]
    [Scale(1e4)]
    HectometerSquared = 2,

    [UnitAbbreviation("km²")]
    [Scale(1e6)]
    KilometerSquared = 3,

    [UnitAbbreviation("Mm²")]
    [Scale(1e12)]
    MegameterSquared = 6,

    [UnitAbbreviation("Gm²")]
    [Scale(1e18)]
    GigameterSquared = 9,

    [UnitAbbreviation("Tm²")]
    [Scale(1e24)]
    TerameterSquared = 12,

    [UnitAbbreviation("Pm²")]
    [Scale(1e30)]
    PetameterSquared = 15,

    [UnitAbbreviation("Em²")]
    [Scale(1e36)]
    ExameterSquared = 18,

    //[UnitAbbreviation("Zm²")]
    //[Scale(1e42)]
    //ZettameterSquared = 21,

    //[UnitAbbreviation("Ym²")]
    //[Scale(1e48)]
    //YottameterSquared = 24,

    [UnitAbbreviation("in²")]
    [Scale(0.00064516)]
    InchSquared = 101,

    [UnitAbbreviation("ft²")]
    [Scale(0.09290304)]
    FootSquared = 102,

    [UnitAbbreviation("yd²")]
    [Scale(0.83612736)]
    YardSquared = 103,

    [UnitAbbreviation("ac")]
    [Scale(4046.8564224)]
    Acres = 104,

    [UnitAbbreviation("mi²")]
    [Scale(2589988.110336)]
    SquareMiles = 105

}