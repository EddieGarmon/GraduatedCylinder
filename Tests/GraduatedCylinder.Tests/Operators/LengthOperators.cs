using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators
{
    public class LengthOperators
    {
        [Fact]
        public void OpAddition() {
            var length1 = new Length(5000, LengthUnit.Meter);
            var length2 = new Length(2, LengthUnit.Kilometer);
            var expected = new Length(7000, LengthUnit.Meter);
            (length1 + length2).ShouldBe(expected);
            (length2 + length1).ShouldBe(expected);
        }

        [Fact]
        public void OpDivision() {
            var length1 = new Length(4000, LengthUnit.Meter);
            var length2 = new Length(4, LengthUnit.Kilometer);
            (length1 / length2).ShouldBeWithinToleranceOf(1);
            (length2 / length1).ShouldBeWithinToleranceOf(1);

            (length1 / 2).ShouldBe(new Length(2000, LengthUnit.Meter));
            (length2 / 2).ShouldBe(new Length(2, LengthUnit.Kilometer));
        }

        [Fact]
        public void OpEquals() {
            var length1 = new Length(3000, LengthUnit.Meter);
            var length2 = new Length(3, LengthUnit.Kilometer);
            var length3 = new Length(4, LengthUnit.Kilometer);
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
            var length1 = new Length(3000, LengthUnit.Meter);
            var length2 = new Length(3, LengthUnit.Kilometer);
            var length3 = new Length(4, LengthUnit.Kilometer);
            (length1 > length3).ShouldBeFalse();
            (length3 > length1).ShouldBeTrue();
            (length1 > length2).ShouldBeFalse();
            (length2 > length1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var length1 = new Length(3000, LengthUnit.Meter);
            var length2 = new Length(3, LengthUnit.Kilometer);
            var length3 = new Length(4, LengthUnit.Kilometer);
            (length1 >= length3).ShouldBeFalse();
            (length3 >= length1).ShouldBeTrue();
            (length1 >= length2).ShouldBeTrue();
            (length2 >= length1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var length1 = new Length(3000, LengthUnit.Meter);
            var length2 = new Length(3, LengthUnit.Kilometer);
            var length3 = new Length(4, LengthUnit.Kilometer);
            (length1 != length2).ShouldBeFalse();
            (length2 != length1).ShouldBeFalse();
            (length1 != length3).ShouldBeTrue();
            (length3 != length1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var length1 = new Length(3000, LengthUnit.Meter);
            var length2 = new Length(3, LengthUnit.Kilometer);
            var length3 = new Length(4, LengthUnit.Kilometer);
            (length1 < length3).ShouldBeTrue();
            (length3 < length1).ShouldBeFalse();
            (length1 < length2).ShouldBeFalse();
            (length2 < length1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var length1 = new Length(3000, LengthUnit.Meter);
            var length2 = new Length(3, LengthUnit.Kilometer);
            var length3 = new Length(4, LengthUnit.Kilometer);
            (length1 <= length3).ShouldBeTrue();
            (length3 <= length1).ShouldBeFalse();
            (length1 <= length2).ShouldBeTrue();
            (length2 <= length1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var length = new Length(1, LengthUnit.Kilometer);
            var expected = new Length(2, LengthUnit.Kilometer);
            (length * 2).ShouldBe(expected);
            (2 * length).ShouldBe(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var length1 = new Length(7000, LengthUnit.Meter);
            var length2 = new Length(1, LengthUnit.Kilometer);
            (length1 - length2).ShouldBe(new Length(6000, LengthUnit.Meter));
            (length2 - length1).ShouldBe(new Length(-6, LengthUnit.Kilometer));
        }
    }
}