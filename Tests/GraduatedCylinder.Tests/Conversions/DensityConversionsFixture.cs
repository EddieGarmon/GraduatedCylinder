using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Conversions;

public class DensityConversionsFixture
{

    [Theory]
    [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 0.20025, MassDensityUnit.GramsPerCubicCentimeter)]
    [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 200.25, MassDensityUnit.GramsPerLiter)]
    [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 0.20025, MassDensityUnit.GramsPerMilliliter)]
    [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 0.20025, MassDensityUnit.KilogramsPerLiter)]
    [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 12.501199397220569788749394995013, MassDensityUnit.PoundsPerCubicFeet)]
    [InlineData(345.65, MassDensityUnit.KilogramsPerLiter, 21578.2245, MassDensityUnit.PoundsPerCubicFeet)]
    [InlineData(725.96, MassDensityUnit.PoundsPerCubicFeet, 11.62876339948, MassDensityUnit.KilogramsPerLiter)]
    public void DensityConversions(double value1, MassDensityUnit units1, double value2, MassDensityUnit units2) {
        new MassDensity(value1, units1).In(units2).ShouldBe(new MassDensity(value2, units2));
        new MassDensity(value2, units2).In(units1).ShouldBe(new MassDensity(value1, units1));
    }

}