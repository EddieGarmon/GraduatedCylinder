using Xunit.Theories;

namespace GraduatedCylinder
{
	public class FrequencyConversionsFixture
	{
		[Theory]
		[InlineData(10.00000662, FrequencyUnit.Hertz, 10.00000662, FrequencyUnit.NumberOfCyclesPerSecond)]
		public void FrequencyConversions(double value1, FrequencyUnit units1, double value2, FrequencyUnit units2) {
			new Frequency(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Frequency(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}