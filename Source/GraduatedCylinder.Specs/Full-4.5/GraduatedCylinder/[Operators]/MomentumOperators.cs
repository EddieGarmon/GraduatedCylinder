using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class MomentumOperators
    {
        [Fact]
        public void OpAddition() {
            Momentum momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(1, MomentumUnit.KilogramMetersPerSecond);
            Momentum expected = new Momentum(400000, MomentumUnit.GramCentimetersPerSecond);
            (momentum1 + momentum2).ShouldEqual(expected, UnitAndValueComparers.Momentum);
            expected.Units = MomentumUnit.KilogramMetersPerSecond;
            (momentum2 + momentum1).ShouldEqual(expected, UnitAndValueComparers.Momentum);
        }

        [Fact]
        public void OpDivision() {
            Momentum momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
            (momentum1 / momentum2).ShouldBeWithinEpsilonOf(1);
            (momentum2 / momentum1).ShouldBeWithinEpsilonOf(1);

            (momentum1 / 2).ShouldEqual(new Momentum(150000, MomentumUnit.GramCentimetersPerSecond));
            (momentum2 / 2).ShouldEqual(new Momentum(1.5, MomentumUnit.KilogramMetersPerSecond));
        }

        [Fact]
        public void OpEquals() {
            Momentum momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
            Momentum momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
            (momentum1 == momentum2).ShouldBeTrue();
            (momentum2 == momentum1).ShouldBeTrue();
            (momentum1 == momentum3).ShouldBeFalse();
            (momentum3 == momentum1).ShouldBeFalse();
            momentum1.Equals(momentum2).ShouldBeTrue();
            momentum1.Equals((object)momentum2).ShouldBeTrue();
            momentum2.Equals(momentum1).ShouldBeTrue();
            momentum2.Equals((object)momentum1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            Momentum momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
            Momentum momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
            (momentum1 > momentum3).ShouldBeFalse();
            (momentum3 > momentum1).ShouldBeTrue();
            (momentum1 > momentum2).ShouldBeFalse();
            (momentum2 > momentum1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Momentum momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
            Momentum momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
            (momentum1 >= momentum3).ShouldBeFalse();
            (momentum3 >= momentum1).ShouldBeTrue();
            (momentum1 >= momentum2).ShouldBeTrue();
            (momentum2 >= momentum1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Momentum momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
            Momentum momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
            (momentum1 != momentum2).ShouldBeFalse();
            (momentum2 != momentum1).ShouldBeFalse();
            (momentum1 != momentum3).ShouldBeTrue();
            (momentum3 != momentum1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Momentum momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
            Momentum momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
            (momentum1 < momentum3).ShouldBeTrue();
            (momentum3 < momentum1).ShouldBeFalse();
            (momentum1 < momentum2).ShouldBeFalse();
            (momentum2 < momentum1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Momentum momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
            Momentum momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
            (momentum1 <= momentum3).ShouldBeTrue();
            (momentum3 <= momentum1).ShouldBeFalse();
            (momentum1 <= momentum2).ShouldBeTrue();
            (momentum2 <= momentum1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Momentum momentum = new Momentum(1, MomentumUnit.KilogramMetersPerSecond);
            Momentum expected = new Momentum(2, MomentumUnit.KilogramMetersPerSecond);
            (momentum * 2).ShouldEqual(expected, UnitAndValueComparers.Momentum);
            (2 * momentum).ShouldEqual(expected, UnitAndValueComparers.Momentum);
        }

        [Fact]
        public void OpSubtraction() {
            Momentum momentum1 = new Momentum(700000, MomentumUnit.GramCentimetersPerSecond);
            Momentum momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
            (momentum1 - momentum2).ShouldEqual(new Momentum(400000, MomentumUnit.GramCentimetersPerSecond), UnitAndValueComparers.Momentum);
            (momentum2 - momentum1).ShouldEqual(new Momentum(-4, MomentumUnit.KilogramMetersPerSecond), UnitAndValueComparers.Momentum);
        }
    }
}