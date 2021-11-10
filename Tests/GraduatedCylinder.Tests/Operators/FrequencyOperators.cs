using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class FrequencyOperators
{
    [Fact]
    public void OpAddition() {
        var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(1, FrequencyUnit.CyclePerSecond);
        var expected = new Frequency(2, FrequencyUnit.Hertz);
        (frequency1 + frequency2).ShouldBe(expected);
        (frequency2 + frequency1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var frequency1 = new Frequency(2, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(2, FrequencyUnit.CyclePerSecond);
        (frequency1 / frequency2).ShouldBeWithinToleranceOf(1);
        (frequency2 / frequency1).ShouldBeWithinToleranceOf(1);

        (frequency1 / 2).ShouldBe(new Frequency(1, FrequencyUnit.Hertz));
        (frequency2 / 2).ShouldBe(new Frequency(1, FrequencyUnit.CyclePerSecond));
    }

    [Fact]
    public void OpEquals() {
        var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(1, FrequencyUnit.CyclePerSecond);
        var frequency3 = new Frequency(2, FrequencyUnit.CyclePerSecond);
        (frequency1 == frequency2).ShouldBeTrue();
        (frequency2 == frequency1).ShouldBeTrue();
        (frequency1 == frequency3).ShouldBeFalse();
        (frequency3 == frequency1).ShouldBeFalse();
        frequency1.Equals(frequency2).ShouldBeTrue();
        frequency1.Equals((object)frequency2).ShouldBeTrue();
        frequency2.Equals(frequency1).ShouldBeTrue();
        frequency2.Equals((object)frequency1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(1, FrequencyUnit.CyclePerSecond);
        var frequency3 = new Frequency(2, FrequencyUnit.CyclePerSecond);
        (frequency1 > frequency3).ShouldBeFalse();
        (frequency3 > frequency1).ShouldBeTrue();
        (frequency1 > frequency2).ShouldBeFalse();
        (frequency2 > frequency1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(1, FrequencyUnit.CyclePerSecond);
        var frequency3 = new Frequency(2, FrequencyUnit.CyclePerSecond);
        (frequency1 >= frequency3).ShouldBeFalse();
        (frequency3 >= frequency1).ShouldBeTrue();
        (frequency1 >= frequency2).ShouldBeTrue();
        (frequency2 >= frequency1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(1, FrequencyUnit.CyclePerSecond);
        var frequency3 = new Frequency(2, FrequencyUnit.CyclePerSecond);
        (frequency1 != frequency2).ShouldBeFalse();
        (frequency2 != frequency1).ShouldBeFalse();
        (frequency1 != frequency3).ShouldBeTrue();
        (frequency3 != frequency1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(1, FrequencyUnit.CyclePerSecond);
        var frequency3 = new Frequency(2, FrequencyUnit.CyclePerSecond);
        (frequency1 < frequency3).ShouldBeTrue();
        (frequency3 < frequency1).ShouldBeFalse();
        (frequency1 < frequency2).ShouldBeFalse();
        (frequency2 < frequency1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var frequency1 = new Frequency(1, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(1, FrequencyUnit.CyclePerSecond);
        var frequency3 = new Frequency(2, FrequencyUnit.CyclePerSecond);
        (frequency1 <= frequency3).ShouldBeTrue();
        (frequency3 <= frequency1).ShouldBeFalse();
        (frequency1 <= frequency2).ShouldBeTrue();
        (frequency2 <= frequency1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var frequency = new Frequency(1, FrequencyUnit.Hertz);
        var expected = new Frequency(2, FrequencyUnit.Hertz);
        (frequency * 2).ShouldBe(expected);
        (2 * frequency).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var frequency1 = new Frequency(10, FrequencyUnit.Hertz);
        var frequency2 = new Frequency(1, FrequencyUnit.CyclePerSecond);
        (frequency1 - frequency2).ShouldBe(new Frequency(9, FrequencyUnit.Hertz));
        (frequency2 - frequency1).ShouldBe(new Frequency(-9, FrequencyUnit.CyclePerSecond));
    }
}