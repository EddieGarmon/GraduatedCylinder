using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class MassOperators
    {
        [Fact]
        public void OpAddition() {
            Mass mass1 = new Mass(2000, MassUnit.Grams);
            Mass mass2 = new Mass(1, MassUnit.Kilograms);
            Mass expected = new Mass(3000, MassUnit.Grams);
            (mass1 + mass2).ShouldEqual(expected, UnitAndValueComparers.Mass);
            expected.Units = MassUnit.Kilograms;
            (mass2 + mass1).ShouldEqual(expected, UnitAndValueComparers.Mass);
        }

        [Fact]
        public void OpDivision() {
            Mass mass1 = new Mass(2000, MassUnit.Grams);
            Mass mass2 = new Mass(2, MassUnit.Kilograms);
            (mass1 / mass2).ShouldBeWithinEpsilonOf(1);
            (mass2 / mass1).ShouldBeWithinEpsilonOf(1);

            (mass1 / 2).ShouldEqual(new Mass(1000, MassUnit.Grams));
            (mass2 / 2).ShouldEqual(new Mass(1, MassUnit.Kilograms));
        }

        [Fact]
        public void OpEquals() {
            Mass mass1 = new Mass(3000, MassUnit.Grams);
            Mass mass2 = new Mass(3, MassUnit.Kilograms);
            Mass mass3 = new Mass(4, MassUnit.Kilograms);
            (mass1 == mass2).ShouldBeTrue();
            (mass2 == mass1).ShouldBeTrue();
            (mass1 == mass3).ShouldBeFalse();
            (mass3 == mass1).ShouldBeFalse();
            mass1.Equals(mass2).ShouldBeTrue();
            mass1.Equals((object)mass2).ShouldBeTrue();
            mass2.Equals(mass1).ShouldBeTrue();
            mass2.Equals((object)mass1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            Mass mass1 = new Mass(3000, MassUnit.Grams);
            Mass mass2 = new Mass(3, MassUnit.Kilograms);
            Mass mass3 = new Mass(4, MassUnit.Kilograms);
            (mass1 > mass3).ShouldBeFalse();
            (mass3 > mass1).ShouldBeTrue();
            (mass1 > mass2).ShouldBeFalse();
            (mass2 > mass1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Mass mass1 = new Mass(3000, MassUnit.Grams);
            Mass mass2 = new Mass(3, MassUnit.Kilograms);
            Mass mass3 = new Mass(4, MassUnit.Kilograms);
            (mass1 >= mass3).ShouldBeFalse();
            (mass3 >= mass1).ShouldBeTrue();
            (mass1 >= mass2).ShouldBeTrue();
            (mass2 >= mass1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Mass mass1 = new Mass(3000, MassUnit.Grams);
            Mass mass2 = new Mass(3, MassUnit.Kilograms);
            Mass mass3 = new Mass(4, MassUnit.Kilograms);
            (mass1 != mass2).ShouldBeFalse();
            (mass2 != mass1).ShouldBeFalse();
            (mass1 != mass3).ShouldBeTrue();
            (mass3 != mass1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Mass mass1 = new Mass(3000, MassUnit.Grams);
            Mass mass2 = new Mass(3, MassUnit.Kilograms);
            Mass mass3 = new Mass(4, MassUnit.Kilograms);
            (mass1 < mass3).ShouldBeTrue();
            (mass3 < mass1).ShouldBeFalse();
            (mass1 < mass2).ShouldBeFalse();
            (mass2 < mass1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Mass mass1 = new Mass(3000, MassUnit.Grams);
            Mass mass2 = new Mass(3, MassUnit.Kilograms);
            Mass mass3 = new Mass(4, MassUnit.Kilograms);
            (mass1 <= mass3).ShouldBeTrue();
            (mass3 <= mass1).ShouldBeFalse();
            (mass1 <= mass2).ShouldBeTrue();
            (mass2 <= mass1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Mass mass = new Mass(1, MassUnit.Kilograms);
            Mass expected = new Mass(2, MassUnit.Kilograms);
            (mass * 2).ShouldEqual(expected, UnitAndValueComparers.Mass);
            (2 * mass).ShouldEqual(expected, UnitAndValueComparers.Mass);
        }

        [Fact]
        public void OpSubtraction() {
            Mass mass1 = new Mass(7000, MassUnit.Grams);
            Mass mass2 = new Mass(1, MassUnit.Kilograms);
            (mass1 - mass2).ShouldEqual(new Mass(6000, MassUnit.Grams), UnitAndValueComparers.Mass);
            (mass2 - mass1).ShouldEqual(new Mass(-6, MassUnit.Kilograms), UnitAndValueComparers.Mass);
        }
    }
}