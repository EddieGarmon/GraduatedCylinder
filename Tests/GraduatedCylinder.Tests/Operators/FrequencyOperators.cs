#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class FrequencyOperators
{

    [Fact]
    public void OpAddition() {
        Frequency frequency1 = new(1, FrequencyUnit.Hertz);
        Frequency frequency2 = new(1, FrequencyUnit.CyclePerSecond);
        Frequency expected = new(2, FrequencyUnit.Hertz);
        (frequency1 + frequency2).ShouldBe(expected);
        (frequency2 + frequency1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Frequency frequency1 = new(2, FrequencyUnit.Hertz);
        Frequency frequency2 = new(2, FrequencyUnit.CyclePerSecond);
        (frequency1 / frequency2).ShouldBeCloseTo(1);
        (frequency2 / frequency1).ShouldBeCloseTo(1);

        (frequency1 / 2).ShouldBe(new Frequency(1, FrequencyUnit.Hertz));
        (frequency2 / 2).ShouldBe(new Frequency(1, FrequencyUnit.CyclePerSecond));
    }

    [Fact]
    public void OpEquals() {
        Frequency frequency1 = new(1, FrequencyUnit.Hertz);
        Frequency frequency2 = new(1, FrequencyUnit.CyclePerSecond);
        Frequency frequency3 = new(2, FrequencyUnit.CyclePerSecond);
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
        Frequency frequency1 = new(1, FrequencyUnit.Hertz);
        Frequency frequency2 = new(1, FrequencyUnit.CyclePerSecond);
        Frequency frequency3 = new(2, FrequencyUnit.CyclePerSecond);
        (frequency1 > frequency3).ShouldBeFalse();
        (frequency3 > frequency1).ShouldBeTrue();
        (frequency1 > frequency2).ShouldBeFalse();
        (frequency2 > frequency1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Frequency frequency1 = new(1, FrequencyUnit.Hertz);
        Frequency frequency2 = new(1, FrequencyUnit.CyclePerSecond);
        Frequency frequency3 = new(2, FrequencyUnit.CyclePerSecond);
        (frequency1 >= frequency3).ShouldBeFalse();
        (frequency3 >= frequency1).ShouldBeTrue();
        (frequency1 >= frequency2).ShouldBeTrue();
        (frequency2 >= frequency1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Frequency frequency1 = new(1, FrequencyUnit.Hertz);
        Frequency frequency2 = new(1, FrequencyUnit.CyclePerSecond);
        Frequency frequency3 = new(2, FrequencyUnit.CyclePerSecond);
        (frequency1 != frequency2).ShouldBeFalse();
        (frequency2 != frequency1).ShouldBeFalse();
        (frequency1 != frequency3).ShouldBeTrue();
        (frequency3 != frequency1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Frequency frequency1 = new(1, FrequencyUnit.Hertz);
        Frequency frequency2 = new(1, FrequencyUnit.CyclePerSecond);
        Frequency frequency3 = new(2, FrequencyUnit.CyclePerSecond);
        (frequency1 < frequency3).ShouldBeTrue();
        (frequency3 < frequency1).ShouldBeFalse();
        (frequency1 < frequency2).ShouldBeFalse();
        (frequency2 < frequency1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Frequency frequency1 = new(1, FrequencyUnit.Hertz);
        Frequency frequency2 = new(1, FrequencyUnit.CyclePerSecond);
        Frequency frequency3 = new(2, FrequencyUnit.CyclePerSecond);
        (frequency1 <= frequency3).ShouldBeTrue();
        (frequency3 <= frequency1).ShouldBeFalse();
        (frequency1 <= frequency2).ShouldBeTrue();
        (frequency2 <= frequency1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Frequency frequency = new(1, FrequencyUnit.Hertz);
        Frequency expected = new(2, FrequencyUnit.Hertz);
        (frequency * 2).ShouldBe(expected);
        (2 * frequency).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Frequency frequency1 = new(10, FrequencyUnit.Hertz);
        Frequency frequency2 = new(1, FrequencyUnit.CyclePerSecond);
        (frequency1 - frequency2).ShouldBe(new Frequency(9, FrequencyUnit.Hertz));
        (frequency2 - frequency1).ShouldBe(new Frequency(-9, FrequencyUnit.CyclePerSecond));
    }

}