using GraduatedCylinder.Abbreviations;
using GraduatedCylinder.Extensions;
using GraduatedCylinder.Scales;

namespace GraduatedCylinder;

public enum VolumeUnit : short
{

    Unspecified = short.MinValue,

    BaseUnit = CubicMeters,

    [UnitAbbreviation("mm³")]
    [Scale(1E-9)]
    CubicMilliMeters = -9,

    [UnitAbbreviation("cm³")]
    [Scale(1E-6)]
    CubicCentiMeters = -6,

    [UnitAbbreviation("dm³")]
    [Scale(.001)]
    CubicDeciMeters = -3,

    [UnitAbbreviation("m³")]
    [Scale(1.0)]
    CubicMeters = 0,

    [UnitAbbreviation("km³")]
    [Scale(1E9)]
    CubicKiloMeters = 9,

    [UnitAbbreviation("mL")]
    [Scale(0.000001)]
    MilliLiters = 100,

    [UnitAbbreviation("cL")]
    [Scale(0.00001)]
    CentiLiters = 101,

    [UnitAbbreviation("L")]
    [Scale(.001)]
    [Extension("Liters")]
    Liters = 102,

    [UnitAbbreviation("in³")]
    [Scale(0.000016387064)]
    CubicInches = 110,

    [UnitAbbreviation("ft³")]
    [Scale(.028316846592)]
    CubicFeet = 111,

    [UnitAbbreviation("yd³")]
    [Scale(.764554857984)]
    CubicYards = 112,

    [UnitAbbreviation("fl-oz")]
    [Scale(0.0000295735295625)]
    FluidOuncesUS = 150,

    [UnitAbbreviation("fl-oz-UK")]
    [Scale(0.0000284130625)]
    FluidOuncesUK = 151,

    [UnitAbbreviation("pt")]
    [Scale(0.000473176473)]
    PintsUSLiquid = 152,

    [UnitAbbreviation("pt-dry")]
    [Scale(0.0005506104713575)]
    PintsUSDry = 153,

    [UnitAbbreviation("pt-UK")]
    [Scale(0.00056826125)]
    PintsUK = 154,

    [UnitAbbreviation("qt")]
    [Scale(0.000946352946)]
    QuartsUSLiquid = 155,

    [UnitAbbreviation("qt-dry")]
    [Scale(.001101220942715)]
    QuartsUSDry = 156,

    [UnitAbbreviation("qt-UK")]
    [Scale(.0011365225)]
    QuartsUK = 157,

    [UnitAbbreviation("gal")]
    [Scale(.003785411784)]
    GallonsUSLiquid = 158,

    [UnitAbbreviation("gal-dry")]
    [Scale(.00440488377086)]
    GallonsUSDry = 159,

    [UnitAbbreviation("gal-UK")]
    [Scale(.00454609)]
    GallonsUK = 160

}