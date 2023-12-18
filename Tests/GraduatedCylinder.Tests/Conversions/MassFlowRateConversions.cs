using Xunit.Abstractions;

#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class MassFlowRateConversions(ITestOutputHelper output) : ConversionTestBase(output)
{

    [Theory]
    [InlineData(1550.0031, MassFlowRateUnit.KiloGramsPerSecond, 3417.171898196, MassFlowRateUnit.PoundsPerSecond)]
    [InlineData(1550, MassFlowRateUnit.KiloGramsPerSecond, 93000, MassFlowRateUnit.KiloGramsPerMinute)]
    [InlineData(1550.0031, MassFlowRateUnit.KiloGramsPerSecond, 5580011.16, MassFlowRateUnit.KiloGramsPerHour)]
    [InlineData(1550, MassFlowRateUnit.KiloGramsPerSecond, 1550000, MassFlowRateUnit.GramsPerSecond)]
    public void Conversions(double value1, MassFlowRateUnit units1, double value2, MassFlowRateUnit units2) {
        Validate(value1, units1, value2, units2, (value, unit) => new MassFlowRate(value, unit));
    }

}