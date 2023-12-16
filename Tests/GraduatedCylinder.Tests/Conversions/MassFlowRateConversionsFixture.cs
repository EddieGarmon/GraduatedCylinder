#if GraduatedCylinder
namespace GraduatedCylinder.Conversions;
#endif
#if Pipette
namespace Pipette.Conversions;
#endif

public class MassFlowRateConversionsFixture
{

    [Theory]
    [InlineData(1550.0031, MassFlowRateUnit.KiloGramsPerSecond, 3417.171898196, MassFlowRateUnit.PoundsPerSecond)]
    [InlineData(1550.0031, MassFlowRateUnit.KiloGramsPerSecond, 93000.186, MassFlowRateUnit.KiloGramsPerMinute)]
    [InlineData(1550.0031, MassFlowRateUnit.KiloGramsPerSecond, 5580011.16, MassFlowRateUnit.KiloGramsPerHour)]
    [InlineData(1550.0031, MassFlowRateUnit.KiloGramsPerSecond, 1550003.1, MassFlowRateUnit.GramsPerSecond)]
    public void MassFlowRateConversions(double value1, MassFlowRateUnit units1, double value2, MassFlowRateUnit units2) {
        new MassFlowRate(value1, units1).In(units2).ShouldBe(new MassFlowRate(value2, units2));
        new MassFlowRate(value2, units2).In(units1).ShouldBe(new MassFlowRate(value1, units1));
    }

}