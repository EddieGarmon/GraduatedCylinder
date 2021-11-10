using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum VolumeUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = CubicMeters,

    [UnitAbbreviation("m³")]
    [Scale(1.0)]
    CubicMeters = 0,

    [UnitAbbreviation("mm³")]
    [Scale(0.000000001)]
    CubicMillimeters = 1,

    [UnitAbbreviation("cc")]
    [Scale(0.000001)]
    CubicCentimeters = 2,

    [UnitAbbreviation("mL")]
    [Scale(0.000001)]
    Milliliters = 3,

    [UnitAbbreviation("cL")]
    [Scale(0.00001)]
    Centiliters = 4,

    [UnitAbbreviation("dm³")]
    [Scale(.001)]
    CubicDecimeters = 5,

    [UnitAbbreviation("L")]
    [Scale(.001)]
    Liters = 6,

    [UnitAbbreviation("in³")]
    [Scale(0.000016387064)]
    CubicInches = 7,

    [UnitAbbreviation("fl-oz")]
    [Scale(0.0000295735295625)]
    FluidOuncesUS = 8,

    [UnitAbbreviation("fl-oz-UK")]
    [Scale(0.0000284130625)]
    FluidOuncesUK = 9,

    [UnitAbbreviation("pt")]
    [Scale(0.000473176473)]
    PintsUSLiquid = 10,

    [UnitAbbreviation("pt-dry")]
    [Scale(0.0005506104713575)]
    PintsUSDry = 11,

    [UnitAbbreviation("pt-UK")]
    [Scale(0.00056826125)]
    PintsUK = 12,

    [UnitAbbreviation("qt")]
    [Scale(0.000946352946)]
    QuartsUSLiquid = 13,

    [UnitAbbreviation("qt-dry")]
    [Scale(.001101220942715)]
    QuartsUSDry = 14,

    [UnitAbbreviation("qt-UK")]
    [Scale(.0011365225)]
    QuartsUK = 15,

    [UnitAbbreviation("gal")]
    [Scale(.003785411784)]
    GallonsUSLiquid = 16,

    [UnitAbbreviation("gal-dry")]
    [Scale(.00440488377086)]
    GallonsUSDry = 17,

    [UnitAbbreviation("gal-UK")]
    [Scale(.00454609)]
    GallonsUK = 18,

    [UnitAbbreviation("ft³")]
    [Scale(.028316846592)]
    CubicFeet = 19,

    [UnitAbbreviation("yd³")]
    [Scale(.764554857984)]
    CubicYards = 20

}