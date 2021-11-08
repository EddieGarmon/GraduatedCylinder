using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum SpeedUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = MeterPerSecond,

        [UnitAbbreviation("ym/s")]
        [Scale(1e-24f)]
        YoctometerPerSecond = -24,

        [UnitAbbreviation("zm/s")]
        [Scale(1e-21f)]
        ZeptometerPerSecond = -21,

        [UnitAbbreviation("am/s")]
        [Scale(1e-18f)]
        AttometerPerSecond = -18,

        [UnitAbbreviation("fm/s")]
        [Scale(1e-15f)]
        FemtometerPerSecond = -15,

        [UnitAbbreviation("pm/s")]
        [Scale(1e-12f)]
        PicometerPerSecond = -12,

        [UnitAbbreviation("nm/s")]
        [Scale(1e-9f)]
        NanometerPerSecond = -9,

        [UnitAbbreviation("µm/s")]
        [Scale(1e-6f)]
        MicrometerPerSecond = -6,

        [UnitAbbreviation("mm/s")]
        [Scale(1e-3f)]
        MillimeterPerSecond = -3,

        [UnitAbbreviation("cm/s")]
        [Scale(1e-2f)]
        CentimeterPerSecond = -2,

        [UnitAbbreviation("dm/s")]
        [Scale(1e-1f)]
        DecimeterPerSecond = -1,

        [UnitAbbreviation("m/s")]
        [Scale(1.0f)]
        MeterPerSecond = 0,

        [UnitAbbreviation("dam/s")]
        [Scale(10f)]
        DekameterPerSecond = 1,

        [UnitAbbreviation("hm/s")]
        [Scale(1e2f)]
        HectometerPerSecond = 2,

        [UnitAbbreviation("km/s")]
        [Scale(1e3f)]
        KilometerPerSecond = 3,

        [UnitAbbreviation("Mm/s")]
        [Scale(1e6f)]
        MegameterPerSecond = 6,

        [UnitAbbreviation("Gm/s")]
        [Scale(1e9f)]
        GigameterPerSecond = 9,

        [UnitAbbreviation("Tm/s")]
        [Scale(1e12f)]
        TerameterPerSecond = 12,

        [UnitAbbreviation("Pm/s")]
        [Scale(1e15f)]
        PetameterPerSecond = 15,

        [UnitAbbreviation("Em/s")]
        [Scale(1e18f)]
        ExameterPerSecond = 18,

        [UnitAbbreviation("Zm/s")]
        [Scale(1e21f)]
        ZettameterPerSecond = 21,

        [UnitAbbreviation("Ym/s")]
        [Scale(1e24f)]
        YottameterPerSecond = 24,

        [UnitAbbreviation("m/min")]
        [Scale(1.0f / 60.0f)]
        MetersPerMinute = 101,

        [UnitAbbreviation("m/h")]
        [Scale(1.0f / 3600.0f)]
        MetersPerHour = 102,

        [UnitAbbreviation("km/h")]
        [Scale(1.0f / 3.6f)]
        KilometersPerHour = 103,

        [UnitAbbreviation("ft/s")]
        [Scale(0.3048f)]
        FeetPerSecond = 104,

        [UnitAbbreviation("ft/min")]
        [Scale(0.00508f)]
        FeetPerMinute = 105,

        [UnitAbbreviation("ft/h")]
        [Scale(1.0f / 11811.0f)]
        FeetPerHour = 106,

        [UnitAbbreviation("mph")]
        [Scale(0.44704f)]
        MilesPerHour = 107,

        [UnitAbbreviation("knots")]
        [Scale(0.514444f)]
        NauticalMilesPerHour = 108,

        [UnitAbbreviation("yd/s")]
        [Scale(0.9144f)]
        YardsPerSecond = 109

    }
}