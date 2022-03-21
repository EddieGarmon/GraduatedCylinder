using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Conversions;

public class FrequencyConversionsFixture
{

    [Theory]
    [InlineData(10.00000662, FrequencyUnit.Hertz, 10.00000662, FrequencyUnit.CyclePerSecond)]
    [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 0.2625, FrequencyUnit.Hertz)]
    [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 1.64933614313, FrequencyUnit.RadiansPerSecond)]
    [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 0.2625, FrequencyUnit.RevolutionPerSecond)]
    public void FrequencyConversions(double value1, FrequencyUnit units1, double value2, FrequencyUnit units2) {
        new Frequency(value1, units1).In(units2).ShouldBe(new Frequency(value2, units2));
        new Frequency(value2, units2).In(units1).ShouldBe(new Frequency(value1, units1));
    }

}