using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AccelerationUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = MeterPerSecondSquared,

        [UnitAbbreviation("ym/s²")]
        [Scale(1e-24f)]
        YoctometerPerSecondSquared = -24,

        [UnitAbbreviation("zm/s²")]
        [Scale(1e-21f)]
        ZeptometerPerSecondSquared = -21,

        [UnitAbbreviation("am/s²")]
        [Scale(1e-18f)]
        AttometerPerSecondSquared = -18,

        [UnitAbbreviation("fm/s²")]
        [Scale(1e-15f)]
        FemtometerPerSecondSquared = -15,

        [UnitAbbreviation("pm/s²")]
        [Scale(1e-12f)]
        PicometerPerSecondSquared = -12,

        [UnitAbbreviation("nm/s²")]
        [Scale(1e-9f)]
        NanometerPerSecondSquared = -9,

        [UnitAbbreviation("µm/s²")]
        [Scale(1e-6f)]
        MicrometerPerSecondSquared = -6,

        [UnitAbbreviation("mm/s²")]
        [Scale(1e-3f)]
        MillimeterPerSecondSquared = -3,

        [UnitAbbreviation("cm/s²")]
        [Scale(1e-2f)]
        CentimeterPerSecondSquared = -2,

        [UnitAbbreviation("dm/s²")]
        [Scale(1e-1f)]
        DecimeterPerSecondSquared = -1,

        [UnitAbbreviation("m/s²")]
        [Scale(1.0f)]
        MeterPerSecondSquared = 0,

        [UnitAbbreviation("dam/s²")]
        [Scale(10f)]
        DekameterPerSecondSquared = 1,

        [UnitAbbreviation("hm/s²")]
        [Scale(1e2f)]
        HectometerPerSecondSquared = 2,

        [UnitAbbreviation("km/s²")]
        [Scale(1e3f)]
        KilometerPerSecondSquared = 3,

        [UnitAbbreviation("Mm/s²")]
        [Scale(1e6f)]
        MegameterPerSecondSquared = 6,

        [UnitAbbreviation("Gm/s²")]
        [Scale(1e9f)]
        GigameterPerSecondSquared = 9,

        [UnitAbbreviation("Tm/s²")]
        [Scale(1e12f)]
        TerameterPerSecondSquared = 12,

        [UnitAbbreviation("Pm/s²")]
        [Scale(1e15f)]
        PetameterPerSecondSquared = 15,

        [UnitAbbreviation("Em/s²")]
        [Scale(1e18f)]
        ExameterPerSecondSquared = 18,

        [UnitAbbreviation("Zm/s²")]
        [Scale(1e21f)]
        ZettameterPerSecondSquared = 21,

        [UnitAbbreviation("Ym/s²")]
        [Scale(1e24f)]
        YottameterPerSecondSquared = 24,

        [UnitAbbreviation("km/h/s")]
        [Scale(1.0f / 3.6f)]
        KilometerPerHourPerSecond = 101,

        [UnitAbbreviation("mph/s")]
        [Scale(0.44704f)]
        MilePerHourPerSecond = 102

    }
}