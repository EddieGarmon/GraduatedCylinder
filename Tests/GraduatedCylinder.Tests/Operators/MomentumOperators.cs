using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class MomentumOperators
{

    [Fact]
    public void OpAddition() {
        var momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(1, MomentumUnit.KilogramMetersPerSecond);
        var expected = new Momentum(400000, MomentumUnit.GramCentimetersPerSecond);
        (momentum1 + momentum2).ShouldBe(expected);
        (momentum2 + momentum1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
        (momentum1 / momentum2).ShouldBeCloseTo(1);
        (momentum2 / momentum1).ShouldBeCloseTo(1);

        (momentum1 / 2).ShouldBe(new Momentum(150000, MomentumUnit.GramCentimetersPerSecond));
        (momentum2 / 2).ShouldBe(new Momentum(1.5, MomentumUnit.KilogramMetersPerSecond));
    }

    [Fact]
    public void OpEquals() {
        var momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
        var momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
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
        var momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
        var momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
        (momentum1 > momentum3).ShouldBeFalse();
        (momentum3 > momentum1).ShouldBeTrue();
        (momentum1 > momentum2).ShouldBeFalse();
        (momentum2 > momentum1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
        var momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
        (momentum1 >= momentum3).ShouldBeFalse();
        (momentum3 >= momentum1).ShouldBeTrue();
        (momentum1 >= momentum2).ShouldBeTrue();
        (momentum2 >= momentum1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
        var momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
        (momentum1 != momentum2).ShouldBeFalse();
        (momentum2 != momentum1).ShouldBeFalse();
        (momentum1 != momentum3).ShouldBeTrue();
        (momentum3 != momentum1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
        var momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
        (momentum1 < momentum3).ShouldBeTrue();
        (momentum3 < momentum1).ShouldBeFalse();
        (momentum1 < momentum2).ShouldBeFalse();
        (momentum2 < momentum1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var momentum1 = new Momentum(300000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
        var momentum3 = new Momentum(4, MomentumUnit.KilogramMetersPerSecond);
        (momentum1 <= momentum3).ShouldBeTrue();
        (momentum3 <= momentum1).ShouldBeFalse();
        (momentum1 <= momentum2).ShouldBeTrue();
        (momentum2 <= momentum1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var momentum = new Momentum(1, MomentumUnit.KilogramMetersPerSecond);
        var expected = new Momentum(2, MomentumUnit.KilogramMetersPerSecond);
        (momentum * 2).ShouldBe(expected);
        (2 * momentum).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var momentum1 = new Momentum(700000, MomentumUnit.GramCentimetersPerSecond);
        var momentum2 = new Momentum(3, MomentumUnit.KilogramMetersPerSecond);
        (momentum1 - momentum2).ShouldBe(new Momentum(400000, MomentumUnit.GramCentimetersPerSecond));
        (momentum2 - momentum1).ShouldBe(new Momentum(-4, MomentumUnit.KilogramMetersPerSecond));
    }

}