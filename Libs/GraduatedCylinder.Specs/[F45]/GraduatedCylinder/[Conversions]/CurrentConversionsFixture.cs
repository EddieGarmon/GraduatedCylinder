using Xunit.Theories;

namespace GraduatedCylinder
{
	public class CurrentConversionsFixture
	{
		[Theory]
		[InlineData(45553.6666, CurrentUnit.Amperes, 45.5536666, CurrentUnit.KiloAmperes)]
		[InlineData(45553.6666, CurrentUnit.Amperes, 45553666.6, CurrentUnit.Milliamperes)]
		public void CurrentConversions(double value1, CurrentUnit units1, double value2, CurrentUnit units2) {
			new Current(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Current(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}