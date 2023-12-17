using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class AngularAccelerationConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(3 * Math.PI, AngularAccelerationUnit.RadiansPerSquareSecond, 1.5, AngularAccelerationUnit.RevolutionsPerSquareSecond)]
    public void Conversions(double value1, AngularAccelerationUnit units1, double value2, AngularAccelerationUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new AngularAcceleration(value, unit));
    }

}