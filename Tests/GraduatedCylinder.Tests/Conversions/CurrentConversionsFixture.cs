using Xunit;

namespace GraduatedCylinder.Conversions
{
    public class CurrentConversionsFixture
    {
        [Theory]
        [InlineData(45553.6666, ElectricCurrentUnit.Ampere, 45.5536666, ElectricCurrentUnit.KiloAmpere)]
        [InlineData(45553.6666, ElectricCurrentUnit.Ampere, 45553666.6, ElectricCurrentUnit.Milliampere)]
        public void CurrentConversions(double value1,
                                       ElectricCurrentUnit units1,
                                       double value2,
                                       ElectricCurrentUnit units2) {
            new ElectricCurrent(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinToleranceOf(value2);
            new ElectricCurrent(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinToleranceOf(value1);
        }
    }
}