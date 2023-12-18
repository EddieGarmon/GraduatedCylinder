using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class AccelerationConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(3.25, AccelerationUnit.MeterPerSquareSecond, 11.7, AccelerationUnit.KiloMeterPerHourPerSecond)]
    [InlineData(3.25, AccelerationUnit.MeterPerSquareSecond, 0.00325, AccelerationUnit.KiloMeterPerSquareSecond)]
    [InlineData(3.25, AccelerationUnit.MeterPerSquareSecond, 7.27004295, AccelerationUnit.MilePerHourPerSecond)]
    [InlineData(4.65, AccelerationUnit.MilePerHourPerSecond, 7.4834496, AccelerationUnit.KiloMeterPerHourPerSecond)]
    [InlineData(6.5, AccelerationUnit.KiloMeterPerHourPerSecond, 4.0389127, AccelerationUnit.MilePerHourPerSecond)]
    public void Conversions(double value1, AccelerationUnit units1, double value2, AccelerationUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Acceleration(value, unit));
    }

}