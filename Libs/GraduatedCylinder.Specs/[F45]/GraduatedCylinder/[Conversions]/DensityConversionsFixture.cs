using Xunit.Theories;

namespace GraduatedCylinder
{
	public class DensityConversionsFixture
	{
		[Theory]
		[InlineData(200.25, DensityUnit.KilogramsPerCubicMeter, 0.20025, DensityUnit.GramsPerCubicCentimeter)]
		[InlineData(200.25, DensityUnit.KilogramsPerCubicMeter, 200.25, DensityUnit.GramsPerLiter)]
		[InlineData(200.25, DensityUnit.KilogramsPerCubicMeter, 0.20025, DensityUnit.GramsPerMilliliter)]
		[InlineData(200.25, DensityUnit.KilogramsPerCubicMeter, 0.20025, DensityUnit.KilogramsPerLiter)]
		[InlineData(200.25, DensityUnit.KilogramsPerCubicMeter, 12.501199397220569788749394995013, DensityUnit.PoundsPerCubicFeet)]
		[InlineData(345.65, DensityUnit.KilogramsPerLiter, 21578.225076, DensityUnit.PoundsPerCubicFeet)]
		[InlineData(725.96, DensityUnit.PoundsPerCubicFeet, 11.62876339948, DensityUnit.KilogramsPerLiter)]
		public void DensityConversions(double value1, DensityUnit units1, double value2, DensityUnit units2) {
			new Density(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Density(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}