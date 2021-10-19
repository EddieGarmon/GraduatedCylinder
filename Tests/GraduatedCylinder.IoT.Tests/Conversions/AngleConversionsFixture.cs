using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class AngleConversionsFixture
    {

        [Theory]
        [InlineData(75, AngleUnit.Degree, 1.3089968, AngleUnit.Radian)]
        [InlineData(75, AngleUnit.Degree, 1308.9967, AngleUnit.Milliradian)]
        [InlineData(75, AngleUnit.Degree, 1308996.8, AngleUnit.Microradian)]
        [InlineData(75, AngleUnit.Degree, 83.33334, AngleUnit.Grad)]
        public void AngleConversions(float value1, AngleUnit units1, float value2, AngleUnit units2) {
            new Angle(value1, units1).In(units2).Value.ShouldBe(value2);
            new Angle(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}