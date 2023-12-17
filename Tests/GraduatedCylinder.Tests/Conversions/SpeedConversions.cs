using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class SpeedConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(100, SpeedUnit.MeterPerSecond, 360, SpeedUnit.KiloMetersPerHour)]
    [InlineData(100, SpeedUnit.MeterPerSecond, 223.69363, SpeedUnit.MilesPerHour)]
    [InlineData(100, SpeedUnit.MeterPerSecond, 194.384617178935, SpeedUnit.NauticalMilesPerHour)]
    [InlineData(100, SpeedUnit.MeterPerSecond, 1181099.9999999, SpeedUnit.FeetPerHour)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 313503.6417322835, SpeedUnit.FeetPerMinute)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 5225.060695538, SpeedUnit.FeetPerSecond)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 5733354.6, SpeedUnit.MetersPerHour)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 95555.914062, SpeedUnit.MetersPerMinute)]
    [InlineData(1592.5985, SpeedUnit.MeterPerSecond, 1741.686898513, SpeedUnit.YardsPerSecond)]
    [InlineData(3455.99982, SpeedUnit.KiloMetersPerHour, 2147.458740, SpeedUnit.MilesPerHour)]
    [InlineData(2176.546, SpeedUnit.MilesPerHour, 3502.811245824, SpeedUnit.KiloMetersPerHour)]
    public void Conversions(double value1, SpeedUnit units1, double value2, SpeedUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Speed(value, unit));
    }

}