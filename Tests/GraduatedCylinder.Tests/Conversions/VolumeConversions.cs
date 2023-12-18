using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class VolumeConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(1000, VolumeUnit.Liters, 100000, VolumeUnit.CentiLiters)]
    [InlineData(1000, VolumeUnit.Liters, 1000000, VolumeUnit.CubicCentiMeters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1000.7865, VolumeUnit.CubicDeciMeters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 35.34244170686, VolumeUnit.CubicFeet)]
    [InlineData(1000, VolumeUnit.Liters, 61023.74409473, VolumeUnit.CubicInches)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1.0007865, VolumeUnit.CubicMeters)]
    [InlineData(1000, VolumeUnit.Liters, 1000000000, VolumeUnit.CubicMilliMeters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1.30897932248, VolumeUnit.CubicYards)]
    [InlineData(1000.7865, VolumeUnit.Liters, 35222.76065806, VolumeUnit.FluidOuncesUK)]
    [InlineData(1000.7865, VolumeUnit.Liters, 33840.617430698, VolumeUnit.FluidOuncesUS)]
    [InlineData(1000.7865, VolumeUnit.Liters, 220.1422541129, VolumeUnit.GallonsUK)]
    [InlineData(1000.7865, VolumeUnit.Liters, 227.199297884, VolumeUnit.GallonsUSDry)]
    [InlineData(1000.7865, VolumeUnit.Liters, 264.3798236773, VolumeUnit.GallonsUSLiquid)]
    [InlineData(1000, VolumeUnit.Liters, 1000000, VolumeUnit.MilliLiters)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1761.138032903, VolumeUnit.PintsUK)]
    [InlineData(100, VolumeUnit.Liters, 181.61659685, VolumeUnit.PintsUSDry)]
    [InlineData(1000.7865, VolumeUnit.Liters, 2115.03858942, VolumeUnit.PintsUSLiquid)]
    [InlineData(1000.7865, VolumeUnit.Liters, 880.5690164515, VolumeUnit.QuartsUK)]
    [InlineData(1000.7865, VolumeUnit.Liters, 908.797191536, VolumeUnit.QuartsUSDry)]
    [InlineData(1000.7865, VolumeUnit.Liters, 1057.519294709, VolumeUnit.QuartsUSLiquid)]
    public void Conversions(double value1, VolumeUnit units1, double value2, VolumeUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Volume(value, unit));
    }

}