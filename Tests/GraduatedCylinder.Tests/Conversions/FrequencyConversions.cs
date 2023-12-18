using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class FrequencyConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(10.00000662, FrequencyUnit.Hertz, 10.00000662, FrequencyUnit.CyclePerSecond)]
    [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 0.2625, FrequencyUnit.Hertz)]
    [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 1.64933614313, FrequencyUnit.RadiansPerSecond)]
    [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 0.2625, FrequencyUnit.RevolutionPerSecond)]
    public void Conversions(double value1, FrequencyUnit units1, double value2, FrequencyUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new Frequency(value, unit));
    }

}