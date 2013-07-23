using Xunit.Theories;

namespace GraduatedCylinder
{
	public class NumericConversionsFixture
	{
		[Theory]
		[InlineData(0.905, NumericUnit.Empty, 90.5, NumericUnit.Percent)]
		public void NumericConversions(double value1, NumericUnit units1, double value2, NumericUnit units2) {
			new Numeric(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Numeric(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}