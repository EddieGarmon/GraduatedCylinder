using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class AngularAccelerationConversionsFixture
    {

        [Theory]
        [InlineData(36.75,
                    AngularAccelerationUnit.RevolutionsPerMinutePerSecond,
                    0.6125,
                    AngularAccelerationUnit.RevolutionsPerSecondSquared)]
        public void AngularAccelerationConversions(float value1,
                                                   AngularAccelerationUnit units1,
                                                   float value2,
                                                   AngularAccelerationUnit units2) {
            new AngularAcceleration(value1, units1).In(units2).Value.ShouldBe(value2);
            new AngularAcceleration(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}