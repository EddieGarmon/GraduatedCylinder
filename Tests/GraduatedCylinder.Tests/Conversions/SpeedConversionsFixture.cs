using Xunit.Abstractions;
#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class SpeedConversionsFixture
{

    private readonly ITestOutputHelper _output;

    public SpeedConversionsFixture(ITestOutputHelper output) {
        _output = output;
    }

    [Theory]
    [InlineData(100, SpeedUnit.MeterPerSecond, 360, SpeedUnit.KiloMetersPerHour)]
    [InlineData(100, SpeedUnit.MeterPerSecond, 223.69363, SpeedUnit.MilesPerHour)]
    [InlineData(100, SpeedUnit.MeterPerSecond, 194.384617178935, SpeedUnit.NauticalMilesPerHour)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 18810180.8835, SpeedUnit.FeetPerHour)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 313503.6417322835, SpeedUnit.FeetPerMinute)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 5225.060695538, SpeedUnit.FeetPerSecond)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 5733354.6, SpeedUnit.MetersPerHour)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 95555.91, SpeedUnit.MetersPerMinute)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 1741.686898513, SpeedUnit.YardsPerSecond)]
    [InlineData(3455.9997558, SpeedUnit.KiloMetersPerHour, 2147.458740, SpeedUnit.MilesPerHour)]
    [InlineData(2176.546, SpeedUnit.MilesPerHour, 3502.811245824, SpeedUnit.KiloMetersPerHour)]
    public void SpeedConversions(double value1, SpeedUnit units1, double value2, SpeedUnit units2) {
        Speed speed1 = new(value1, units1);
        Speed speed2 = new(value2, units2);
        Speed speed1Converted = speed1.In(units2);
        Speed speed2Converted = speed2.In(units1);
        _output.WriteLine($"    speed 1: {speed1}, 2: {speed2}");
        _output.WriteLine($"converted 1: {speed2Converted}, 2: {speed2}");
        speed1Converted.ShouldBe(speed2);
        speed2Converted.ShouldBe(speed1);
    }

}