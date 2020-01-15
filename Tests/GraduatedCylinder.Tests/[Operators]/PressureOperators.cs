using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder
{
    public class PressureOperators
    {
        [Fact]
        public void OpAddition() {
            var pressure1 = new Pressure(1000, PressureUnit.Pascals);
            var pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            var expected = new Pressure(2000, PressureUnit.Pascals);
            (pressure1 + pressure2).ShouldBe(expected);
            (pressure2 + pressure1).ShouldBe(expected);
        }

        [Fact]
        public void OpDivision() {
            var pressure1 = new Pressure(4000, PressureUnit.Pascals);
            var pressure2 = new Pressure(4, PressureUnit.KiloPascals);
            (pressure1 / pressure2).ShouldBeWithinEpsilonOf(1);
            (pressure2 / pressure1).ShouldBeWithinEpsilonOf(1);

            (pressure1 / 2).ShouldBe(new Pressure(2000, PressureUnit.Pascals));
            (pressure2 / 2).ShouldBe(new Pressure(2, PressureUnit.KiloPascals));
        }

        [Fact]
        public void OpEquals() {
            var pressure1 = new Pressure(1000, PressureUnit.Pascals);
            var pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            var pressure3 = new Pressure(2, PressureUnit.KiloPascals);
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
            var pressure1 = new Pressure(1000, PressureUnit.Pascals);
            var pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            var pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 > pressure3).ShouldBeFalse();
            (pressure3 > pressure1).ShouldBeTrue();
            (pressure1 > pressure2).ShouldBeFalse();
            (pressure2 > pressure1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var pressure1 = new Pressure(1000, PressureUnit.Pascals);
            var pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            var pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 >= pressure3).ShouldBeFalse();
            (pressure3 >= pressure1).ShouldBeTrue();
            (pressure1 >= pressure2).ShouldBeTrue();
            (pressure2 >= pressure1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var pressure1 = new Pressure(1000, PressureUnit.Pascals);
            var pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            var pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 != pressure2).ShouldBeFalse();
            (pressure2 != pressure1).ShouldBeFalse();
            (pressure1 != pressure3).ShouldBeTrue();
            (pressure3 != pressure1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var pressure1 = new Pressure(1000, PressureUnit.Pascals);
            var pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            var pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 < pressure3).ShouldBeTrue();
            (pressure3 < pressure1).ShouldBeFalse();
            (pressure1 < pressure2).ShouldBeFalse();
            (pressure2 < pressure1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var pressure1 = new Pressure(1000, PressureUnit.Pascals);
            var pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            var pressure3 = new Pressure(2, PressureUnit.KiloPascals);
            (pressure1 <= pressure3).ShouldBeTrue();
            (pressure3 <= pressure1).ShouldBeFalse();
            (pressure1 <= pressure2).ShouldBeTrue();
            (pressure2 <= pressure1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var pressure = new Pressure(1, PressureUnit.Pascals);
            var expected = new Pressure(2, PressureUnit.Pascals);
            (pressure * 2).ShouldBe(expected);
            (2 * pressure).ShouldBe(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var pressure1 = new Pressure(7000, PressureUnit.Pascals);
            var pressure2 = new Pressure(1, PressureUnit.KiloPascals);
            (pressure1 - pressure2).ShouldBe(new Pressure(6000, PressureUnit.Pascals));
            (pressure2 - pressure1).ShouldBe(new Pressure(-6, PressureUnit.KiloPascals));
        }
    }
}