#if IOT
using VALUE = System.Single;
#else
using VALUE = System.Double;
#endif
using Xunit;

namespace GraduatedCylinder.Conversions
{
    public class AngleConversionsFixture
    {

        [Theory]
        [InlineData(75, AngleUnit.Degree, 1.3089969, AngleUnit.Radian)]
        [InlineData(75, AngleUnit.Degree, 1308.99693, AngleUnit.Milliradian)]
        [InlineData(75, AngleUnit.Degree, 1308996.93899, AngleUnit.Microradian)]
        [InlineData(75, AngleUnit.Degree, 83.33333, AngleUnit.Grad)]
        public void AngleConversions(VALUE value1, AngleUnit units1, VALUE value2, AngleUnit units2) {
            new Angle(value1, units1).In(units2).Value.ShouldBeWithinToleranceOf(value2);
            new Angle(value2, units2).In(units1).Value.ShouldBeWithinToleranceOf(value1);
        }

    }
}