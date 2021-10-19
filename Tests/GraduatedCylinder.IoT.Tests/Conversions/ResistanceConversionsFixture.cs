using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class ResistanceConversionsFixture
    {

        [Theory]
        [InlineData(67749.5444, ElectricResistanceUnit.Ohm, 67.74955, ElectricResistanceUnit.Kiloohm)]
        [InlineData(67749.5444, ElectricResistanceUnit.Ohm, 67749544.4, ElectricResistanceUnit.Milliohm)]
        public void ResistanceConversions(float value1,
                                          ElectricResistanceUnit units1,
                                          float value2,
                                          ElectricResistanceUnit units2) {
            new ElectricResistance(value1, units1).In(units2).Value.ShouldBe(value2);
            new ElectricResistance(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}