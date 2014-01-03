using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class MassOperators
    {
        [Fact]
        public void OpAddition() {
            var mass1 = new Mass(2000, MassUnit.Gram);
            var mass2 = new Mass(1, MassUnit.Kilogram);
            var expected = new Mass(3000, MassUnit.Gram);
            (mass1 + mass2).ShouldEqual(expected);
            (mass2 + mass1).ShouldEqual(expected);
        }

        [Fact]
        public void OpDivision() {
            var mass1 = new Mass(2000, MassUnit.Gram);
            var mass2 = new Mass(2, MassUnit.Kilogram);
            (mass1 / mass2).ShouldBeWithinEpsilonOf(1);
            (mass2 / mass1).ShouldBeWithinEpsilonOf(1);

            (mass1 / 2).ShouldEqual(new Mass(1000, MassUnit.Gram));
            (mass2 / 2).ShouldEqual(new Mass(1, MassUnit.Kilogram));
        }

        [Fact]
        public void OpEquals() {
            var mass1 = new Mass(3000, MassUnit.Gram);
            var mass2 = new Mass(3, MassUnit.Kilogram);
            var mass3 = new Mass(4, MassUnit.Kilogram);
            (mass1 == mass2).ShouldBeTrue();
            (mass2 == mass1).ShouldBeTrue();
            (mass1 == mass3).ShouldBeFalse();
            (mass3 == mass1).ShouldBeFalse();
            mass1.Equals(mass2)
                 .ShouldBeTrue();
            mass1.Equals((object)mass2)
                 .ShouldBeTrue();
            mass2.Equals(mass1)
                 .ShouldBeTrue();
            mass2.Equals((object)mass1)
                 .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var mass1 = new Mass(3000, MassUnit.Gram);
            var mass2 = new Mass(3, MassUnit.Kilogram);
            var mass3 = new Mass(4, MassUnit.Kilogram);
            (mass1 > mass3).ShouldBeFalse();
            (mass3 > mass1).ShouldBeTrue();
            (mass1 > mass2).ShouldBeFalse();
            (mass2 > mass1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var mass1 = new Mass(3000, MassUnit.Gram);
            var mass2 = new Mass(3, MassUnit.Kilogram);
            var mass3 = new Mass(4, MassUnit.Kilogram);
            (mass1 >= mass3).ShouldBeFalse();
            (mass3 >= mass1).ShouldBeTrue();
            (mass1 >= mass2).ShouldBeTrue();
            (mass2 >= mass1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var mass1 = new Mass(3000, MassUnit.Gram);
            var mass2 = new Mass(3, MassUnit.Kilogram);
            var mass3 = new Mass(4, MassUnit.Kilogram);
            (mass1 != mass2).ShouldBeFalse();
            (mass2 != mass1).ShouldBeFalse();
            (mass1 != mass3).ShouldBeTrue();
            (mass3 != mass1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var mass1 = new Mass(3000, MassUnit.Gram);
            var mass2 = new Mass(3, MassUnit.Kilogram);
            var mass3 = new Mass(4, MassUnit.Kilogram);
            (mass1 < mass3).ShouldBeTrue();
            (mass3 < mass1).ShouldBeFalse();
            (mass1 < mass2).ShouldBeFalse();
            (mass2 < mass1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var mass1 = new Mass(3000, MassUnit.Gram);
            var mass2 = new Mass(3, MassUnit.Kilogram);
            var mass3 = new Mass(4, MassUnit.Kilogram);
            (mass1 <= mass3).ShouldBeTrue();
            (mass3 <= mass1).ShouldBeFalse();
            (mass1 <= mass2).ShouldBeTrue();
            (mass2 <= mass1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var mass = new Mass(1, MassUnit.Kilogram);
            var expected = new Mass(2, MassUnit.Kilogram);
            (mass * 2).ShouldEqual(expected);
            (2 * mass).ShouldEqual(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var mass1 = new Mass(7000, MassUnit.Gram);
            var mass2 = new Mass(1, MassUnit.Kilogram);
            (mass1 - mass2).ShouldEqual(new Mass(6000, MassUnit.Gram));
            (mass2 - mass1).ShouldEqual(new Mass(-6, MassUnit.Kilogram));
        }
    }
}