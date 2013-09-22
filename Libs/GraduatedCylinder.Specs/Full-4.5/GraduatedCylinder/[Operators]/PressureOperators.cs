using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class PressureOperators
    {
        [Fact]
        public void OpAddition() {
            Pressure pressure1 = new Pressure(1000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            Pressure expected = new Pressure(2000, PressureUnit.Pascals);
            (pressure1 + pressure2).ShouldEqual(expected, UnitAndValueComparers.Pressure);
            expected.Units = PressureUnit.KiloPascals;
            (pressure2 + pressure1).ShouldEqual(expected, UnitAndValueComparers.Pressure);
        }

        [Fact]
        public void OpDivision() {
            Pressure pressure1 = new Pressure(4000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(4, PressureUnit.KiloPascals);
            (pressure1 / pressure2).ShouldBeWithinEpsilonOf(1);
            (pressure2 / pressure1).ShouldBeWithinEpsilonOf(1);

            (pressure1 / 2).ShouldEqual(new Pressure(2000, PressureUnit.Pascals));
            (pressure2 / 2).ShouldEqual(new Pressure(2, PressureUnit.KiloPascals));
        }

        [Fact]
        public void OpEquals() {
            Pressure pressure1 = new Pressure(1000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            Pressure pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 == pressure2).ShouldBeTrue();
            (pressure2 == pressure1).ShouldBeTrue();
            (pressure1 == pressure3).ShouldBeFalse();
            (pressure3 == pressure1).ShouldBeFalse();
            pressure1.Equals(pressure2).ShouldBeTrue();
            pressure1.Equals((object)pressure2).ShouldBeTrue();
            pressure2.Equals(pressure1).ShouldBeTrue();
            pressure2.Equals((object)pressure1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            Pressure pressure1 = new Pressure(1000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            Pressure pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 > pressure3).ShouldBeFalse();
            (pressure3 > pressure1).ShouldBeTrue();
            (pressure1 > pressure2).ShouldBeFalse();
            (pressure2 > pressure1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Pressure pressure1 = new Pressure(1000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            Pressure pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 >= pressure3).ShouldBeFalse();
            (pressure3 >= pressure1).ShouldBeTrue();
            (pressure1 >= pressure2).ShouldBeTrue();
            (pressure2 >= pressure1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Pressure pressure1 = new Pressure(1000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            Pressure pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 != pressure2).ShouldBeFalse();
            (pressure2 != pressure1).ShouldBeFalse();
            (pressure1 != pressure3).ShouldBeTrue();
            (pressure3 != pressure1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Pressure pressure1 = new Pressure(1000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            Pressure pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 < pressure3).ShouldBeTrue();
            (pressure3 < pressure1).ShouldBeFalse();
            (pressure1 < pressure2).ShouldBeFalse();
            (pressure2 < pressure1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Pressure pressure1 = new Pressure(1000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            Pressure pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 <= pressure3).ShouldBeTrue();
            (pressure3 <= pressure1).ShouldBeFalse();
            (pressure1 <= pressure2).ShouldBeTrue();
            (pressure2 <= pressure1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Pressure pressure = new Pressure(1, PressureUnit.Pascals);
            Pressure expected = new Pressure(2, PressureUnit.Pascals);
            (pressure * 2).ShouldEqual(expected, UnitAndValueComparers.Pressure);
            (2 * pressure).ShouldEqual(expected, UnitAndValueComparers.Pressure);
        }

        [Fact]
        public void OpSubtraction() {
            Pressure pressure1 = new Pressure(7000, PressureUnit.Pascals);
            Pressure pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            (pressure1 - pressure2).ShouldEqual(new Pressure(6000, PressureUnit.Pascals), UnitAndValueComparers.Pressure);
            (pressure2 - pressure1).ShouldEqual(new Pressure(-6, PressureUnit.KiloPascals), UnitAndValueComparers.Pressure);
        }
    }
}