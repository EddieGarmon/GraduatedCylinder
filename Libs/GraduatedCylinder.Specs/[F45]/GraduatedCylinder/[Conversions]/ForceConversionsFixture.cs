using Xunit.Theories;

namespace GraduatedCylinder
{
	public class ForceConversionsFixture
	{
		[Theory]
		[InlineData(156.758, ForceUnit.Newtons, 15.9794087666, ForceUnit.KilogramForce)]
		[InlineData(156.789, ForceUnit.Newtons, 35.247582178938991326867825781998, ForceUnit.PoundForce)]
		[InlineData(1678.254, ForceUnit.PoundForce, 760.98297735779816513761467889908, ForceUnit.KilogramForce)]
		public void ForceConversions(double value1, ForceUnit units1, double value2, ForceUnit units2) {
			new Force(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Force(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}