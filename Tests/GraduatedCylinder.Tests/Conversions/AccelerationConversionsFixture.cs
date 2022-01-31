using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Conversions;

public class AccelerationConversionsFixture
{

    [Theory]
    [InlineData(3.25, AccelerationUnit.MeterPerSquareSecond, 11.7, AccelerationUnit.KilometerPerHourPerSecond)]
    [InlineData(3.25, AccelerationUnit.MeterPerSquareSecond, 0.00325, AccelerationUnit.KilometerPerSquareSecond)]
    [InlineData(3.25, AccelerationUnit.MeterPerSquareSecond, 7.27004295, AccelerationUnit.MilePerHourPerSecond)]
    [InlineData(4.65, AccelerationUnit.MilePerHourPerSecond, 7.4834496, AccelerationUnit.KilometerPerHourPerSecond)]
    [InlineData(6.5, AccelerationUnit.KilometerPerHourPerSecond, 4.0389127, AccelerationUnit.MilePerHourPerSecond)]
    public void AccelerationConversions(double value1, AccelerationUnit units1, double value2, AccelerationUnit units2) {
        new Acceleration(value1, units1).In(units2).ShouldBe(new Acceleration(value2, units2));
        new Acceleration(value2, units2).In(units1).ShouldBe(new Acceleration(value1, units1));
    }

}