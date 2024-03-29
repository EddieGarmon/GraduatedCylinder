#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class LengthOperators
{

    [Fact]
    public void OpAddition() {
        Length length1 = new(5000, LengthUnit.Meter);
        Length length2 = new(2, LengthUnit.KiloMeter);
        Length expected = new(7000, LengthUnit.Meter);
        (length1 + length2).ShouldBe(expected);
        (length2 + length1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Length length1 = new(4000, LengthUnit.Meter);
        Length length2 = new(4, LengthUnit.KiloMeter);
        (length1 / length2).ShouldBeCloseTo(1);
        (length2 / length1).ShouldBeCloseTo(1);

        (length1 / 2).ShouldBe(new Length(2000, LengthUnit.Meter));
        (length2 / 2).ShouldBe(new Length(2, LengthUnit.KiloMeter));
    }

    [Fact]
    public void OpEquals() {
        Length length1 = new(3000, LengthUnit.Meter);
        Length length2 = new(3, LengthUnit.KiloMeter);
        Length length3 = new(4, LengthUnit.KiloMeter);
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
        Length length1 = new(3000, LengthUnit.Meter);
        Length length2 = new(3, LengthUnit.KiloMeter);
        Length length3 = new(4, LengthUnit.KiloMeter);
        (length1 > length3).ShouldBeFalse();
        (length3 > length1).ShouldBeTrue();
        (length1 > length2).ShouldBeFalse();
        (length2 > length1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Length length1 = new(3000, LengthUnit.Meter);
        Length length2 = new(3, LengthUnit.KiloMeter);
        Length length3 = new(4, LengthUnit.KiloMeter);
        (length1 >= length3).ShouldBeFalse();
        (length3 >= length1).ShouldBeTrue();
        (length1 >= length2).ShouldBeTrue();
        (length2 >= length1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Length length1 = new(3000, LengthUnit.Meter);
        Length length2 = new(3, LengthUnit.KiloMeter);
        Length length3 = new(4, LengthUnit.KiloMeter);
        (length1 != length2).ShouldBeFalse();
        (length2 != length1).ShouldBeFalse();
        (length1 != length3).ShouldBeTrue();
        (length3 != length1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Length length1 = new(3000, LengthUnit.Meter);
        Length length2 = new(3, LengthUnit.KiloMeter);
        Length length3 = new(4, LengthUnit.KiloMeter);
        (length1 < length3).ShouldBeTrue();
        (length3 < length1).ShouldBeFalse();
        (length1 < length2).ShouldBeFalse();
        (length2 < length1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Length length1 = new(3000, LengthUnit.Meter);
        Length length2 = new(3, LengthUnit.KiloMeter);
        Length length3 = new(4, LengthUnit.KiloMeter);
        (length1 <= length3).ShouldBeTrue();
        (length3 <= length1).ShouldBeFalse();
        (length1 <= length2).ShouldBeTrue();
        (length2 <= length1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Length length = new(1, LengthUnit.KiloMeter);
        Length expected = new(2, LengthUnit.KiloMeter);
        (length * 2).ShouldBe(expected);
        (2 * length).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Length length1 = new(7000, LengthUnit.Meter);
        Length length2 = new(1, LengthUnit.KiloMeter);
        (length1 - length2).ShouldBe(new Length(6000, LengthUnit.Meter));
        (length2 - length1).ShouldBe(new Length(-6, LengthUnit.KiloMeter));
    }

}