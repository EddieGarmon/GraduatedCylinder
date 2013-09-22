using Xunit.Theories;

namespace GraduatedCylinder
{
    public class AngularAccelerationConversionsFixture
    {
        [Theory]
        [InlineData(36.75, AngularAccelerationUnit.RevolutionsPerMinutePerSecond, 0.6125,
            AngularAccelerationUnit.RevolutionsPerSecondSquared)]
        public void AngularAccelerationConversions(double value1,
                                                   AngularAccelerationUnit units1,
                                                   double value2,
                                                   AngularAccelerationUnit units2) {
            new AngularAcceleration(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
            new AngularAcceleration(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}