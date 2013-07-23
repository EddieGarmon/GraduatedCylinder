using Xunit.Theories;

namespace GraduatedCylinder
{
	public class ResistanceConversionsFixture
	{
		[Theory]
		[InlineData(67749.5444, ResistanceUnit.Ohms, 67.7495444, ResistanceUnit.KiloOhms)]
		[InlineData(67749.5444, ResistanceUnit.Ohms, 67749544.4, ResistanceUnit.MilliOhms)]
		public void ResistanceConversions(double value1, ResistanceUnit units1, double value2, ResistanceUnit units2) {
			new Resistance(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Resistance(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}