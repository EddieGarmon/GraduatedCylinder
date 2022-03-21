using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Conversions;

public class SpeedConversionsFixture
{

    [Theory]
    [InlineData(100, SpeedUnit.MeterPerSecond, 360, SpeedUnit.KilometersPerHour)]
    [InlineData(100, SpeedUnit.MeterPerSecond, 223.69363, SpeedUnit.MilesPerHour)]
    [InlineData(100, SpeedUnit.MeterPerSecond, 194.384617178935, SpeedUnit.NauticalMilesPerHour)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 18810180.8835, SpeedUnit.FeetPerHour)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 313503.6417322835, SpeedUnit.FeetPerMinute)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 5225.060695538, SpeedUnit.FeetPerSecond)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 5733354.6, SpeedUnit.MetersPerHour)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 95555.91, SpeedUnit.MetersPerMinute)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 1741.686898513, SpeedUnit.YardsPerSecond)]
    [InlineData(3564.765, SpeedUnit.KilometersPerHour, 2215.042278096, SpeedUnit.MilesPerHour)]
    [InlineData(2176.546, SpeedUnit.MilesPerHour, 3502.811245824, SpeedUnit.KilometersPerHour)]
    public void SpeedConversions(double value1, SpeedUnit units1, double value2, SpeedUnit units2) {
        new Speed(value1, units1).In(units2).ShouldBe(new Speed(value2, units2));
        new Speed(value2, units2).In(units1).ShouldBe(new Speed(value1, units1));
    }

}