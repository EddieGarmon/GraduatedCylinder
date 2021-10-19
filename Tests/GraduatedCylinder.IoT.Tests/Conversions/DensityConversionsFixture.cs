using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.IoT.Tests
{
    public class DensityConversionsFixture
    {

        [Theory]
        [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 0.20025, MassDensityUnit.GramsPerCubicCentimeter)]
        [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 200.25, MassDensityUnit.GramsPerLiter)]
        [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 0.20025, MassDensityUnit.GramsPerMilliliter)]
        [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 0.20025, MassDensityUnit.KilogramsPerLiter)]
        [InlineData(200.25, MassDensityUnit.KilogramsPerCubicMeter, 12.501203, MassDensityUnit.PoundsPerCubicFeet)]
        [InlineData(345.65, MassDensityUnit.KilogramsPerLiter, 21578.23, MassDensityUnit.PoundsPerCubicFeet)]
        [InlineData(725.96, MassDensityUnit.PoundsPerCubicFeet, 11.62876, MassDensityUnit.KilogramsPerLiter)]
        public void DensityConversions(float value1, MassDensityUnit units1, float value2, MassDensityUnit units2) {
            new MassDensity(value1, units1).In(units2).Value.ShouldBe(value2);
            new MassDensity(value2, units2).In(units1).Value.ShouldBe(value1);
        }

    }
}