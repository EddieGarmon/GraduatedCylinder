using Xunit.Theories;

namespace GraduatedCylinder
{
    public class MomentumConversionsFixture
    {
        [Theory]
        [InlineData(6579.356, MomentumUnit.KilogramMetersPerSecond, 657935600, MomentumUnit.GramCentimetersPerSecond)]
        [InlineData(6579.356, MomentumUnit.KilogramMetersPerSecond, 32446.7596668, MomentumUnit.PoundsMilesPerHour)]
        [InlineData(6579.356, MomentumUnit.KilogramMetersPerSecond, 23685.6816, MomentumUnit.KilogramsKiloMetersPerHour)]
        [InlineData(6579.356, MomentumUnit.KilogramMetersPerSecond, 394761.36, MomentumUnit.KilogramsMetersPerMinute)]
        public void MomentumConversions(double value1, MomentumUnit units1, double value2, MomentumUnit units2) {
            new Momentum(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
            new Momentum(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}