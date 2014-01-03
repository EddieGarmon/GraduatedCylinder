using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class EnergyOperators
    {
        [Fact]
        public void OpAddition() {
            var energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            var energy2 = new Energy(2, EnergyUnit.Kilojoules);
            var expected = new Energy(4000, EnergyUnit.NewtonMeters);
            (energy1 + energy2).ShouldEqual(expected);
            (energy2 + energy1).ShouldEqual(expected);
        }

        [Fact]
        public void OpDivision() {
            var energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            var energy2 = new Energy(2, EnergyUnit.Kilojoules);
            (energy1 / energy2).ShouldBeWithinEpsilonOf(1);
            (energy2 / energy1).ShouldBeWithinEpsilonOf(1);

            (energy1 / 2).ShouldEqual(new Energy(1000, EnergyUnit.NewtonMeters));
            (energy2 / 2).ShouldEqual(new Energy(1, EnergyUnit.Kilojoules));
        }

        [Fact]
        public void OpEquals() {
            var energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            var energy2 = new Energy(2, EnergyUnit.Kilojoules);
            var energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 == energy2).ShouldBeTrue();
            (energy2 == energy1).ShouldBeTrue();
            (energy1 == energy3).ShouldBeFalse();
            (energy3 == energy1).ShouldBeFalse();
            energy1.Equals(energy2)
                   .ShouldBeTrue();
            energy1.Equals((object)energy2)
                   .ShouldBeTrue();
            energy2.Equals(energy1)
                   .ShouldBeTrue();
            energy2.Equals((object)energy1)
                   .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            var energy2 = new Energy(2, EnergyUnit.Kilojoules);
            var energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 > energy3).ShouldBeFalse();
            (energy3 > energy1).ShouldBeTrue();
            (energy1 > energy2).ShouldBeFalse();
            (energy2 > energy1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            var energy2 = new Energy(2, EnergyUnit.Kilojoules);
            var energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 >= energy3).ShouldBeFalse();
            (energy3 >= energy1).ShouldBeTrue();
            (energy1 >= energy2).ShouldBeTrue();
            (energy2 >= energy1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            var energy2 = new Energy(2, EnergyUnit.Kilojoules);
            var energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 != energy2).ShouldBeFalse();
            (energy2 != energy1).ShouldBeFalse();
            (energy1 != energy3).ShouldBeTrue();
            (energy3 != energy1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            var energy2 = new Energy(2, EnergyUnit.Kilojoules);
            var energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 < energy3).ShouldBeTrue();
            (energy3 < energy1).ShouldBeFalse();
            (energy1 < energy2).ShouldBeFalse();
            (energy2 < energy1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var energy1 = new Energy(2000, EnergyUnit.NewtonMeters);
            var energy2 = new Energy(2, EnergyUnit.Kilojoules);
            var energy3 = new Energy(4000, EnergyUnit.Joules);
            (energy1 <= energy3).ShouldBeTrue();
            (energy3 <= energy1).ShouldBeFalse();
            (energy1 <= energy2).ShouldBeTrue();
            (energy2 <= energy1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var energy = new Energy(1, EnergyUnit.Kilojoules);
            var expected = new Energy(2, EnergyUnit.Kilojoules);
            (energy * 2).ShouldEqual(expected);
            (2 * energy).ShouldEqual(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var energy1 = new Energy(2000, EnergyUnit.Joules);
            var energy2 = new Energy(1, EnergyUnit.Kilojoules);
            (energy1 - energy2).ShouldEqual(new Energy(1000, EnergyUnit.Joules));
            (energy2 - energy1).ShouldEqual(new Energy(-1, EnergyUnit.Kilojoules));
        }
    }
}