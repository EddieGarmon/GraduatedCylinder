using Xunit;

namespace GraduatedCylinder.Conversions
{
    public class VoltageConversionsFixture
    {
        [Theory]
        [InlineData(15555.655, ElectricPotentialUnit.Volt, 15.555655, ElectricPotentialUnit.Kilovolt)]
        [InlineData(15555.655, ElectricPotentialUnit.Volt, 15555655, ElectricPotentialUnit.Millivolt)]
        public void VoltageConversions(double value1,
                                       ElectricPotentialUnit units1,
                                       double value2,
                                       ElectricPotentialUnit units2) {
            new ElectricPotential(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinToleranceOf(value2);
            new ElectricPotential(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinToleranceOf(value1);
        }
    }
}