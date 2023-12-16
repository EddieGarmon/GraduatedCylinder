#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class PressureOperators
{

    [Fact]
    public void OpAddition() {
        Pressure pressure1 = new(1000, PressureUnit.Pascals);
        Pressure pressure2 = new(1, PressureUnit.KiloPascals);
        Pressure expected = new(2000, PressureUnit.Pascals);
        (pressure1 + pressure2).ShouldBe(expected);
        (pressure2 + pressure1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Pressure pressure1 = new(4000, PressureUnit.Pascals);
        Pressure pressure2 = new(4, PressureUnit.KiloPascals);
        (pressure1 / pressure2).ShouldBeCloseTo(1);
        (pressure2 / pressure1).ShouldBeCloseTo(1);

        (pressure1 / 2).ShouldBe(new Pressure(2000, PressureUnit.Pascals));
        (pressure2 / 2).ShouldBe(new Pressure(2, PressureUnit.KiloPascals));
    }

    [Fact]
    public void OpEquals() {
        Pressure pressure1 = new(1000, PressureUnit.Pascals);
        Pressure pressure2 = new(1, PressureUnit.KiloPascals);
        Pressure pressure3 = new(2, PressureUnit.KiloPascals);
        (pressure1 == pressure2).ShouldBeTrue();
        (pressure2 == pressure1).ShouldBeTrue();
        (pressure1 == pressure3).ShouldBeFalse();
        (pressure3 == pressure1).ShouldBeFalse();
        pressure1.Equals(pressure2).ShouldBeTrue();
        pressure1.Equals((object)pressure2).ShouldBeTrue();
        pressure2.Equals(pressure1).ShouldBeTrue();
        pressure2.Equals((object)pressure1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        Pressure pressure1 = new(1000, PressureUnit.Pascals);
        Pressure pressure2 = new(1, PressureUnit.KiloPascals);
        Pressure pressure3 = new(2, PressureUnit.KiloPascals);
        (pressure1 > pressure3).ShouldBeFalse();
        (pressure3 > pressure1).ShouldBeTrue();
        (pressure1 > pressure2).ShouldBeFalse();
        (pressure2 > pressure1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Pressure pressure1 = new(1000, PressureUnit.Pascals);
        Pressure pressure2 = new(1, PressureUnit.KiloPascals);
        Pressure pressure3 = new(2, PressureUnit.KiloPascals);
        (pressure1 >= pressure3).ShouldBeFalse();
        (pressure3 >= pressure1).ShouldBeTrue();
        (pressure1 >= pressure2).ShouldBeTrue();
        (pressure2 >= pressure1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Pressure pressure1 = new(1000, PressureUnit.Pascals);
        Pressure pressure2 = new(1, PressureUnit.KiloPascals);
        Pressure pressure3 = new(2, PressureUnit.KiloPascals);
        (pressure1 != pressure2).ShouldBeFalse();
        (pressure2 != pressure1).ShouldBeFalse();
        (pressure1 != pressure3).ShouldBeTrue();
        (pressure3 != pressure1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Pressure pressure1 = new(1000, PressureUnit.Pascals);
        Pressure pressure2 = new(1, PressureUnit.KiloPascals);
        Pressure pressure3 = new(2, PressureUnit.KiloPascals);
        (pressure1 < pressure3).ShouldBeTrue();
        (pressure3 < pressure1).ShouldBeFalse();
        (pressure1 < pressure2).ShouldBeFalse();
        (pressure2 < pressure1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Pressure pressure1 = new(1000, PressureUnit.Pascals);
        Pressure pressure2 = new(1, PressureUnit.KiloPascals);
        Pressure pressure3 = new(2, PressureUnit.KiloPascals);
        (pressure1 <= pressure3).ShouldBeTrue();
        (pressure3 <= pressure1).ShouldBeFalse();
        (pressure1 <= pressure2).ShouldBeTrue();
        (pressure2 <= pressure1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Pressure pressure = new(1, PressureUnit.Pascals);
        Pressure expected = new(2, PressureUnit.Pascals);
        (pressure * 2).ShouldBe(expected);
        (2 * pressure).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Pressure pressure1 = new(7000, PressureUnit.Pascals);
        Pressure pressure2 = new(1, PressureUnit.KiloPascals);
        (pressure1 - pressure2).ShouldBe(new Pressure(6000, PressureUnit.Pascals));
        (pressure2 - pressure1).ShouldBe(new Pressure(-6, PressureUnit.KiloPascals));
    }

}