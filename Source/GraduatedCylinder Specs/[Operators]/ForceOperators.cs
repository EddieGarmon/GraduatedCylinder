using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class ForceOperators
    {
        [Fact]
        public void OpAddition() {
            var force1 = new Force(9.81, ForceUnit.Newtons);
            var force2 = new Force(1, ForceUnit.KilogramForce);
            var expected = new Force(19.62, ForceUnit.Newtons);
            (force1 + force2).ShouldEqual(expected);
            (force2 + force1).ShouldEqual(expected);
        }

        [Fact]
        public void OpDivision() {
            var force1 = new Force(19.62, ForceUnit.Newtons);
            var force2 = new Force(2, ForceUnit.KilogramForce);
            (force1 / force2).ShouldBeWithinEpsilonOf(1);
            (force2 / force1).ShouldBeWithinEpsilonOf(1);

            (force1 / 2).ShouldEqual(new Force(9.81, ForceUnit.Newtons));
            (force2 / 2).ShouldEqual(new Force(1, ForceUnit.KilogramForce));
        }

        [Fact]
        public void OpEquals() {
            var force1 = new Force(9.81, ForceUnit.Newtons);
            var force2 = new Force(1, ForceUnit.KilogramForce);
            var force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 == force2).ShouldBeTrue();
            (force2 == force1).ShouldBeTrue();
            (force1 == force3).ShouldBeFalse();
            (force3 == force1).ShouldBeFalse();
            force1.Equals(force2)
                  .ShouldBeTrue();
            force1.Equals((object)force2)
                  .ShouldBeTrue();
            force2.Equals(force1)
                  .ShouldBeTrue();
            force2.Equals((object)force1)
                  .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var force1 = new Force(9.81, ForceUnit.Newtons);
            var force2 = new Force(1, ForceUnit.KilogramForce);
            var force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 > force3).ShouldBeFalse();
            (force3 > force1).ShouldBeTrue();
            (force1 > force2).ShouldBeFalse();
            (force2 > force1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var force1 = new Force(9.81, ForceUnit.Newtons);
            var force2 = new Force(1, ForceUnit.KilogramForce);
            var force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 >= force3).ShouldBeFalse();
            (force3 >= force1).ShouldBeTrue();
            (force1 >= force2).ShouldBeTrue();
            (force2 >= force1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var force1 = new Force(9.81, ForceUnit.Newtons);
            var force2 = new Force(1, ForceUnit.KilogramForce);
            var force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 != force2).ShouldBeFalse();
            (force2 != force1).ShouldBeFalse();
            (force1 != force3).ShouldBeTrue();
            (force3 != force1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var force1 = new Force(9.81, ForceUnit.Newtons);
            var force2 = new Force(1, ForceUnit.KilogramForce);
            var force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 < force3).ShouldBeTrue();
            (force3 < force1).ShouldBeFalse();
            (force1 < force2).ShouldBeFalse();
            (force2 < force1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var force1 = new Force(9.81, ForceUnit.Newtons);
            var force2 = new Force(1, ForceUnit.KilogramForce);
            var force3 = new Force(2, ForceUnit.KilogramForce);
            (force1 <= force3).ShouldBeTrue();
            (force3 <= force1).ShouldBeFalse();
            (force1 <= force2).ShouldBeTrue();
            (force2 <= force1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var force = new Force(1, ForceUnit.KilogramForce);
            var expected = new Force(2, ForceUnit.KilogramForce);
            (force * 2).ShouldEqual(expected);
            (2 * force).ShouldEqual(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var force1 = new Force(19.62, ForceUnit.Newtons);
            var force2 = new Force(1, ForceUnit.KilogramForce);
            (force1 - force2).ShouldEqual(new Force(9.81, ForceUnit.Newtons));
            (force2 - force1).ShouldEqual(new Force(-1, ForceUnit.KilogramForce));
        }
    }
}