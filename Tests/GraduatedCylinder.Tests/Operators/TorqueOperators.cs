using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators
{
    public class TorqueOperators
    {
        [Fact]
        public void OpAddition() {
            var torque1 = new Torque(9.81, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(1, TorqueUnit.KilogramForceMeters);
            var expected = new Torque(19.62, TorqueUnit.NewtonMeters);
            (torque1 + torque2).ShouldBe(expected);
            (torque2 + torque1).ShouldBe(expected);
        }

        [Fact]
        public void OpDivision() {
            var torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            (torque1 / torque2).ShouldBeWithinToleranceOf(1);
            (torque2 / torque1).ShouldBeWithinToleranceOf(1);

            (torque1 / 2).ShouldBe(new Torque(9.81, TorqueUnit.NewtonMeters));
            (torque2 / 2).ShouldBe(new Torque(1, TorqueUnit.KilogramForceMeters));
        }

        [Fact]
        public void OpEquals() {
            var torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            var torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 == torque2).ShouldBeTrue();
            (torque2 == torque1).ShouldBeTrue();
            (torque1 == torque3).ShouldBeFalse();
            (torque3 == torque1).ShouldBeFalse();
            torque1.Equals(torque2).ShouldBeTrue();
            torque1.Equals((object)torque2).ShouldBeTrue();
            torque2.Equals(torque1).ShouldBeTrue();
            torque2.Equals((object)torque1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            var torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 > torque3).ShouldBeFalse();
            (torque3 > torque1).ShouldBeTrue();
            (torque1 > torque2).ShouldBeFalse();
            (torque2 > torque1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            var torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 >= torque3).ShouldBeFalse();
            (torque3 >= torque1).ShouldBeTrue();
            (torque1 >= torque2).ShouldBeTrue();
            (torque2 >= torque1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            var torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 != torque2).ShouldBeFalse();
            (torque2 != torque1).ShouldBeFalse();
            (torque1 != torque3).ShouldBeTrue();
            (torque3 != torque1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            var torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 < torque3).ShouldBeTrue();
            (torque3 < torque1).ShouldBeFalse();
            (torque1 < torque2).ShouldBeFalse();
            (torque2 < torque1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            var torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 <= torque3).ShouldBeTrue();
            (torque3 <= torque1).ShouldBeFalse();
            (torque1 <= torque2).ShouldBeTrue();
            (torque2 <= torque1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var torque = new Torque(1, TorqueUnit.NewtonMeters);
            var expected = new Torque(2, TorqueUnit.NewtonMeters);
            (torque * 2).ShouldBe(expected);
            (2 * torque).ShouldBe(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            var torque2 = new Torque(1, TorqueUnit.KilogramForceMeters);
            (torque1 - torque2).ShouldBe(new Torque(9.81, TorqueUnit.NewtonMeters));
            (torque2 - torque1).ShouldBe(new Torque(-1, TorqueUnit.KilogramForceMeters));
        }
    }
}