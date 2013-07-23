using Xunit.Theories;

namespace GraduatedCylinder
{
	public class AngleConversionsFixture
	{
		[Theory]
		[InlineData(4.5, AngleUnit.Degrees, 257831008.103485345243, AngleUnit.MicroRadians)]
		[InlineData(4.5, AngleUnit.Degrees, 257831.0081034853, AngleUnit.MilliRadians)]
		[InlineData(4.5, AngleUnit.Degrees, 257.8310081035, AngleUnit.Radians)]
		[InlineData(75, AngleUnit.Degrees, 83.3333333333333, AngleUnit.Grads)]
		public void AngleConversions(double value1, AngleUnit units1, double value2, AngleUnit units2) {
			new Angle(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Angle(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}