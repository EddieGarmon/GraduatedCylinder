#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class VolumeConversionsFixture
{

    [Theory]
    [InlineData(1000.7865, VolumeUnit.Liters, 100078.65, VolumeUnit.CentiLiters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1000786.5, VolumeUnit.CubicCentiMeters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1000.7865, VolumeUnit.CubicDeciMeters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 35.34244170686, VolumeUnit.CubicFeet)]
    [InlineData(1000.7865, VolumeUnit.Liters, 61071.73926946279, VolumeUnit.CubicInches)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1.0007865, VolumeUnit.CubicMeters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1000786500, VolumeUnit.CubicMilliMeters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1.30897932248, VolumeUnit.CubicYards)]
    [InlineData(1000.7865, VolumeUnit.Liters, 35222.76065806, VolumeUnit.FluidOuncesUK)]
    [InlineData(1000.7865, VolumeUnit.Liters, 33840.617430698, VolumeUnit.FluidOuncesUS)]
    [InlineData(1000.7865, VolumeUnit.Liters, 220.1422541129, VolumeUnit.GallonsUK)]
    [InlineData(1000.7865, VolumeUnit.Liters, 227.199297884, VolumeUnit.GallonsUSDry)]
    [InlineData(1000.7865, VolumeUnit.Liters, 264.3798236773, VolumeUnit.GallonsUSLiquid)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1000786.5, VolumeUnit.MilliLiters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1761.138032903, VolumeUnit.PintsUK)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1817.594383072, VolumeUnit.PintsUSDry)]
    [InlineData(1000.7865, VolumeUnit.Liters, 2115.03858942, VolumeUnit.PintsUSLiquid)]
    [InlineData(1000.7865, VolumeUnit.Liters, 880.5690164515, VolumeUnit.QuartsUK)]
    [InlineData(1000.7865, VolumeUnit.Liters, 908.797191536, VolumeUnit.QuartsUSDry)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1057.519294709, VolumeUnit.QuartsUSLiquid)]
    public void VolumeConversions(double value1, VolumeUnit units1, double value2, VolumeUnit units2) {
        new Volume(value1, units1).In(units2).ShouldBe(new Volume(value2, units2));
        new Volume(value2, units2).In(units1).ShouldBe(new Volume(value1, units1));
    }

}