using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class DensityOperators
    {
        [Fact]
        public void OpAddition() {
            Density density1 = new Density(3000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            Density expected = new Density(6000, DensityUnit.KilogramsPerCubicMeter);
            (density1 + density2).ShouldEqual(expected, UnitAndValueComparers.Density);
            expected.Units = DensityUnit.GramsPerCubicCentimeter;
            (density2 + density1).ShouldEqual(expected, UnitAndValueComparers.Density);
        }

        [Fact]
        public void OpDivision() {
            Density density1 = new Density(3000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            (density1 / density2).ShouldBeWithinEpsilonOf(1);
            (density2 / density1).ShouldBeWithinEpsilonOf(1);

            (density1 / 2).ShouldEqual(new Density(1500, DensityUnit.KilogramsPerCubicMeter));
            (density2 / 2).ShouldEqual(new Density(1.5, DensityUnit.GramsPerCubicCentimeter));
        }

        [Fact]
        public void OpEquals() {
            Density density1 = new Density(3000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            Density density3 = new Density(12, DensityUnit.GramsPerCubicCentimeter);
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
            Density density1 = new Density(3000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            Density density3 = new Density(12, DensityUnit.GramsPerCubicCentimeter);
            (density1 > density3).ShouldBeFalse();
            (density3 > density1).ShouldBeTrue();
            (density1 > density2).ShouldBeFalse();
            (density2 > density1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Density density1 = new Density(3000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            Density density3 = new Density(12, DensityUnit.GramsPerCubicCentimeter);
            (density1 >= density3).ShouldBeFalse();
            (density3 >= density1).ShouldBeTrue();
            (density1 >= density2).ShouldBeTrue();
            (density2 >= density1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Density density1 = new Density(3000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            Density density3 = new Density(12, DensityUnit.GramsPerCubicCentimeter);
            (density1 != density2).ShouldBeFalse();
            (density2 != density1).ShouldBeFalse();
            (density1 != density3).ShouldBeTrue();
            (density3 != density1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Density density1 = new Density(3000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            Density density3 = new Density(12, DensityUnit.GramsPerCubicCentimeter);
            (density1 < density3).ShouldBeTrue();
            (density3 < density1).ShouldBeFalse();
            (density1 < density2).ShouldBeFalse();
            (density2 < density1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Density density1 = new Density(3000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            Density density3 = new Density(12, DensityUnit.GramsPerCubicCentimeter);
            (density1 <= density3).ShouldBeTrue();
            (density3 <= density1).ShouldBeFalse();
            (density1 <= density2).ShouldBeTrue();
            (density2 <= density1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Density density = new Density(1, DensityUnit.GramsPerCubicCentimeter);
            Density expected = new Density(2, DensityUnit.GramsPerCubicCentimeter);
            (density * 2).ShouldEqual(expected, UnitAndValueComparers.Density);
            (2 * density).ShouldEqual(expected, UnitAndValueComparers.Density);
        }

        [Fact]
        public void OpSubtraction() {
            Density density1 = new Density(6000, DensityUnit.KilogramsPerCubicMeter);
            Density density2 = new Density(3, DensityUnit.GramsPerCubicCentimeter);
            (density1 - density2).ShouldEqual(new Density(3000, DensityUnit.KilogramsPerCubicMeter), UnitAndValueComparers.Density);
            (density2 - density1).ShouldEqual(new Density(-3, DensityUnit.GramsPerCubicCentimeter), UnitAndValueComparers.Density);
        }
    }
}