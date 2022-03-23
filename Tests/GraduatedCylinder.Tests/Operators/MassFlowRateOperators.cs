using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class MassFlowRateOperators
{

    [Fact]
    public void OpAddition() {
        var massFlowRate1 = new MassFlowRate(4000, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(1, MassFlowRateUnit.KiloGramsPerSecond);
        var expected = new MassFlowRate(5000, MassFlowRateUnit.GramsPerSecond);
        (massFlowRate1 + massFlowRate2).ShouldBe(expected);
        (massFlowRate2 + massFlowRate1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var massFlowRate1 = new MassFlowRate(3600, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(3.6, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 / massFlowRate2).ShouldBeCloseTo(1);
        (massFlowRate2 / massFlowRate1).ShouldBeCloseTo(1);

        (massFlowRate1 / 2).ShouldBe(new MassFlowRate(1800, MassFlowRateUnit.GramsPerSecond));
        (massFlowRate2 / 2).ShouldBe(new MassFlowRate(1.8, MassFlowRateUnit.KiloGramsPerSecond));
    }

    [Fact]
    public void OpEquals() {
        var massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KiloGramsPerSecond);
        var massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KiloGramsPerSecond);
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
        var massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KiloGramsPerSecond);
        var massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 > massFlowRate3).ShouldBeFalse();
        (massFlowRate3 > massFlowRate1).ShouldBeTrue();
        (massFlowRate1 > massFlowRate2).ShouldBeFalse();
        (massFlowRate2 > massFlowRate1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KiloGramsPerSecond);
        var massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 >= massFlowRate3).ShouldBeFalse();
        (massFlowRate3 >= massFlowRate1).ShouldBeTrue();
        (massFlowRate1 >= massFlowRate2).ShouldBeTrue();
        (massFlowRate2 >= massFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KiloGramsPerSecond);
        var massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 != massFlowRate2).ShouldBeFalse();
        (massFlowRate2 != massFlowRate1).ShouldBeFalse();
        (massFlowRate1 != massFlowRate3).ShouldBeTrue();
        (massFlowRate3 != massFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KiloGramsPerSecond);
        var massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 < massFlowRate3).ShouldBeTrue();
        (massFlowRate3 < massFlowRate1).ShouldBeFalse();
        (massFlowRate1 < massFlowRate2).ShouldBeFalse();
        (massFlowRate2 < massFlowRate1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var massFlowRate1 = new MassFlowRate(3000, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(3, MassFlowRateUnit.KiloGramsPerSecond);
        var massFlowRate3 = new MassFlowRate(5, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 <= massFlowRate3).ShouldBeTrue();
        (massFlowRate3 <= massFlowRate1).ShouldBeFalse();
        (massFlowRate1 <= massFlowRate2).ShouldBeTrue();
        (massFlowRate2 <= massFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var massFlowRate = new MassFlowRate(1, MassFlowRateUnit.KiloGramsPerSecond);
        var expected = new MassFlowRate(2, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate * 2).ShouldBe(expected);
        (2 * massFlowRate).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var massFlowRate1 = new MassFlowRate(5000, MassFlowRateUnit.GramsPerSecond);
        var massFlowRate2 = new MassFlowRate(1, MassFlowRateUnit.KiloGramsPerSecond);
        (massFlowRate1 - massFlowRate2).ShouldBe(new MassFlowRate(4000, MassFlowRateUnit.GramsPerSecond));
        (massFlowRate2 - massFlowRate1).ShouldBe(new MassFlowRate(-4, MassFlowRateUnit.KiloGramsPerSecond));
    }

}