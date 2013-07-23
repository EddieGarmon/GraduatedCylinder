using Xunit.Theories;

namespace GraduatedCylinder
{
	public class VoltageConversionsFixture
	{
		[Theory]
		[InlineData(15555.655, VoltageUnit.Volts, 15.555655, VoltageUnit.KiloVolts)]
		[InlineData(15555.655, VoltageUnit.Volts, 15555655, VoltageUnit.MilliVolts)]
		public void VoltageConversions(double value1, VoltageUnit units1, double value2, VoltageUnit units2) {
			new Voltage(value1, units1) {Units = units2}.Value.ShouldBeWithinEpsilonOf(value2);
			new Voltage(value2, units2) {Units = units1}.Value.ShouldBeWithinEpsilonOf(value1);
		}
	}
}