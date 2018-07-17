namespace GraduatedCylinder
{
    public enum AreaUnit
    {
        BaseUnit = MeterSquared,

        [UnitAbbreviation("ym^2")]
        [Scale(1e-48)]
        YoctometerSquared = -24,

        [UnitAbbreviation("zm^2")]
        [Scale(1e-42)]
        ZeptometerSquared = -21,

        [UnitAbbreviation("am^2")]
        [Scale(1e-36)]
        AttometerSquared = -18,

        [UnitAbbreviation("fm^2")]
        [Scale(1e-30)]
        FemtometerSquared = -15,

        [UnitAbbreviation("pm^2")]
        [Scale(1e-24)]
        PicometerSquared = -12,

        [UnitAbbreviation("nm^2")]
        [Scale(1e-18)]
        NanometerSquared = -9,

        [UnitAbbreviation("µm^2")]
        [Scale(1e-12)]
        MicrometerSquared = -6,

        [UnitAbbreviation("mm^2")]
        [Scale(1e-6)]
        MillimeterSquared = -3,

        [UnitAbbreviation("cm^2")]
        [Scale(1e-4)]
        CentimeterSquared = -2,

        [UnitAbbreviation("dm^2")]
        [Scale(1e-2)]
        DecimeterSquared = -1,

        [UnitAbbreviation("m^2")]
        [Scale(1.0)]
        MeterSquared = 0,

        [UnitAbbreviation("dam^2")]
        [Scale(1e2)]
        DekameterSquared = 1,

        [UnitAbbreviation("hm^2")]
        [Scale(1e4)]
        HectometerSquared = 2,

        [UnitAbbreviation("km^2")]
        [Scale(1e6)]
        KilometerSquared = 3,

        [UnitAbbreviation("Mm^2")]
        [Scale(1e12)]
        MegameterSquared = 6,

        [UnitAbbreviation("Gm^2")]
        [Scale(1e18)]
        GigameterSquared = 9,

        [UnitAbbreviation("Tm^2")]
        [Scale(1e24)]
        TerameterSquared = 12,

        [UnitAbbreviation("Pm^2")]
        [Scale(1e30)]
        PetameterSquared = 15,

        [UnitAbbreviation("Em^2")]
        [Scale(1e36)]
        ExameterSquared = 18,

        [UnitAbbreviation("Zm^2")]
        [Scale(1e42)]
        ZettameterSquared = 21,

        [UnitAbbreviation("Ym^2")]
        [Scale(1e48)]
        YottameterSquared = 24,

        [UnitAbbreviation("in^2")]
        [Scale(0.00064516)]
        InchSquared = 101,

        [UnitAbbreviation("ft^2")]
        [Scale(0.09290304)]
        FootSquared = 102,

        [UnitAbbreviation("yd^2")]
        [Scale(0.83612736)]
        YardSquared = 103,

        [UnitAbbreviation("ac")]
        [Scale(4046.8564224)]
        Acres = 104,

        [UnitAbbreviation("mi^2")]
        [Scale(2589988.110336)]
        SquareMiles = 105
    }
}