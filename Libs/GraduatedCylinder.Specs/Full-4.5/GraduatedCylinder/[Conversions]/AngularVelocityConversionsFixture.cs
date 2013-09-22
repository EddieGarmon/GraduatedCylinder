using Xunit.Theories;

namespace GraduatedCylinder
{
    public class AngularVelocityConversionsFixture
    {
        [Theory]
        [InlineData(15.75, AngularVelocityUnit.RevolutionsPerMinute, 0.2625, AngularVelocityUnit.Hertz)]
        [InlineData(15.75, AngularVelocityUnit.RevolutionsPerMinute, 1.64933614313, AngularVelocityUnit.RadiansPerSecond)]
        [InlineData(15.75, AngularVelocityUnit.RevolutionsPerMinute, 0.2625, AngularVelocityUnit.RevolutionsPerSecond)]
        public void AngularVelocityConversions(double value1, AngularVelocityUnit units1, double value2, AngularVelocityUnit units2) {
            new AngularVelocity(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
            new AngularVelocity(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}