using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class ElectricCurrentOperators
{

    [Fact]
    public void OpAddition() {
        ElectricCurrent current1 = new(3000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(1, ElectricCurrentUnit.KiloAmpere);
        ElectricCurrent expected = new(4000, ElectricCurrentUnit.Ampere);
        (current1 + current2).ShouldBe(expected);
        (current2 + current1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        ElectricCurrent current1 = new(2000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(2, ElectricCurrentUnit.KiloAmpere);
        (current1 / current2).ShouldBeCloseTo(1);
        (current2 / current1).ShouldBeCloseTo(1);

        (current1 / 2).ShouldBe(new ElectricCurrent(1000, ElectricCurrentUnit.Ampere));
        (current2 / 2).ShouldBe(new ElectricCurrent(1, ElectricCurrentUnit.KiloAmpere));
    }

    [Fact]
    public void OpEquals() {
        ElectricCurrent current1 = new(3000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(3, ElectricCurrentUnit.KiloAmpere);
        ElectricCurrent current3 = new(6, ElectricCurrentUnit.KiloAmpere);
        (current1 == current2).ShouldBeTrue();
        (current2 == current1).ShouldBeTrue();
        (current1 == current3).ShouldBeFalse();
        (current3 == current1).ShouldBeFalse();
        current1.Equals(current2).ShouldBeTrue();
        current1.Equals((object)current2).ShouldBeTrue();
        current2.Equals(current1).ShouldBeTrue();
        current2.Equals((object)current1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        ElectricCurrent current1 = new(3000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(3, ElectricCurrentUnit.KiloAmpere);
        ElectricCurrent current3 = new(6, ElectricCurrentUnit.KiloAmpere);
        (current1 > current3).ShouldBeFalse();
        (current3 > current1).ShouldBeTrue();
        (current1 > current2).ShouldBeFalse();
        (current2 > current1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        ElectricCurrent current1 = new(3000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(3, ElectricCurrentUnit.KiloAmpere);
        ElectricCurrent current3 = new(6, ElectricCurrentUnit.KiloAmpere);
        (current1 >= current3).ShouldBeFalse();
        (current3 >= current1).ShouldBeTrue();
        (current1 >= current2).ShouldBeTrue();
        (current2 >= current1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        ElectricCurrent current1 = new(3000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(3, ElectricCurrentUnit.KiloAmpere);
        ElectricCurrent current3 = new(6, ElectricCurrentUnit.KiloAmpere);
        (current1 != current2).ShouldBeFalse();
        (current2 != current1).ShouldBeFalse();
        (current1 != current3).ShouldBeTrue();
        (current3 != current1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        ElectricCurrent current1 = new(3000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(3, ElectricCurrentUnit.KiloAmpere);
        ElectricCurrent current3 = new(6, ElectricCurrentUnit.KiloAmpere);
        (current1 < current3).ShouldBeTrue();
        (current3 < current1).ShouldBeFalse();
        (current1 < current2).ShouldBeFalse();
        (current2 < current1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        ElectricCurrent current1 = new(3000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(3, ElectricCurrentUnit.KiloAmpere);
        ElectricCurrent current3 = new(6, ElectricCurrentUnit.KiloAmpere);
        (current1 <= current3).ShouldBeTrue();
        (current3 <= current1).ShouldBeFalse();
        (current1 <= current2).ShouldBeTrue();
        (current2 <= current1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        ElectricCurrent current = new(1, ElectricCurrentUnit.Ampere);
        ElectricCurrent expected = new(2, ElectricCurrentUnit.Ampere);
        (current * 2).ShouldBe(expected);
        (2 * current).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        ElectricCurrent current1 = new(7000, ElectricCurrentUnit.Ampere);
        ElectricCurrent current2 = new(1, ElectricCurrentUnit.KiloAmpere);
        (current1 - current2).ShouldBe(new ElectricCurrent(6000, ElectricCurrentUnit.Ampere));
        (current2 - current1).ShouldBe(new ElectricCurrent(-6, ElectricCurrentUnit.KiloAmpere));
    }

}