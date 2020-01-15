using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder
{
    public class ElectricCurrentOperators
    {
        [Fact]
        public void OpAddition() {
            var current1 = new ElectricCurrent(3000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(1, ElectricCurrentUnit.KiloAmpere);
            var expected = new ElectricCurrent(4000, ElectricCurrentUnit.Ampere);
            (current1 + current2).ShouldBe(expected);
            (current2 + current1).ShouldBe(expected);
        }

        [Fact]
        public void OpDivision() {
            var current1 = new ElectricCurrent(2000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(2, ElectricCurrentUnit.KiloAmpere);
            (current1 / current2).ShouldBeWithinEpsilonOf(1);
            (current2 / current1).ShouldBeWithinEpsilonOf(1);

            (current1 / 2).ShouldBe(new ElectricCurrent(1000, ElectricCurrentUnit.Ampere));
            (current2 / 2).ShouldBe(new ElectricCurrent(1, ElectricCurrentUnit.KiloAmpere));
        }

        [Fact]
        public void OpEquals() {
            var current1 = new ElectricCurrent(3000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(3, ElectricCurrentUnit.KiloAmpere);
            var current3 = new ElectricCurrent(6, ElectricCurrentUnit.KiloAmpere);
            (current1 == current2).ShouldBeTrue();
            (current2 == current1).ShouldBeTrue();
            (current1 == current3).ShouldBeFalse();
            (current3 == current1).ShouldBeFalse();
            current1.Equals(current2).ShouldBeTrue();
            current1.Equals((object)current2).ShouldBeTrue();
            current2.Equals(current1).ShouldBeTrue();
            current2.Equals((object)current1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var current1 = new ElectricCurrent(3000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(3, ElectricCurrentUnit.KiloAmpere);
            var current3 = new ElectricCurrent(6, ElectricCurrentUnit.KiloAmpere);
            (current1 > current3).ShouldBeFalse();
            (current3 > current1).ShouldBeTrue();
            (current1 > current2).ShouldBeFalse();
            (current2 > current1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var current1 = new ElectricCurrent(3000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(3, ElectricCurrentUnit.KiloAmpere);
            var current3 = new ElectricCurrent(6, ElectricCurrentUnit.KiloAmpere);
            (current1 >= current3).ShouldBeFalse();
            (current3 >= current1).ShouldBeTrue();
            (current1 >= current2).ShouldBeTrue();
            (current2 >= current1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var current1 = new ElectricCurrent(3000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(3, ElectricCurrentUnit.KiloAmpere);
            var current3 = new ElectricCurrent(6, ElectricCurrentUnit.KiloAmpere);
            (current1 != current2).ShouldBeFalse();
            (current2 != current1).ShouldBeFalse();
            (current1 != current3).ShouldBeTrue();
            (current3 != current1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var current1 = new ElectricCurrent(3000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(3, ElectricCurrentUnit.KiloAmpere);
            var current3 = new ElectricCurrent(6, ElectricCurrentUnit.KiloAmpere);
            (current1 < current3).ShouldBeTrue();
            (current3 < current1).ShouldBeFalse();
            (current1 < current2).ShouldBeFalse();
            (current2 < current1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var current1 = new ElectricCurrent(3000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(3, ElectricCurrentUnit.KiloAmpere);
            var current3 = new ElectricCurrent(6, ElectricCurrentUnit.KiloAmpere);
            (current1 <= current3).ShouldBeTrue();
            (current3 <= current1).ShouldBeFalse();
            (current1 <= current2).ShouldBeTrue();
            (current2 <= current1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var current = new ElectricCurrent(1, ElectricCurrentUnit.Ampere);
            var expected = new ElectricCurrent(2, ElectricCurrentUnit.Ampere);
            (current * 2).ShouldBe(expected);
            (2 * current).ShouldBe(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var current1 = new ElectricCurrent(7000, ElectricCurrentUnit.Ampere);
            var current2 = new ElectricCurrent(1, ElectricCurrentUnit.KiloAmpere);
            (current1 - current2).ShouldBe(new ElectricCurrent(6000, ElectricCurrentUnit.Ampere));
            (current2 - current1).ShouldBe(new ElectricCurrent(-6, ElectricCurrentUnit.KiloAmpere));
        }
    }
}