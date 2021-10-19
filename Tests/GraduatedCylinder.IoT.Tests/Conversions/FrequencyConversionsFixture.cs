using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class FrequencyConversionsFixture
    {

        [Theory]
        [InlineData(10.00000662, FrequencyUnit.Hertz, 10.00000662, FrequencyUnit.CyclePerSecond)]
        [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 0.26250005, FrequencyUnit.Hertz)]
        [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 1.6493368, FrequencyUnit.RadiansPerSecond)]
        [InlineData(15.75, FrequencyUnit.RevolutionsPerMinute, 0.26250005, FrequencyUnit.RevolutionPerSecond)]
        public void FrequencyConversions(float value1, FrequencyUnit units1, float value2, FrequencyUnit units2) {
            new Frequency(value1, units1).In(units2).Value.ShouldBe(value2);
            new Frequency(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}