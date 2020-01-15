using Xunit;

namespace GraduatedCylinder
{
    public class AccelerationConversionsFixture
    {
        [Theory]
        [InlineData(3.25, AccelerationUnit.MeterPerSecondSquared, 11.7, AccelerationUnit.KilometerPerHourPerSecond)]
        [InlineData(3.25, AccelerationUnit.MeterPerSecondSquared, 0.00325, AccelerationUnit.KilometerPerSecondSquared)]
        [InlineData(3.25, AccelerationUnit.MeterPerSecondSquared, 7.27004295, AccelerationUnit.MilePerHourPerSecond)]
        [InlineData(4.65, AccelerationUnit.MilePerHourPerSecond, 7.4834496, AccelerationUnit.KilometerPerHourPerSecond)]
        [InlineData(6.5,
                    AccelerationUnit.KilometerPerHourPerSecond,
                    4.038912749543,
                    AccelerationUnit.MilePerHourPerSecond)]
        public void AccelerationConversions(double value1,
                                            AccelerationUnit units1,
                                            double value2,
                                            AccelerationUnit units2) {
            new Acceleration(value1, units1) {
                Units = units2
            }.Value.ShouldBeWithinEpsilonOf(value2);
            new Acceleration(value2, units2) {
                Units = units1
            }.Value.ShouldBeWithinEpsilonOf(value1);
        }
    }
}