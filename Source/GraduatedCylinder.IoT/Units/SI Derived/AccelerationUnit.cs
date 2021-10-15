using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum AccelerationUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = MeterPerSecondSquared,

        [UnitAbbreviation("ym/s^2")]
        [Scale(1e-24f)]
        YoctometerPerSecondSquared = -24,

        [UnitAbbreviation("zm/s^2")]
        [Scale(1e-21f)]
        ZeptometerPerSecondSquared = -21,

        [UnitAbbreviation("am/s^2")]
        [Scale(1e-18f)]
        AttometerPerSecondSquared = -18,

        [UnitAbbreviation("fm/s^2")]
        [Scale(1e-15f)]
        FemtometerPerSecondSquared = -15,

        [UnitAbbreviation("pm/s^2")]
        [Scale(1e-12f)]
        PicometerPerSecondSquared = -12,

        [UnitAbbreviation("nm/s^2")]
        [Scale(1e-9f)]
        NanometerPerSecondSquared = -9,

        [UnitAbbreviation("µm/s^2")]
        [Scale(1e-6f)]
        MicrometerPerSecondSquared = -6,

        [UnitAbbreviation("mm/s^2")]
        [Scale(1e-3f)]
        MillimeterPerSecondSquared = -3,

        [UnitAbbreviation("cm/s^2")]
        [Scale(1e-2f)]
        CentimeterPerSecondSquared = -2,

        [UnitAbbreviation("dm/s^2")]
        [Scale(1e-1f)]
        DecimeterPerSecondSquared = -1,

        [UnitAbbreviation("m/s^2")]
        [Scale(1.0f)]
        MeterPerSecondSquared = 0,

        [UnitAbbreviation("dam/s^2")]
        [Scale(10f)]
        DekameterPerSecondSquared = 1,

        [UnitAbbreviation("hm/s^2")]
        [Scale(1e2f)]
        HectometerPerSecondSquared = 2,

        [UnitAbbreviation("km/s^2")]
        [Scale(1e3f)]
        KilometerPerSecondSquared = 3,

        [UnitAbbreviation("Mm/s^2")]
        [Scale(1e6f)]
        MegameterPerSecondSquared = 6,

        [UnitAbbreviation("Gm/s^2")]
        [Scale(1e9f)]
        GigameterPerSecondSquared = 9,

        [UnitAbbreviation("Tm/s^2")]
        [Scale(1e12f)]
        TerameterPerSecondSquared = 12,

        [UnitAbbreviation("Pm/s^2")]
        [Scale(1e15f)]
        PetameterPerSecondSquared = 15,

        [UnitAbbreviation("Em/s^2")]
        [Scale(1e18f)]
        ExameterPerSecondSquared = 18,

        [UnitAbbreviation("Zm/s^2")]
        [Scale(1e21f)]
        ZettameterPerSecondSquared = 21,

        [UnitAbbreviation("Ym/s^2")]
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