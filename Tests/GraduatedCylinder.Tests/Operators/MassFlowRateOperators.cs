#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class MassFlowRateOperators
{

    [Fact]
    public void OpAddition() {
        MassFlowRate massFlowRate1 = new(4000, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(1, MassFlowRateUnit.KiloGramsPerSecond);
        MassFlowRate expected = new(5000, MassFlowRateUnit.GramsPerSecond);
        (massFlowRate1 + massFlowRate2).ShouldBe(expected);
        (massFlowRate2 + massFlowRate1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        MassFlowRate massFlowRate1 = new(3600, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(3.6, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 / massFlowRate2).ShouldBeCloseTo(1);
        (massFlowRate2 / massFlowRate1).ShouldBeCloseTo(1);

        (massFlowRate1 / 2).ShouldBe(new MassFlowRate(1800, MassFlowRateUnit.GramsPerSecond));
        (massFlowRate2 / 2).ShouldBe(new MassFlowRate(1.8, MassFlowRateUnit.KiloGramsPerSecond));
    }

    [Fact]
    public void OpEquals() {
        MassFlowRate massFlowRate1 = new(3000, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(3, MassFlowRateUnit.KiloGramsPerSecond);
        MassFlowRate massFlowRate3 = new(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 == massFlowRate2).ShouldBeTrue();
        (massFlowRate2 == massFlowRate1).ShouldBeTrue();
        (massFlowRate1 == massFlowRate3).ShouldBeFalse();
        (massFlowRate3 == massFlowRate1).ShouldBeFalse();
        massFlowRate1.Equals(massFlowRate2).ShouldBeTrue();
        massFlowRate1.Equals((object)massFlowRate2).ShouldBeTrue();
        massFlowRate2.Equals(massFlowRate1).ShouldBeTrue();
        massFlowRate2.Equals((object)massFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        MassFlowRate massFlowRate1 = new(3000, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(3, MassFlowRateUnit.KiloGramsPerSecond);
        MassFlowRate massFlowRate3 = new(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 > massFlowRate3).ShouldBeFalse();
        (massFlowRate3 > massFlowRate1).ShouldBeTrue();
        (massFlowRate1 > massFlowRate2).ShouldBeFalse();
        (massFlowRate2 > massFlowRate1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        MassFlowRate massFlowRate1 = new(3000, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(3, MassFlowRateUnit.KiloGramsPerSecond);
        MassFlowRate massFlowRate3 = new(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 >= massFlowRate3).ShouldBeFalse();
        (massFlowRate3 >= massFlowRate1).ShouldBeTrue();
        (massFlowRate1 >= massFlowRate2).ShouldBeTrue();
        (massFlowRate2 >= massFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        MassFlowRate massFlowRate1 = new(3000, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(3, MassFlowRateUnit.KiloGramsPerSecond);
        MassFlowRate massFlowRate3 = new(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 != massFlowRate2).ShouldBeFalse();
        (massFlowRate2 != massFlowRate1).ShouldBeFalse();
        (massFlowRate1 != massFlowRate3).ShouldBeTrue();
        (massFlowRate3 != massFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        MassFlowRate massFlowRate1 = new(3000, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(3, MassFlowRateUnit.KiloGramsPerSecond);
        MassFlowRate massFlowRate3 = new(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 < massFlowRate3).ShouldBeTrue();
        (massFlowRate3 < massFlowRate1).ShouldBeFalse();
        (massFlowRate1 < massFlowRate2).ShouldBeFalse();
        (massFlowRate2 < massFlowRate1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        MassFlowRate massFlowRate1 = new(3000, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(3, MassFlowRateUnit.KiloGramsPerSecond);
        MassFlowRate massFlowRate3 = new(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 <= massFlowRate3).ShouldBeTrue();
        (massFlowRate3 <= massFlowRate1).ShouldBeFalse();
        (massFlowRate1 <= massFlowRate2).ShouldBeTrue();
        (massFlowRate2 <= massFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        MassFlowRate massFlowRate = new(1, MassFlowRateUnit.KiloGramsPerSecond);
        MassFlowRate expected = new(2, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate * 2).ShouldBe(expected);
        (2 * massFlowRate).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        MassFlowRate massFlowRate1 = new(5000, MassFlowRateUnit.GramsPerSecond);
        MassFlowRate massFlowRate2 = new(1, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 - massFlowRate2).ShouldBe(new MassFlowRate(4000, MassFlowRateUnit.GramsPerSecond));
        (massFlowRate2 - massFlowRate1).ShouldBe(new MassFlowRate(-4, MassFlowRateUnit.KiloGramsPerSecond));
    }

}