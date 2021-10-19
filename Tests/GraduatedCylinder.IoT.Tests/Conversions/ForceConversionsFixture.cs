using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class ForceConversionsFixture
    {

        [Theory]
        [InlineData(156.758, ForceUnit.Newtons, 15.979407, ForceUnit.KilogramForce)]
        [InlineData(156.789, ForceUnit.Newtons, 35.247585, ForceUnit.PoundForce)]
        [InlineData(1678.254, ForceUnit.PoundForce, 760.9829, ForceUnit.KilogramForce)]
        public void ForceConversions(float value1, ForceUnit units1, float value2, ForceUnit units2) {
            new Force(value1, units1).In(units2).Value.ShouldBe(value2);
            new Force(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}