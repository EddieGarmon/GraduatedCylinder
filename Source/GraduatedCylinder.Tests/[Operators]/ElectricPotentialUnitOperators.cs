using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder
{
    public class ElectricPotentialUnitOperators
    {
        [Fact]
        public void OpAddition() {
            var voltage1 = new ElectricPotential(3000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(1, ElectricPotentialUnit.Kilovolt);
            var expected = new ElectricPotential(4000, ElectricPotentialUnit.Volt);
            (voltage1 + voltage2).ShouldBe(expected);
            (voltage2 + voltage1).ShouldBe(expected);
        }

        [Fact]
        public void OpDivision() {
            var voltage1 = new ElectricPotential(3000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(3, ElectricPotentialUnit.Kilovolt);
            (voltage1 / voltage2).ShouldBeWithinEpsilonOf(1);
            (voltage2 / voltage1).ShouldBeWithinEpsilonOf(1);

            (voltage1 / 2).ShouldBe(new ElectricPotential(1500, ElectricPotentialUnit.Volt));
            (voltage2 / 2).ShouldBe(new ElectricPotential(1.5, ElectricPotentialUnit.Kilovolt));
        }

        [Fact]
        public void OpEquals() {
            var voltage1 = new ElectricPotential(3000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(3, ElectricPotentialUnit.Kilovolt);
            var voltage3 = new ElectricPotential(10, ElectricPotentialUnit.Kilovolt);
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
            var voltage1 = new ElectricPotential(3000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(3, ElectricPotentialUnit.Kilovolt);
            var voltage3 = new ElectricPotential(10, ElectricPotentialUnit.Kilovolt);
            (voltage1 > voltage3).ShouldBeFalse();
            (voltage3 > voltage1).ShouldBeTrue();
            (voltage1 > voltage2).ShouldBeFalse();
            (voltage2 > voltage1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var voltage1 = new ElectricPotential(3000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(3, ElectricPotentialUnit.Kilovolt);
            var voltage3 = new ElectricPotential(10, ElectricPotentialUnit.Kilovolt);
            (voltage1 >= voltage3).ShouldBeFalse();
            (voltage3 >= voltage1).ShouldBeTrue();
            (voltage1 >= voltage2).ShouldBeTrue();
            (voltage2 >= voltage1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var voltage1 = new ElectricPotential(3000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(3, ElectricPotentialUnit.Kilovolt);
            var voltage3 = new ElectricPotential(10, ElectricPotentialUnit.Kilovolt);
            (voltage1 != voltage2).ShouldBeFalse();
            (voltage2 != voltage1).ShouldBeFalse();
            (voltage1 != voltage3).ShouldBeTrue();
            (voltage3 != voltage1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var voltage1 = new ElectricPotential(3000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(3, ElectricPotentialUnit.Kilovolt);
            var voltage3 = new ElectricPotential(10, ElectricPotentialUnit.Kilovolt);
            (voltage1 < voltage3).ShouldBeTrue();
            (voltage3 < voltage1).ShouldBeFalse();
            (voltage1 < voltage2).ShouldBeFalse();
            (voltage2 < voltage1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var voltage1 = new ElectricPotential(3000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(3, ElectricPotentialUnit.Kilovolt);
            var voltage3 = new ElectricPotential(10, ElectricPotentialUnit.Kilovolt);
            (voltage1 <= voltage3).ShouldBeTrue();
            (voltage3 <= voltage1).ShouldBeFalse();
            (voltage1 <= voltage2).ShouldBeTrue();
            (voltage2 <= voltage1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var voltage = new ElectricPotential(1, ElectricPotentialUnit.Volt);
            var expected = new ElectricPotential(2, ElectricPotentialUnit.Volt);
            (voltage * 2).ShouldBe(expected);
            (2 * voltage).ShouldBe(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var voltage1 = new ElectricPotential(7000, ElectricPotentialUnit.Volt);
            var voltage2 = new ElectricPotential(1, ElectricPotentialUnit.Kilovolt);
            (voltage1 - voltage2).ShouldBe(new ElectricPotential(6000, ElectricPotentialUnit.Volt));
            (voltage2 - voltage1).ShouldBe(new ElectricPotential(-6, ElectricPotentialUnit.Kilovolt));
        }
    }
}