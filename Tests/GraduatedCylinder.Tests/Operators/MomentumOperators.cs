using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class MomentumOperators
{

    [Fact]
    public void OpAddition() {
        Momentum momentum1 = new(300000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(1, MomentumUnit.KiloGramMetersPerSecond);
        Momentum expected = new(400000, MomentumUnit.GramCentiMetersPerSecond);
        (momentum1 + momentum2).ShouldBe(expected);
        (momentum2 + momentum1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Momentum momentum1 = new(300000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(3, MomentumUnit.KiloGramMetersPerSecond);
        (momentum1 / momentum2).ShouldBeCloseTo(1);
        (momentum2 / momentum1).ShouldBeCloseTo(1);

        (momentum1 / 2).ShouldBe(new Momentum(150000, MomentumUnit.GramCentiMetersPerSecond));
        (momentum2 / 2).ShouldBe(new Momentum(1.5, MomentumUnit.KiloGramMetersPerSecond));
    }

    [Fact]
    public void OpEquals() {
        Momentum momentum1 = new(300000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(3, MomentumUnit.KiloGramMetersPerSecond);
        Momentum momentum3 = new(4, MomentumUnit.KiloGramMetersPerSecond);
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
        Momentum momentum1 = new(300000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(3, MomentumUnit.KiloGramMetersPerSecond);
        Momentum momentum3 = new(4, MomentumUnit.KiloGramMetersPerSecond);
        (momentum1 > momentum3).ShouldBeFalse();
        (momentum3 > momentum1).ShouldBeTrue();
        (momentum1 > momentum2).ShouldBeFalse();
        (momentum2 > momentum1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Momentum momentum1 = new(300000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(3, MomentumUnit.KiloGramMetersPerSecond);
        Momentum momentum3 = new(4, MomentumUnit.KiloGramMetersPerSecond);
        (momentum1 >= momentum3).ShouldBeFalse();
        (momentum3 >= momentum1).ShouldBeTrue();
        (momentum1 >= momentum2).ShouldBeTrue();
        (momentum2 >= momentum1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Momentum momentum1 = new(300000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(3, MomentumUnit.KiloGramMetersPerSecond);
        Momentum momentum3 = new(4, MomentumUnit.KiloGramMetersPerSecond);
        (momentum1 != momentum2).ShouldBeFalse();
        (momentum2 != momentum1).ShouldBeFalse();
        (momentum1 != momentum3).ShouldBeTrue();
        (momentum3 != momentum1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Momentum momentum1 = new(300000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(3, MomentumUnit.KiloGramMetersPerSecond);
        Momentum momentum3 = new(4, MomentumUnit.KiloGramMetersPerSecond);
        (momentum1 < momentum3).ShouldBeTrue();
        (momentum3 < momentum1).ShouldBeFalse();
        (momentum1 < momentum2).ShouldBeFalse();
        (momentum2 < momentum1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Momentum momentum1 = new(300000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(3, MomentumUnit.KiloGramMetersPerSecond);
        Momentum momentum3 = new(4, MomentumUnit.KiloGramMetersPerSecond);
        (momentum1 <= momentum3).ShouldBeTrue();
        (momentum3 <= momentum1).ShouldBeFalse();
        (momentum1 <= momentum2).ShouldBeTrue();
        (momentum2 <= momentum1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Momentum momentum = new(1, MomentumUnit.KiloGramMetersPerSecond);
        Momentum expected = new(2, MomentumUnit.KiloGramMetersPerSecond);
        (momentum * 2).ShouldBe(expected);
        (2 * momentum).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Momentum momentum1 = new(700000, MomentumUnit.GramCentiMetersPerSecond);
        Momentum momentum2 = new(3, MomentumUnit.KiloGramMetersPerSecond);
        (momentum1 - momentum2).ShouldBe(new Momentum(400000, MomentumUnit.GramCentiMetersPerSecond));
        (momentum2 - momentum1).ShouldBe(new Momentum(-4, MomentumUnit.KiloGramMetersPerSecond));
    }

}