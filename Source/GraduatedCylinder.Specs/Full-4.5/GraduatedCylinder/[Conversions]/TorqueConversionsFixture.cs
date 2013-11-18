using Xunit.Theories;

namespace GraduatedCylinder
{
    public class TorqueConversionsFixture
    {
        [Theory]
        [InlineData(156.758, TorqueUnit.NewtonMeters, 15.9794087666, TorqueUnit.KilogramForceMeters)]
        [InlineData(156.789, TorqueUnit.NewtonMeters, 115.64163168071347631885239460062, TorqueUnit.FootPounds)]
        [InlineData(1678.254, TorqueUnit.KilogramForceMeters, 12142.9810986054, TorqueUnit.FootPounds)]
        public void TorqueConversions(double value1, TorqueUnit units1, double value2, TorqueUnit units2) {
            new Torque(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
            new Torque(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}