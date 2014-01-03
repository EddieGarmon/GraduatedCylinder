using Xunit;

namespace GraduatedCylinder
{
    public class ResistanceConversionsFixture
    {
        [Theory]
        [InlineData(67749.5444, ElectricResistanceUnit.Ohm, 67.7495444, ElectricResistanceUnit.Kiloohm)]
        [InlineData(67749.5444, ElectricResistanceUnit.Ohm, 67749544.4, ElectricResistanceUnit.Milliohm)]
        public void ResistanceConversions(double value1, ElectricResistanceUnit units1, double value2, ElectricResistanceUnit units2) {
            new ElectricResistance(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinEpsilonOf(value2);
            new ElectricResistance(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}