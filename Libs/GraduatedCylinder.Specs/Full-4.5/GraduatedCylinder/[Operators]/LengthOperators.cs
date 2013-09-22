using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class LengthOperators
    {
        [Fact]
        public void OpAddition() {
            Length length1 = new Length(5000, LengthUnit.Meters);
            Length length2 = new Length(2, LengthUnit.Kilometers);
            Length expected = new Length(7000, LengthUnit.Meters);
            (length1 + length2).ShouldEqual(expected, UnitAndValueComparers.Length);
            expected.Units = LengthUnit.Kilometers;
            (length2 + length1).ShouldEqual(expected, UnitAndValueComparers.Length);
        }

        [Fact]
        public void OpDivision() {
            Length length1 = new Length(4000, LengthUnit.Meters);
            Length length2 = new Length(4, LengthUnit.Kilometers);
            (length1 / length2).ShouldBeWithinEpsilonOf(1);
            (length2 / length1).ShouldBeWithinEpsilonOf(1);

            (length1 / 2).ShouldEqual(new Length(2000, LengthUnit.Meters));
            (length2 / 2).ShouldEqual(new Length(2, LengthUnit.Kilometers));
        }

        [Fact]
        public void OpEquals() {
            Length length1 = new Length(3000, LengthUnit.Meters);
            Length length2 = new Length(3, LengthUnit.Kilometers);
            Length length3 = new Length(4, LengthUnit.Kilometers);
            (length1 == length2).ShouldBeTrue();
            (length2 == length1).ShouldBeTrue();
            (length1 == length3).ShouldBeFalse();
            (length3 == length1).ShouldBeFalse();
            length1.Equals(length2).ShouldBeTrue();
            length1.Equals((object)length2).ShouldBeTrue();
            length2.Equals(length1).ShouldBeTrue();
            length2.Equals((object)length1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            Length length1 = new Length(3000, LengthUnit.Meters);
            Length length2 = new Length(3, LengthUnit.Kilometers);
            Length length3 = new Length(4, LengthUnit.Kilometers);
            (length1 > length3).ShouldBeFalse();
            (length3 > length1).ShouldBeTrue();
            (length1 > length2).ShouldBeFalse();
            (length2 > length1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Length length1 = new Length(3000, LengthUnit.Meters);
            Length length2 = new Length(3, LengthUnit.Kilometers);
            Length length3 = new Length(4, LengthUnit.Kilometers);
            (length1 >= length3).ShouldBeFalse();
            (length3 >= length1).ShouldBeTrue();
            (length1 >= length2).ShouldBeTrue();
            (length2 >= length1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Length length1 = new Length(3000, LengthUnit.Meters);
            Length length2 = new Length(3, LengthUnit.Kilometers);
            Length length3 = new Length(4, LengthUnit.Kilometers);
            (length1 != length2).ShouldBeFalse();
            (length2 != length1).ShouldBeFalse();
            (length1 != length3).ShouldBeTrue();
            (length3 != length1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Length length1 = new Length(3000, LengthUnit.Meters);
            Length length2 = new Length(3, LengthUnit.Kilometers);
            Length length3 = new Length(4, LengthUnit.Kilometers);
            (length1 < length3).ShouldBeTrue();
            (length3 < length1).ShouldBeFalse();
            (length1 < length2).ShouldBeFalse();
            (length2 < length1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Length length1 = new Length(3000, LengthUnit.Meters);
            Length length2 = new Length(3, LengthUnit.Kilometers);
            Length length3 = new Length(4, LengthUnit.Kilometers);
            (length1 <= length3).ShouldBeTrue();
            (length3 <= length1).ShouldBeFalse();
            (length1 <= length2).ShouldBeTrue();
            (length2 <= length1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Length length = new Length(1, LengthUnit.Kilometers);
            Length expected = new Length(2, LengthUnit.Kilometers);
            (length * 2).ShouldEqual(expected, UnitAndValueComparers.Length);
            (2 * length).ShouldEqual(expected, UnitAndValueComparers.Length);
        }

        [Fact]
        public void OpSubtraction() {
            Length length1 = new Length(7000, LengthUnit.Meters);
            Length length2 = new Length(1, LengthUnit.Kilometers);
            (length1 - length2).ShouldEqual(new Length(6000, LengthUnit.Meters), UnitAndValueComparers.Length);
            (length2 - length1).ShouldEqual(new Length(-6, LengthUnit.Kilometers), UnitAndValueComparers.Length);
        }
    }
}