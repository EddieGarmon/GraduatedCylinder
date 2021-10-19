using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class MomentumConversionsFixture
    {

        [Theory]
        [InlineData(6579.356, MomentumUnit.KilogramMetersPerSecond, 657935600, MomentumUnit.GramCentimetersPerSecond)]
        [InlineData(6579.356, MomentumUnit.KilogramMetersPerSecond, 32446.759, MomentumUnit.PoundsMilesPerHour)]
        [InlineData(6579.356, MomentumUnit.KilogramMetersPerSecond, 23685.68, MomentumUnit.KilogramsKiloMetersPerHour)]
        [InlineData(6579.356, MomentumUnit.KilogramMetersPerSecond, 394761.28, MomentumUnit.KilogramsMetersPerMinute)]
        public void MomentumConversions(float value1, MomentumUnit units1, float value2, MomentumUnit units2) {
            new Momentum(value1, units1).In(units2).Value.ShouldBe(value2);
            new Momentum(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}