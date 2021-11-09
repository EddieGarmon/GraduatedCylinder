using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AreaUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = MeterSquared,

        [UnitAbbreviation("ym²")]
        [Scale(1e-48f)]
        YoctometerSquared = -24,

        [UnitAbbreviation("zm²")]
        [Scale(1e-42f)]
        ZeptometerSquared = -21,

        [UnitAbbreviation("am²")]
        [Scale(1e-36f)]
        AttometerSquared = -18,

        [UnitAbbreviation("fm²")]
        [Scale(1e-30f)]
        FemtometerSquared = -15,

        [UnitAbbreviation("pm²")]
        [Scale(1e-24f)]
        PicometerSquared = -12,

        [UnitAbbreviation("nm²")]
        [Scale(1e-18f)]
        NanometerSquared = -9,

        [UnitAbbreviation("µm²")]
        [Scale(1e-12f)]
        MicrometerSquared = -6,

        [UnitAbbreviation("mm²")]
        [Scale(1e-6f)]
        MillimeterSquared = -3,

        [UnitAbbreviation("cm²")]
        [Scale(1e-4f)]
        CentimeterSquared = -2,

        [UnitAbbreviation("dm²")]
        [Scale(1e-2f)]
        DecimeterSquared = -1,

        [UnitAbbreviation("m²")]
        [Scale(1.0f)]
        MeterSquared = 0,

        [UnitAbbreviation("dam²")]
        [Scale(1e2f)]
        DekameterSquared = 1,

        [UnitAbbreviation("hm²")]
        [Scale(1e4f)]
        HectometerSquared = 2,

        [UnitAbbreviation("km²")]
        [Scale(1e6f)]
        KilometerSquared = 3,

        [UnitAbbreviation("Mm²")]
        [Scale(1e12f)]
        MegameterSquared = 6,

        [UnitAbbreviation("Gm²")]
        [Scale(1e18f)]
        GigameterSquared = 9,

        [UnitAbbreviation("Tm²")]
        [Scale(1e24f)]
        TerameterSquared = 12,

        [UnitAbbreviation("Pm²")]
        [Scale(1e30f)]
        PetameterSquared = 15,

        [UnitAbbreviation("Em²")]
        [Scale(1e36f)]
        ExameterSquared = 18,

        //[UnitAbbreviation("Zm²")]
        //[Scale(1e42f)]
        //ZettameterSquared = 21,

        //[UnitAbbreviation("Ym²")]
        //[Scale(1e48f)]
        //YottameterSquared = 24,

        [UnitAbbreviation("in²")]
        [Scale(0.00064516f)]
        InchSquared = 101,

        [UnitAbbreviation("ft²")]
        [Scale(0.09290304f)]
        FootSquared = 102,

        [UnitAbbreviation("yd²")]
        [Scale(0.83612736f)]
        YardSquared = 103,

        [UnitAbbreviation("ac")]
        [Scale(4046.8564224f)]
        Acres = 104,

        [UnitAbbreviation("mi²")]
        [Scale(2589988.110336f)]
        SquareMiles = 105

    }
}