using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class VoltageOperators
	{
		[Fact]
		public void OpAddition() {
			Voltage voltage1 = new Voltage(3000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(1, VoltageUnit.KiloVolts);
			Voltage expected = new Voltage(4000, VoltageUnit.Volts);
			(voltage1 + voltage2).ShouldEqual(expected, UnitAndValueComparers.Voltage);
			expected.Units = VoltageUnit.KiloVolts;
			(voltage2 + voltage1).ShouldEqual(expected, UnitAndValueComparers.Voltage);
		}

		[Fact]
		public void OpDivision() {
			Voltage voltage1 = new Voltage(3000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(3, VoltageUnit.KiloVolts);
			(voltage1 / voltage2).ShouldBeWithinEpsilonOf(1);
			(voltage2 / voltage1).ShouldBeWithinEpsilonOf(1);

			(voltage1 / 2).ShouldEqual(new Voltage(1500, VoltageUnit.Volts));
			(voltage2 / 2).ShouldEqual(new Voltage(1.5, VoltageUnit.KiloVolts));
		}

		[Fact]
		public void OpEquals() {
			Voltage voltage1 = new Voltage(3000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(3, VoltageUnit.KiloVolts);
			Voltage voltage3 = new Voltage(10, VoltageUnit.KiloVolts);
			(voltage1 == voltage2).ShouldBeTrue();
			(voltage2 == voltage1).ShouldBeTrue();
			(voltage1 == voltage3).ShouldBeFalse();
			(voltage3 == voltage1).ShouldBeFalse();
			voltage1.Equals(voltage2).ShouldBeTrue();
			voltage1.Equals((object)voltage2).ShouldBeTrue();
			voltage2.Equals(voltage1).ShouldBeTrue();
			voltage2.Equals((object)voltage1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			Voltage voltage1 = new Voltage(3000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(3, VoltageUnit.KiloVolts);
			Voltage voltage3 = new Voltage(10, VoltageUnit.KiloVolts);
			(voltage1 > voltage3).ShouldBeFalse();
			(voltage3 > voltage1).ShouldBeTrue();
			(voltage1 > voltage2).ShouldBeFalse();
			(voltage2 > voltage1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			Voltage voltage1 = new Voltage(3000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(3, VoltageUnit.KiloVolts);
			Voltage voltage3 = new Voltage(10, VoltageUnit.KiloVolts);
			(voltage1 >= voltage3).ShouldBeFalse();
			(voltage3 >= voltage1).ShouldBeTrue();
			(voltage1 >= voltage2).ShouldBeTrue();
			(voltage2 >= voltage1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			Voltage voltage1 = new Voltage(3000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(3, VoltageUnit.KiloVolts);
			Voltage voltage3 = new Voltage(10, VoltageUnit.KiloVolts);
			(voltage1 != voltage2).ShouldBeFalse();
			(voltage2 != voltage1).ShouldBeFalse();
			(voltage1 != voltage3).ShouldBeTrue();
			(voltage3 != voltage1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			Voltage voltage1 = new Voltage(3000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(3, VoltageUnit.KiloVolts);
			Voltage voltage3 = new Voltage(10, VoltageUnit.KiloVolts);
			(voltage1 < voltage3).ShouldBeTrue();
			(voltage3 < voltage1).ShouldBeFalse();
			(voltage1 < voltage2).ShouldBeFalse();
			(voltage2 < voltage1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			Voltage voltage1 = new Voltage(3000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(3, VoltageUnit.KiloVolts);
			Voltage voltage3 = new Voltage(10, VoltageUnit.KiloVolts);
			(voltage1 <= voltage3).ShouldBeTrue();
			(voltage3 <= voltage1).ShouldBeFalse();
			(voltage1 <= voltage2).ShouldBeTrue();
			(voltage2 <= voltage1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			Voltage voltage = new Voltage(1, VoltageUnit.Volts);
			Voltage expected = new Voltage(2, VoltageUnit.Volts);
			(voltage * 2).ShouldEqual(expected, UnitAndValueComparers.Voltage);
			(2 * voltage).ShouldEqual(expected, UnitAndValueComparers.Voltage);
		}

		[Fact]
		public void OpSubtraction() {
			Voltage voltage1 = new Voltage(7000, VoltageUnit.Volts);
			Voltage voltage2 = new Voltage(1, VoltageUnit.KiloVolts);
			(voltage1 - voltage2).ShouldEqual(new Voltage(6000, VoltageUnit.Volts), UnitAndValueComparers.Voltage);
			(voltage2 - voltage1).ShouldEqual(new Voltage(-6, VoltageUnit.KiloVolts), UnitAndValueComparers.Voltage);
		}
	}
}