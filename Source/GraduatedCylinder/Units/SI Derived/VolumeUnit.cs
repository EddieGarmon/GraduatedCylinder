using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder
{
    public enum VolumeUnit : short
    {

        Unspecified = short.MinValue,

        BaseUnit = CubicMeters,

        [UnitAbbreviation("m³")]
        [Scale(1.0f)]
        CubicMeters = 0,

        [UnitAbbreviation("mm³")]
        [Scale(0.000000001f)]
        CubicMillimeters = 1,

        [UnitAbbreviation("cc")]
        [Scale(0.000001f)]
        CubicCentimeters = 2,

        [UnitAbbreviation("mL")]
        [Scale(0.000001f)]
        Milliliters = 3,

        [UnitAbbreviation("cL")]
        [Scale(0.00001f)]
        Centilitres = 4,

        [UnitAbbreviation("dm³")]
        [Scale(.001f)]
        CubicDecimeters = 5,

        [UnitAbbreviation("L")]
        [Scale(.001f)]
        Liters = 6,

        [UnitAbbreviation("in³")]
        [Scale(0.000016387064f)]
        CubicInches = 7,

        [UnitAbbreviation("fl-oz")]
        [Scale(0.0000295735295625f)]
        FluidOuncesUS = 8,

        [UnitAbbreviation("fl-oz-UK")]
        [Scale(0.0000284130625f)]
        FluidOuncesUK = 9,

        [UnitAbbreviation("pt")]
        [Scale(0.000473176473f)]
        PintsUSLiquid = 10,

        [UnitAbbreviation("pt-dry")]
        [Scale(0.0005506104713575f)]
        PintsUSDry = 11,

        [UnitAbbreviation("pt-UK")]
        [Scale(0.00056826125f)]
        PintsUK = 12,

        [UnitAbbreviation("qt")]
        [Scale(0.000946352946f)]
        QuartsUSLiquid = 13,

        [UnitAbbreviation("qt-dry")]
        [Scale(.001101220942715f)]
        QuartsUSDry = 14,

        [UnitAbbreviation("qt-UK")]
        [Scale(.0011365225f)]
        QuartsUK = 15,

        [UnitAbbreviation("gal")]
        [Scale(.003785411784f)]
        GallonsUSLiquid = 16,

        [UnitAbbreviation("gal-dry")]
        [Scale(.00440488377086f)]
        GallonsUSDry = 17,

        [UnitAbbreviation("gal-UK")]
        [Scale(.00454609f)]
        GallonsUK = 18,

        [UnitAbbreviation("ft³")]
        [Scale(.028316846592f)]
        CubicFeet = 19,

        [UnitAbbreviation("yd³")]
        [Scale(.764554857984f)]
        CubicYards = 20

    }
}