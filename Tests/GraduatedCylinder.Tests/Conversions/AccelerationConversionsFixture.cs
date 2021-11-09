using Xunit;
#if IOT
using VALUE = System.Single;
#else
using VALUE = System.Double;
#endif

namespace GraduatedCylinder.Conversions
{
    public class AccelerationConversionsFixture
    {

        [Theory]
        [InlineData(3.25, AccelerationUnit.MeterPerSecondSquared, 11.7, AccelerationUnit.KilometerPerHourPerSecond)]
        [InlineData(3.25, AccelerationUnit.MeterPerSecondSquared, 0.00325, AccelerationUnit.KilometerPerSecondSquared)]
        [InlineData(3.25, AccelerationUnit.MeterPerSecondSquared, 7.27004295, AccelerationUnit.MilePerHourPerSecond)]
        [InlineData(4.65, AccelerationUnit.MilePerHourPerSecond, 7.4834496, AccelerationUnit.KilometerPerHourPerSecond)]
        [InlineData(6.5, AccelerationUnit.KilometerPerHourPerSecond, 4.0389127, AccelerationUnit.MilePerHourPerSecond)]
        public void AccelerationConversions(VALUE value1,
                                            AccelerationUnit units1,
                                            VALUE value2,
                                            AccelerationUnit units2) {
            new Acceleration(value1, units1).In(units2).Value.ShouldBeWithinToleranceOf(value2);
            new Acceleration(value2, units2).In(units1).Value.ShouldBeWithinToleranceOf(value1);
        }

    }
}