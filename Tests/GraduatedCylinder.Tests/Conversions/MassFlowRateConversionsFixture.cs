using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Conversions;

public class MassFlowRateConversionsFixture
{

    [Theory]
    [InlineData(1550.0031, MassFlowRateUnit.KilogramsPerSecond, 3417.171898196, MassFlowRateUnit.PoundsPerSecond)]
    [InlineData(1550.0031, MassFlowRateUnit.KilogramsPerSecond, 93000.186, MassFlowRateUnit.KilogramsPerMinute)]
    [InlineData(1550.0031, MassFlowRateUnit.KilogramsPerSecond, 5580011.16, MassFlowRateUnit.KilogramsPerHour)]
    [InlineData(1550.0031, MassFlowRateUnit.KilogramsPerSecond, 1550003.1, MassFlowRateUnit.GramsPerSecond)]
    public void MassFlowRateConversions(double value1, MassFlowRateUnit units1, double value2, MassFlowRateUnit units2) {
        new MassFlowRate(value1, units1).In(units2).ShouldBe(new MassFlowRate(value2, units2));
        new MassFlowRate(value2, units2).In(units1).ShouldBe(new MassFlowRate(value1, units1));
    }

}