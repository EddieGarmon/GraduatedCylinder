using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class CurrentConversionsFixture
    {

        [Theory]
        [InlineData(45553.6666, ElectricCurrentUnit.Ampere, 45.55367, ElectricCurrentUnit.KiloAmpere)]
        [InlineData(45553.6666, ElectricCurrentUnit.Ampere, 45553664, ElectricCurrentUnit.Milliampere)]
        public void CurrentConversions(float value1,
                                       ElectricCurrentUnit units1,
                                       float value2,
                                       ElectricCurrentUnit units2) {
            new ElectricCurrent(value1, units1).In(units2).Value.ShouldBe(value2);
            new ElectricCurrent(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}