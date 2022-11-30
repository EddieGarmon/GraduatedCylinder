using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class DensityOperators
{

    [Fact]
    public void OpAddition() {
        MassDensity density1 = new(3000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        MassDensity expected = new(6000, MassDensityUnit.KiloGramsPerCubicMeter);
        (density1 + density2).ShouldBe(expected);
        (density2 + density1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        MassDensity density1 = new(3000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        (density1 / density2).ShouldBeCloseTo(1);
        (density2 / density1).ShouldBeCloseTo(1);

        (density1 / 2).ShouldBe(new MassDensity(1500, MassDensityUnit.KiloGramsPerCubicMeter));
        (density2 / 2).ShouldBe(new MassDensity(1.5, MassDensityUnit.GramsPerCubicCentiMeter));
    }

    [Fact]
    public void OpEquals() {
        MassDensity density1 = new(3000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        MassDensity density3 = new(12, MassDensityUnit.GramsPerCubicCentiMeter);
        (density1 == density2).ShouldBeTrue();
        (density2 == density1).ShouldBeTrue();
        (density1 == density3).ShouldBeFalse();
        (density3 == density1).ShouldBeFalse();
        density1.Equals(density2).ShouldBeTrue();
        density1.Equals((object)density2).ShouldBeTrue();
        density2.Equals(density1).ShouldBeTrue();
        density2.Equals((object)density1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        MassDensity density1 = new(3000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        MassDensity density3 = new(12, MassDensityUnit.GramsPerCubicCentiMeter);
        (density1 > density3).ShouldBeFalse();
        (density3 > density1).ShouldBeTrue();
        (density1 > density2).ShouldBeFalse();
        (density2 > density1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        MassDensity density1 = new(3000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        MassDensity density3 = new(12, MassDensityUnit.GramsPerCubicCentiMeter);
        (density1 >= density3).ShouldBeFalse();
        (density3 >= density1).ShouldBeTrue();
        (density1 >= density2).ShouldBeTrue();
        (density2 >= density1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        MassDensity density1 = new(3000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        MassDensity density3 = new(12, MassDensityUnit.GramsPerCubicCentiMeter);
        (density1 != density2).ShouldBeFalse();
        (density2 != density1).ShouldBeFalse();
        (density1 != density3).ShouldBeTrue();
        (density3 != density1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        MassDensity density1 = new(3000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        MassDensity density3 = new(12, MassDensityUnit.GramsPerCubicCentiMeter);
        (density1 < density3).ShouldBeTrue();
        (density3 < density1).ShouldBeFalse();
        (density1 < density2).ShouldBeFalse();
        (density2 < density1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        MassDensity density1 = new(3000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        MassDensity density3 = new(12, MassDensityUnit.GramsPerCubicCentiMeter);
        (density1 <= density3).ShouldBeTrue();
        (density3 <= density1).ShouldBeFalse();
        (density1 <= density2).ShouldBeTrue();
        (density2 <= density1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        MassDensity density = new(1, MassDensityUnit.GramsPerCubicCentiMeter);
        MassDensity expected = new(2, MassDensityUnit.GramsPerCubicCentiMeter);
        (density * 2).ShouldBe(expected);
        (2 * density).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        MassDensity density1 = new(6000, MassDensityUnit.KiloGramsPerCubicMeter);
        MassDensity density2 = new(3, MassDensityUnit.GramsPerCubicCentiMeter);
        (density1 - density2).ShouldBe(new MassDensity(3000, MassDensityUnit.KiloGramsPerCubicMeter));
        (density2 - density1).ShouldBe(new MassDensity(-3, MassDensityUnit.GramsPerCubicCentiMeter));
    }

}