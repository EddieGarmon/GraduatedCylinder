using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class EnergyOperators
    {
        [Fact]
        public void OpAddition() {
            Energy energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            Energy energy2 = new Energy(2, EnergyUnit.Kilojoules);
            Energy expected = new Energy(4000, EnergyUnit.NewtonMeters);
            (energy1 + energy2).ShouldEqual(expected, UnitAndValueComparers.Energy);
            expected.Units = EnergyUnit.Kilojoules;
            (energy2 + energy1).ShouldEqual(expected, UnitAndValueComparers.Energy);
        }

        [Fact]
        public void OpDivision() {
            Energy energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            Energy energy2 = new Energy(2, EnergyUnit.Kilojoules);
            (energy1 / energy2).ShouldBeWithinEpsilonOf(1);
            (energy2 / energy1).ShouldBeWithinEpsilonOf(1);

            (energy1 / 2).ShouldEqual(new Energy(1000, EnergyUnit.NewtonMeters));
            (energy2 / 2).ShouldEqual(new Energy(1, EnergyUnit.Kilojoules));
        }

        [Fact]
        public void OpEquals() {
            Energy energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            Energy energy2 = new Energy(2, EnergyUnit.Kilojoules);
            Energy energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 == energy2).ShouldBeTrue();
            (energy2 == energy1).ShouldBeTrue();
            (energy1 == energy3).ShouldBeFalse();
            (energy3 == energy1).ShouldBeFalse();
            energy1.Equals(energy2).ShouldBeTrue();
            energy1.Equals((object)energy2).ShouldBeTrue();
            energy2.Equals(energy1).ShouldBeTrue();
            energy2.Equals((object)energy1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            Energy energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            Energy energy2 = new Energy(2, EnergyUnit.Kilojoules);
            Energy energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 > energy3).ShouldBeFalse();
            (energy3 > energy1).ShouldBeTrue();
            (energy1 > energy2).ShouldBeFalse();
            (energy2 > energy1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Energy energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            Energy energy2 = new Energy(2, EnergyUnit.Kilojoules);
            Energy energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 >= energy3).ShouldBeFalse();
            (energy3 >= energy1).ShouldBeTrue();
            (energy1 >= energy2).ShouldBeTrue();
            (energy2 >= energy1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Energy energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            Energy energy2 = new Energy(2, EnergyUnit.Kilojoules);
            Energy energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 != energy2).ShouldBeFalse();
            (energy2 != energy1).ShouldBeFalse();
            (energy1 != energy3).ShouldBeTrue();
            (energy3 != energy1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Energy energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            Energy energy2 = new Energy(2, EnergyUnit.Kilojoules);
            Energy energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 < energy3).ShouldBeTrue();
            (energy3 < energy1).ShouldBeFalse();
            (energy1 < energy2).ShouldBeFalse();
            (energy2 < energy1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Energy energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            Energy energy2 = new Energy(2, EnergyUnit.Kilojoules);
            Energy energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 <= energy3).ShouldBeTrue();
            (energy3 <= energy1).ShouldBeFalse();
            (energy1 <= energy2).ShouldBeTrue();
            (energy2 <= energy1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Energy energy = new Energy(1, EnergyUnit.Kilojoules);
            Energy expected = new Energy(2, EnergyUnit.Kilojoules);
            (energy * 2).ShouldEqual(expected, UnitAndValueComparers.Energy);
            (2 * energy).ShouldEqual(expected, UnitAndValueComparers.Energy);
        }

        [Fact]
        public void OpSubtraction() {
            Energy energy1 = new Energy(2000, EnergyUnit.Joules);
            Energy energy2 = new Energy(1, EnergyUnit.Kilojoules);
            (energy1 - energy2).ShouldEqual(new Energy(1000, EnergyUnit.Joules), UnitAndValueComparers.Energy);
            (energy2 - energy1).ShouldEqual(new Energy(-1, EnergyUnit.Kilojoules), UnitAndValueComparers.Energy);
        }
    }
}