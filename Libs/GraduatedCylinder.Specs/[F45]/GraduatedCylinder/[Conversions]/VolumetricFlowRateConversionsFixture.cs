using Xunit.Theories;

namespace GraduatedCylinder
{
	public class VolumetricFlowRateConversionsFixture
	{
		[Theory]
		[InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 520755.24, VolumetricFlowRateUnit.LitersPerMinute)]
		[InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 31245314.4, VolumetricFlowRateUnit.LitersPerHour)]
		[InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 8.679254, VolumetricFlowRateUnit.CubicMetersPerSecond)]
		[InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 8254138.8316236086, VolumetricFlowRateUnit.GallonsUsPerHour)]
		[InlineData(8679.254, VolumetricFlowRateUnit.LitersPerSecond, 2292.81634211767, VolumetricFlowRateUnit.GallonsUsPerSecond)]
		public void VolumetricFlowRateConversions(double value1, VolumetricFlowRateUnit units1, double value2, VolumetricFlowRateUnit units2) {
			new VolumetricFlowRate(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new VolumetricFlowRate(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}