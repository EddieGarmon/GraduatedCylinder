using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class TorqueOperators
    {
        [Fact]
        public void OpAddition() {
            Torque torque1 = new Torque(9.81, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(1, TorqueUnit.KilogramForceMeters);
            Torque expected = new Torque(19.62, TorqueUnit.NewtonMeters);
            (torque1 + torque2).ShouldEqual(expected, UnitAndValueComparers.Torque);
            expected.Units = TorqueUnit.KilogramForceMeters;
            (torque2 + torque1).ShouldEqual(expected, UnitAndValueComparers.Torque);
        }

        [Fact]
        public void OpDivision() {
            Torque torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            (torque1 / torque2).ShouldBeWithinEpsilonOf(1);
            (torque2 / torque1).ShouldBeWithinEpsilonOf(1);

            (torque1 / 2).ShouldEqual(new Torque(9.81, TorqueUnit.NewtonMeters));
            (torque2 / 2).ShouldEqual(new Torque(1, TorqueUnit.KilogramForceMeters));
        }

        [Fact]
        public void OpEquals() {
            Torque torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            Torque torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
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
            Torque torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            Torque torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 > torque3).ShouldBeFalse();
            (torque3 > torque1).ShouldBeTrue();
            (torque1 > torque2).ShouldBeFalse();
            (torque2 > torque1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Torque torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            Torque torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 >= torque3).ShouldBeFalse();
            (torque3 >= torque1).ShouldBeTrue();
            (torque1 >= torque2).ShouldBeTrue();
            (torque2 >= torque1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Torque torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            Torque torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 != torque2).ShouldBeFalse();
            (torque2 != torque1).ShouldBeFalse();
            (torque1 != torque3).ShouldBeTrue();
            (torque3 != torque1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Torque torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            Torque torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 < torque3).ShouldBeTrue();
            (torque3 < torque1).ShouldBeFalse();
            (torque1 < torque2).ShouldBeFalse();
            (torque2 < torque1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Torque torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(2, TorqueUnit.KilogramForceMeters);
            Torque torque3 = new Torque(3, TorqueUnit.KilogramForceMeters);
            (torque1 <= torque3).ShouldBeTrue();
            (torque3 <= torque1).ShouldBeFalse();
            (torque1 <= torque2).ShouldBeTrue();
            (torque2 <= torque1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Torque torque = new Torque(1, TorqueUnit.NewtonMeters);
            Torque expected = new Torque(2, TorqueUnit.NewtonMeters);
            (torque * 2).ShouldEqual(expected, UnitAndValueComparers.Torque);
            (2 * torque).ShouldEqual(expected, UnitAndValueComparers.Torque);
        }

        [Fact]
        public void OpSubtraction() {
            Torque torque1 = new Torque(19.62, TorqueUnit.NewtonMeters);
            Torque torque2 = new Torque(1, TorqueUnit.KilogramForceMeters);
            (torque1 - torque2).ShouldEqual(new Torque(9.81, TorqueUnit.NewtonMeters), UnitAndValueComparers.Torque);
            (torque2 - torque1).ShouldEqual(new Torque(-1, TorqueUnit.KilogramForceMeters), UnitAndValueComparers.Torque);
        }
    }
}