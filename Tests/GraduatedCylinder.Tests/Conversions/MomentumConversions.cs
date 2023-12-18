using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class MomentumConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(6579.356, MomentumUnit.KiloGramMetersPerSecond, 657935600, MomentumUnit.GramCentiMetersPerSecond)]
    [InlineData(6579.356, MomentumUnit.KiloGramMetersPerSecond, 32446.7596668, MomentumUnit.PoundsMilesPerHour)]
    [InlineData(6579.356, MomentumUnit.KiloGramMetersPerSecond, 23685.6816, MomentumUnit.KiloGramsKiloMetersPerHour)]
    [InlineData(205.75, MomentumUnit.KiloGramMetersPerSecond, 12345, MomentumUnit.KiloGramsMetersPerMinute)]
    public void Conversions(double value1, MomentumUnit units1, double value2, MomentumUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Momentum(value, unit));
    }

}