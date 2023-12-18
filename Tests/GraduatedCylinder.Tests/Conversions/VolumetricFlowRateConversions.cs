using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class VolumetricFlowRateConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(500, VolumetricFlowRateUnit.LitersPerSecond, 30000, VolumetricFlowRateUnit.LitersPerMinute)]
    [InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 31245314.4, VolumetricFlowRateUnit.LitersPerHour)]
    [InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 8.679254, VolumetricFlowRateUnit.CubicMetersPerSecond)]
    [InlineData(679.254, VolumetricFlowRateUnit.LitersPerSecond, 645983.7237089, VolumetricFlowRateUnit.GallonsUsPerHour)]
    [InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 2292.81634211767, VolumetricFlowRateUnit.GallonsUsPerSecond)]
    public void Conversions(double value1, VolumetricFlowRateUnit units1, double value2, VolumetricFlowRateUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new VolumetricFlowRate(value, unit));
    }

}