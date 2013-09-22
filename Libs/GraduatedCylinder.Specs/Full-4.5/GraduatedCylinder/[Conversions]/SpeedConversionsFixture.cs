using Xunit.Theories;

namespace GraduatedCylinder
{
    public class SpeedConversionsFixture
    {
        [Theory]
        [InlineData(100, SpeedUnit.MetersPerSecond, 360, SpeedUnit.KilometersPerHour)]
        [InlineData(100, SpeedUnit.MetersPerSecond, 223.69363, SpeedUnit.MilesPerHour)]
        [InlineData(100, SpeedUnit.MetersPerSecond, 194.384617178935, SpeedUnit.NauticalMilesPerHour)]
        [InlineData(1592.5985, SpeedUnit.MetersPerSecond, 18810180.8835, SpeedUnit.FeetPerHour)]
        [InlineData(1592.5985, SpeedUnit.MetersPerSecond, 313503.6417322835, SpeedUnit.FeetPerMinute)]
        [InlineData(1592.5985, SpeedUnit.MetersPerSecond, 5225.060695538, SpeedUnit.FeetPerSecond)]
        [InlineData(1592.5985, SpeedUnit.MetersPerSecond, 5733354.6, SpeedUnit.MetersPerHour)]
        [InlineData(1592.5985, SpeedUnit.MetersPerSecond, 95555.91, SpeedUnit.MetersPerMinute)]
        [InlineData(1592.5985, SpeedUnit.MetersPerSecond, 1741.686898513, SpeedUnit.YardsPerSecond)]
        [InlineData(3564.765, SpeedUnit.KilometersPerHour, 2215.042278096, SpeedUnit.MilesPerHour)]
        [InlineData(2176.546, SpeedUnit.MilesPerHour, 3502.811245824, SpeedUnit.KilometersPerHour)]
        public void SpeedConversions(double value1, SpeedUnit units1, double value2, SpeedUnit units2) {
            new Speed(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
            new Speed(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}