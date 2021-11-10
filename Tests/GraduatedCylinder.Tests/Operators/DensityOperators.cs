using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class DensityOperators
{
    [Fact]
    public void OpAddition() {
        var density1 = new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        var expected = new MassDensity(6000, MassDensityUnit.KilogramsPerCubicMeter);
        (density1 + density2).ShouldBe(expected);
        (density2 + density1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var density1 = new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        (density1 / density2).ShouldBeWithinToleranceOf(1);
        (density2 / density1).ShouldBeWithinToleranceOf(1);

        (density1 / 2).ShouldBe(new MassDensity(1500, MassDensityUnit.KilogramsPerCubicMeter));
        (density2 / 2).ShouldBe(new MassDensity(1.5, MassDensityUnit.GramsPerCubicCentimeter));
    }

    [Fact]
    public void OpEquals() {
        var density1 = new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        var density3 = new MassDensity(12, MassDensityUnit.GramsPerCubicCentimeter);
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
        var density1 = new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        var density3 = new MassDensity(12, MassDensityUnit.GramsPerCubicCentimeter);
        (density1 > density3).ShouldBeFalse();
        (density3 > density1).ShouldBeTrue();
        (density1 > density2).ShouldBeFalse();
        (density2 > density1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var density1 = new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        var density3 = new MassDensity(12, MassDensityUnit.GramsPerCubicCentimeter);
        (density1 >= density3).ShouldBeFalse();
        (density3 >= density1).ShouldBeTrue();
        (density1 >= density2).ShouldBeTrue();
        (density2 >= density1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var density1 = new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        var density3 = new MassDensity(12, MassDensityUnit.GramsPerCubicCentimeter);
        (density1 != density2).ShouldBeFalse();
        (density2 != density1).ShouldBeFalse();
        (density1 != density3).ShouldBeTrue();
        (density3 != density1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var density1 = new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        var density3 = new MassDensity(12, MassDensityUnit.GramsPerCubicCentimeter);
        (density1 < density3).ShouldBeTrue();
        (density3 < density1).ShouldBeFalse();
        (density1 < density2).ShouldBeFalse();
        (density2 < density1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var density1 = new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        var density3 = new MassDensity(12, MassDensityUnit.GramsPerCubicCentimeter);
        (density1 <= density3).ShouldBeTrue();
        (density3 <= density1).ShouldBeFalse();
        (density1 <= density2).ShouldBeTrue();
        (density2 <= density1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var density = new MassDensity(1, MassDensityUnit.GramsPerCubicCentimeter);
        var expected = new MassDensity(2, MassDensityUnit.GramsPerCubicCentimeter);
        (density * 2).ShouldBe(expected);
        (2 * density).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var density1 = new MassDensity(6000, MassDensityUnit.KilogramsPerCubicMeter);
        var density2 = new MassDensity(3, MassDensityUnit.GramsPerCubicCentimeter);
        (density1 - density2).ShouldBe(new MassDensity(3000, MassDensityUnit.KilogramsPerCubicMeter));
        (density2 - density1).ShouldBe(new MassDensity(-3, MassDensityUnit.GramsPerCubicCentimeter));
    }
}