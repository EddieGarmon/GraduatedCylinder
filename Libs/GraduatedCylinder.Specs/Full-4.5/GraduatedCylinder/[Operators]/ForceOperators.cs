using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class ForceOperators
    {
        [Fact]
        public void OpAddition() {
            Force force1 = new Force(9.81, ForceUnit.Newtons);
            Force force2 = new Force(1, ForceUnit.KilogramForce);
            Force expected = new Force(19.62, ForceUnit.Newtons);
            (force1 + force2).ShouldEqual(expected, UnitAndValueComparers.Force);
            expected.Units = ForceUnit.KilogramForce;
            (force2 + force1).ShouldEqual(expected, UnitAndValueComparers.Force);
        }

        [Fact]
        public void OpDivision() {
            Force force1 = new Force(19.62, ForceUnit.Newtons);
            Force force2 = new Force(2, ForceUnit.KilogramForce);
            (force1 / force2).ShouldBeWithinEpsilonOf(1);
            (force2 / force1).ShouldBeWithinEpsilonOf(1);

            (force1 / 2).ShouldEqual(new Force(9.81, ForceUnit.Newtons));
            (force2 / 2).ShouldEqual(new Force(1, ForceUnit.KilogramForce));
        }

        [Fact]
        public void OpEquals() {
            Force force1 = new Force(9.81, ForceUnit.Newtons);
            Force force2 = new Force(1, ForceUnit.KilogramForce);
            Force force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 == force2).ShouldBeTrue();
            (force2 == force1).ShouldBeTrue();
            (force1 == force3).ShouldBeFalse();
            (force3 == force1).ShouldBeFalse();
            force1.Equals(force2).ShouldBeTrue();
            force1.Equals((object)force2).ShouldBeTrue();
            force2.Equals(force1).ShouldBeTrue();
            force2.Equals((object)force1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            Force force1 = new Force(9.81, ForceUnit.Newtons);
            Force force2 = new Force(1, ForceUnit.KilogramForce);
            Force force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 > force3).ShouldBeFalse();
            (force3 > force1).ShouldBeTrue();
            (force1 > force2).ShouldBeFalse();
            (force2 > force1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Force force1 = new Force(9.81, ForceUnit.Newtons);
            Force force2 = new Force(1, ForceUnit.KilogramForce);
            Force force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 >= force3).ShouldBeFalse();
            (force3 >= force1).ShouldBeTrue();
            (force1 >= force2).ShouldBeTrue();
            (force2 >= force1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Force force1 = new Force(9.81, ForceUnit.Newtons);
            Force force2 = new Force(1, ForceUnit.KilogramForce);
            Force force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 != force2).ShouldBeFalse();
            (force2 != force1).ShouldBeFalse();
            (force1 != force3).ShouldBeTrue();
            (force3 != force1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Force force1 = new Force(9.81, ForceUnit.Newtons);
            Force force2 = new Force(1, ForceUnit.KilogramForce);
            Force force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 < force3).ShouldBeTrue();
            (force3 < force1).ShouldBeFalse();
            (force1 < force2).ShouldBeFalse();
            (force2 < force1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Force force1 = new Force(9.81, ForceUnit.Newtons);
            Force force2 = new Force(1, ForceUnit.KilogramForce);
            Force force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 <= force3).ShouldBeTrue();
            (force3 <= force1).ShouldBeFalse();
            (force1 <= force2).ShouldBeTrue();
            (force2 <= force1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Force force = new Force(1, ForceUnit.KilogramForce);
            Force expected = new Force(2, ForceUnit.KilogramForce);
            (force * 2).ShouldEqual(expected, UnitAndValueComparers.Force);
            (2 * force).ShouldEqual(expected, UnitAndValueComparers.Force);
        }

        [Fact]
        public void OpSubtraction() {
            Force force1 = new Force(19.62, ForceUnit.Newtons);
            Force force2 = new Force(1, ForceUnit.KilogramForce);
            (force1 - force2).ShouldEqual(new Force(9.81, ForceUnit.Newtons), UnitAndValueComparers.Force);
            (force2 - force1).ShouldEqual(new Force(-1, ForceUnit.KilogramForce), UnitAndValueComparers.Force);
        }
    }
}