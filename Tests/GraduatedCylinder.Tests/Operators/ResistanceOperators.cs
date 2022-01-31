using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class ElectricResistanceOperators
{
    [Fact]
    public void OpAddition() {
        var resistance1 = new ElectricResistance(3000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(1, ElectricResistanceUnit.Kiloohm);
        var expected = new ElectricResistance(4000, ElectricResistanceUnit.Ohm);
        (resistance1 + resistance2).ShouldBe(expected);
        (resistance2 + resistance1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var resistance1 = new ElectricResistance(2000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(2, ElectricResistanceUnit.Kiloohm);
        (resistance1 / resistance2).ShouldBeCloseTo(1);
        (resistance2 / resistance1).ShouldBeCloseTo(1);

        (resistance1 / 2).ShouldBe(new ElectricResistance(1000, ElectricResistanceUnit.Ohm));
        (resistance2 / 2).ShouldBe(new ElectricResistance(1, ElectricResistanceUnit.Kiloohm));
    }

    [Fact]
    public void OpEquals() {
        var resistance1 = new ElectricResistance(3000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(3, ElectricResistanceUnit.Kiloohm);
        var resistance3 = new ElectricResistance(4, ElectricResistanceUnit.Kiloohm);
        (resistance1 == resistance2).ShouldBeTrue();
        (resistance2 == resistance1).ShouldBeTrue();
        (resistance1 == resistance3).ShouldBeFalse();
        (resistance3 == resistance1).ShouldBeFalse();
        resistance1.Equals(resistance2).ShouldBeTrue();
        resistance1.Equals((object)resistance2).ShouldBeTrue();
        resistance2.Equals(resistance1).ShouldBeTrue();
        resistance2.Equals((object)resistance1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        var resistance1 = new ElectricResistance(3000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(3, ElectricResistanceUnit.Kiloohm);
        var resistance3 = new ElectricResistance(4, ElectricResistanceUnit.Kiloohm);
        (resistance1 > resistance3).ShouldBeFalse();
        (resistance3 > resistance1).ShouldBeTrue();
        (resistance1 > resistance2).ShouldBeFalse();
        (resistance2 > resistance1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var resistance1 = new ElectricResistance(3000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(3, ElectricResistanceUnit.Kiloohm);
        var resistance3 = new ElectricResistance(4, ElectricResistanceUnit.Kiloohm);
        (resistance1 >= resistance3).ShouldBeFalse();
        (resistance3 >= resistance1).ShouldBeTrue();
        (resistance1 >= resistance2).ShouldBeTrue();
        (resistance2 >= resistance1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var resistance1 = new ElectricResistance(3000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(3, ElectricResistanceUnit.Kiloohm);
        var resistance3 = new ElectricResistance(4, ElectricResistanceUnit.Kiloohm);
        (resistance1 != resistance2).ShouldBeFalse();
        (resistance2 != resistance1).ShouldBeFalse();
        (resistance1 != resistance3).ShouldBeTrue();
        (resistance3 != resistance1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var resistance1 = new ElectricResistance(3000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(3, ElectricResistanceUnit.Kiloohm);
        var resistance3 = new ElectricResistance(4, ElectricResistanceUnit.Kiloohm);
        (resistance1 < resistance3).ShouldBeTrue();
        (resistance3 < resistance1).ShouldBeFalse();
        (resistance1 < resistance2).ShouldBeFalse();
        (resistance2 < resistance1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var resistance1 = new ElectricResistance(3000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(3, ElectricResistanceUnit.Kiloohm);
        var resistance3 = new ElectricResistance(4, ElectricResistanceUnit.Kiloohm);
        (resistance1 <= resistance3).ShouldBeTrue();
        (resistance3 <= resistance1).ShouldBeFalse();
        (resistance1 <= resistance2).ShouldBeTrue();
        (resistance2 <= resistance1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var resistance = new ElectricResistance(1, ElectricResistanceUnit.Ohm);
        var expected = new ElectricResistance(2, ElectricResistanceUnit.Ohm);
        (resistance * 2).ShouldBe(expected);
        (2 * resistance).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var resistance1 = new ElectricResistance(7000, ElectricResistanceUnit.Ohm);
        var resistance2 = new ElectricResistance(1, ElectricResistanceUnit.Kiloohm);
        (resistance1 - resistance2).ShouldBe(new ElectricResistance(6000, ElectricResistanceUnit.Ohm));
        (resistance2 - resistance1).ShouldBe(new ElectricResistance(-6, ElectricResistanceUnit.Kiloohm));
    }
}