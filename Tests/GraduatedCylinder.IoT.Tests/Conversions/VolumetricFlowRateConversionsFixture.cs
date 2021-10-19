using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class VolumetricFlowRateConversionsFixture
    {

        [Theory]
        [InlineData(8679.254,
                    VolumetricFlowRateUnit.LitersPerSecond,
                    520755.16,
                    VolumetricFlowRateUnit.LitersPerMinute)]
        [InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 31245310, VolumetricFlowRateUnit.LitersPerHour)]
        [InlineData(8679.254,
                    VolumetricFlowRateUnit.LitersPerSecond,
                    8.679254,
                    VolumetricFlowRateUnit.CubicMetersPerSecond)]
        [InlineData(8679.254,
                    VolumetricFlowRateUnit.LitersPerSecond,
                    8254141,
                    VolumetricFlowRateUnit.GallonsUsPerHour)]
        [InlineData(8679.254,
                    VolumetricFlowRateUnit.LitersPerSecond,
                    2292.8162,
                    VolumetricFlowRateUnit.GallonsUsPerSecond)]
        public void VolumetricFlowRateConversions(float value1,
                                                  VolumetricFlowRateUnit units1,
                                                  float value2,
                                                  VolumetricFlowRateUnit units2) {
            new VolumetricFlowRate(value1, units1).In(units2).Value.ShouldBe(value2);
            new VolumetricFlowRate(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}