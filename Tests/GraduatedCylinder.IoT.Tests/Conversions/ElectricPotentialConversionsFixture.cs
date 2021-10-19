using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class ElectricPotentialConversionsFixture
    {

        [Theory]
        [InlineData(15555.655, ElectricPotentialUnit.Volt, 15.5556555, ElectricPotentialUnit.Kilovolt)]
        [InlineData(15555.655, ElectricPotentialUnit.Volt, 15555655, ElectricPotentialUnit.Millivolt)]
        public void ElectricPotentialConversions(float value1,
                                                 ElectricPotentialUnit units1,
                                                 float value2,
                                                 ElectricPotentialUnit units2) {
            new ElectricPotential(value1, units1).In(units2).Value.ShouldBe(value2);
            new ElectricPotential(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}