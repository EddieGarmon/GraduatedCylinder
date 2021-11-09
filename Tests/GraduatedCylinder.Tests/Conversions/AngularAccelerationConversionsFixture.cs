#if IOT
using VALUE = System.Single;
#else
using VALUE = System.Double;
#endif
using Xunit;

namespace GraduatedCylinder.Conversions
{
    public class AngularAccelerationConversionsFixture
    {

        [Theory]
        [InlineData(36.75,
                    AngularAccelerationUnit.RevolutionsPerMinutePerSecond,
                    0.6125,
                    AngularAccelerationUnit.RevolutionsPerSecondSquared)]
        public void AngularAccelerationConversions(VALUE value1,
                                                   AngularAccelerationUnit units1,
                                                   VALUE value2,
                                                   AngularAccelerationUnit units2) {
            new AngularAcceleration(value1, units1).In(units2).Value.ShouldBeWithinToleranceOf(value2);
            new AngularAcceleration(value2, units2).In(units1).Value.ShouldBeWithinToleranceOf(value1);
        }

    }
}