using Xunit.Theories;

namespace GraduatedCylinder
{
	public class AccelerationConversionsFixture
	{
		[Theory]
		[InlineData(3.25, AccelerationUnit.MetersPerSecondSquared, 11.7, AccelerationUnit.KilometersPerHourPerSecond)]
		[InlineData(3.25, AccelerationUnit.MetersPerSecondSquared, 0.00325, AccelerationUnit.KilometersPerSecondSquared)]
		[InlineData(3.25, AccelerationUnit.MetersPerSecondSquared, 7.27004295, AccelerationUnit.MilesPerHourPerSecond)]
		[InlineData(4.65, AccelerationUnit.MilesPerHourPerSecond, 7.4834496, AccelerationUnit.KilometersPerHourPerSecond)]
		[InlineData(6.5, AccelerationUnit.KilometersPerHourPerSecond, 4.038912749543, AccelerationUnit.MilesPerHourPerSecond)]
		public void AccelerationConversions(double value1, AccelerationUnit units1, double value2, AccelerationUnit units2) {
			new Acceleration(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Acceleration(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}