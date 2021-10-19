using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class TorqueConversionsFixture
    {

        [Theory]
        [InlineData(156.758, TorqueUnit.NewtonMeters, 15.979407, TorqueUnit.KilogramForceMeters)]
        [InlineData(156.789, TorqueUnit.NewtonMeters, 115.641624, TorqueUnit.FootPounds)]
        [InlineData(1678.2539, TorqueUnit.KilogramForceMeters, 12142.98, TorqueUnit.FootPounds)]
        public void TorqueConversions(float value1, TorqueUnit units1, float value2, TorqueUnit units2) {
            new Torque(value1, units1).In(units2).Value.ShouldBe(value2);
            new Torque(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}