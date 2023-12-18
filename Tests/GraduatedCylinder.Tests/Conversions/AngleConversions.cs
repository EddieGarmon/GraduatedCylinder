using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class AngleConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(75, AngleUnit.Degree, 1.3089969, AngleUnit.Radian)]
    [InlineData(75, AngleUnit.Degree, 1308.99693, AngleUnit.MilliRadian)]
    [InlineData(1, AngleUnit.Degree, 17453.2925199, AngleUnit.MicroRadian)]
    [InlineData(75, AngleUnit.Degree, 83.33333, AngleUnit.Grad)]
    public void Conversions(double value1, AngleUnit units1, double value2, AngleUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Angle(value, unit));
    }

}