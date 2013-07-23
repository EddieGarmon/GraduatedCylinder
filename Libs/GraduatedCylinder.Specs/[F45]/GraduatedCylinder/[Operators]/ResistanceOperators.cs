using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
	public class ElectricResistanceOperators
	{
		[Fact]
		public void OpAddition() {
			Resistance resistance1 = new Resistance(3000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(1, ResistanceUnit.KiloOhms);
			Resistance expected = new Resistance(4000, ResistanceUnit.Ohms);
			(resistance1 + resistance2).ShouldEqual(expected, UnitAndValueComparers.ElectricResistance);
			expected.Units = ResistanceUnit.KiloOhms;
			(resistance2 + resistance1).ShouldEqual(expected, UnitAndValueComparers.ElectricResistance);
		}

		[Fact]
		public void OpDivision() {
			Resistance resistance1 = new Resistance(2000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(2, ResistanceUnit.KiloOhms);
			(resistance1 / resistance2).ShouldBeWithinEpsilonOf(1);
			(resistance2 / resistance1).ShouldBeWithinEpsilonOf(1);

			(resistance1 / 2).ShouldEqual(new Resistance(1000, ResistanceUnit.Ohms));
			(resistance2 / 2).ShouldEqual(new Resistance(1, ResistanceUnit.KiloOhms));
		}

		[Fact]
		public void OpEquals() {
			Resistance resistance1 = new Resistance(3000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(3, ResistanceUnit.KiloOhms);
			Resistance resistance3 = new Resistance(4, ResistanceUnit.KiloOhms);
			(resistance1 == resistance2).ShouldBeTrue();
			(resistance2 == resistance1).ShouldBeTrue();
			(resistance1 == resistance3).ShouldBeFalse();
			(resistance3 == resistance1).ShouldBeFalse();
			resistance1.Equals(resistance2).ShouldBeTrue();
			resistance1.Equals((object)resistance2).ShouldBeTrue();
			resistance2.Equals(resistance1).ShouldBeTrue();
			resistance2.Equals((object)resistance1).ShouldBeTrue();
		}

		[Fact]
		public void OpGreaterThan() {
			Resistance resistance1 = new Resistance(3000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(3, ResistanceUnit.KiloOhms);
			Resistance resistance3 = new Resistance(4, ResistanceUnit.KiloOhms);
			(resistance1 > resistance3).ShouldBeFalse();
			(resistance3 > resistance1).ShouldBeTrue();
			(resistance1 > resistance2).ShouldBeFalse();
			(resistance2 > resistance1).ShouldBeFalse();
		}

		[Fact]
		public void OpGreaterThanOrEqual() {
			Resistance resistance1 = new Resistance(3000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(3, ResistanceUnit.KiloOhms);
			Resistance resistance3 = new Resistance(4, ResistanceUnit.KiloOhms);
			(resistance1 >= resistance3).ShouldBeFalse();
			(resistance3 >= resistance1).ShouldBeTrue();
			(resistance1 >= resistance2).ShouldBeTrue();
			(resistance2 >= resistance1).ShouldBeTrue();
		}

		[Fact]
		public void OpInverseEquals() {
			Resistance resistance1 = new Resistance(3000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(3, ResistanceUnit.KiloOhms);
			Resistance resistance3 = new Resistance(4, ResistanceUnit.KiloOhms);
			(resistance1 != resistance2).ShouldBeFalse();
			(resistance2 != resistance1).ShouldBeFalse();
			(resistance1 != resistance3).ShouldBeTrue();
			(resistance3 != resistance1).ShouldBeTrue();
		}

		[Fact]
		public void OpLessThan() {
			Resistance resistance1 = new Resistance(3000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(3, ResistanceUnit.KiloOhms);
			Resistance resistance3 = new Resistance(4, ResistanceUnit.KiloOhms);
			(resistance1 < resistance3).ShouldBeTrue();
			(resistance3 < resistance1).ShouldBeFalse();
			(resistance1 < resistance2).ShouldBeFalse();
			(resistance2 < resistance1).ShouldBeFalse();
		}

		[Fact]
		public void OpLessThanOrEqual() {
			Resistance resistance1 = new Resistance(3000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(3, ResistanceUnit.KiloOhms);
			Resistance resistance3 = new Resistance(4, ResistanceUnit.KiloOhms);
			(resistance1 <= resistance3).ShouldBeTrue();
			(resistance3 <= resistance1).ShouldBeFalse();
			(resistance1 <= resistance2).ShouldBeTrue();
			(resistance2 <= resistance1).ShouldBeTrue();
		}

		[Fact]
		public void OpMultiplicationScaler() {
			Resistance resistance = new Resistance(1, ResistanceUnit.Ohms);
			Resistance expected = new Resistance(2, ResistanceUnit.Ohms);
			(resistance * 2).ShouldEqual(expected, UnitAndValueComparers.ElectricResistance);
			(2 * resistance).ShouldEqual(expected, UnitAndValueComparers.ElectricResistance);
		}

		[Fact]
		public void OpSubtraction() {
			Resistance resistance1 = new Resistance(7000, ResistanceUnit.Ohms);
			Resistance resistance2 = new Resistance(1, ResistanceUnit.KiloOhms);
			(resistance1 - resistance2).ShouldEqual(new Resistance(6000, ResistanceUnit.Ohms), UnitAndValueComparers.ElectricResistance);
			(resistance2 - resistance1).ShouldEqual(new Resistance(-6, ResistanceUnit.KiloOhms), UnitAndValueComparers.ElectricResistance);
		}
	}
}