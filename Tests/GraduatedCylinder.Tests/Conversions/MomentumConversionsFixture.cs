using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Conversions;

public class MomentumConversionsFixture
{

    [Theory]
    [InlineData(6579.356, MomentumUnit.KiloGramMetersPerSecond, 657935600, MomentumUnit.GramCentiMetersPerSecond)]
    [InlineData(6579.356, MomentumUnit.KiloGramMetersPerSecond, 32446.7596668, MomentumUnit.PoundsMilesPerHour)]
    [InlineData(6579.356, MomentumUnit.KiloGramMetersPerSecond, 23685.6816, MomentumUnit.KiloGramsKiloMetersPerHour)]
    [InlineData(6579.356, MomentumUnit.KiloGramMetersPerSecond, 394761.36, MomentumUnit.KiloGramsMetersPerMinute)]
    public void MomentumConversions(double value1, MomentumUnit units1, double value2, MomentumUnit units2) {
        new Momentum(value1, units1).In(units2).ShouldBe(new Momentum(value2, units2));
        new Momentum(value2, units2).In(units1).ShouldBe(new Momentum(value1, units1));
    }

}