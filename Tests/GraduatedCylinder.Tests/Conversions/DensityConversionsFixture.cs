using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Conversions;

public class DensityConversionsFixture
{

    [Theory]
    [InlineData(200.25, MassDensityUnit.KiloGramsPerCubicMeter, 0.20025, MassDensityUnit.GramsPerCubicCentiMeter)]
    [InlineData(200.25, MassDensityUnit.KiloGramsPerCubicMeter, 200.25, MassDensityUnit.GramsPerLiter)]
    [InlineData(200.25, MassDensityUnit.KiloGramsPerCubicMeter, 0.20025, MassDensityUnit.GramsPerMilliLiter)]
    [InlineData(200.25, MassDensityUnit.KiloGramsPerCubicMeter, 0.20025, MassDensityUnit.KiloGramsPerLiter)]
    [InlineData(200.25, MassDensityUnit.KiloGramsPerCubicMeter, 12.501199397220569788749394995013, MassDensityUnit.PoundsPerCubicFoot)]
    [InlineData(725.96, MassDensityUnit.PoundsPerCubicFoot, 11.62876339948, MassDensityUnit.KiloGramsPerLiter)]
    public void DensityConversions(double value1, MassDensityUnit units1, double value2, MassDensityUnit units2) {
        new MassDensity(value1, units1).In(units2).ShouldBe(new MassDensity(value2, units2));
        new MassDensity(value2, units2).In(units1).ShouldBe(new MassDensity(value1, units1));
    }

}