using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class ElectricResistanceOperators
{

    [Fact]
    public void OpAddition() {
        ElectricResistance resistance1 = new(3000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(1, ElectricResistanceUnit.KiloOhm);
        ElectricResistance expected = new(4000, ElectricResistanceUnit.Ohm);
        (resistance1 + resistance2).ShouldBe(expected);
        (resistance2 + resistance1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        ElectricResistance resistance1 = new(2000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(2, ElectricResistanceUnit.KiloOhm);
        (resistance1 / resistance2).ShouldBeCloseTo(1);
        (resistance2 / resistance1).ShouldBeCloseTo(1);

        (resistance1 / 2).ShouldBe(new ElectricResistance(1000, ElectricResistanceUnit.Ohm));
        (resistance2 / 2).ShouldBe(new ElectricResistance(1, ElectricResistanceUnit.KiloOhm));
    }

    [Fact]
    public void OpEquals() {
        ElectricResistance resistance1 = new(3000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(3, ElectricResistanceUnit.KiloOhm);
        ElectricResistance resistance3 = new(4, ElectricResistanceUnit.KiloOhm);
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
        ElectricResistance resistance1 = new(3000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(3, ElectricResistanceUnit.KiloOhm);
        ElectricResistance resistance3 = new(4, ElectricResistanceUnit.KiloOhm);
        (resistance1 > resistance3).ShouldBeFalse();
        (resistance3 > resistance1).ShouldBeTrue();
        (resistance1 > resistance2).ShouldBeFalse();
        (resistance2 > resistance1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        ElectricResistance resistance1 = new(3000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(3, ElectricResistanceUnit.KiloOhm);
        ElectricResistance resistance3 = new(4, ElectricResistanceUnit.KiloOhm);
        (resistance1 >= resistance3).ShouldBeFalse();
        (resistance3 >= resistance1).ShouldBeTrue();
        (resistance1 >= resistance2).ShouldBeTrue();
        (resistance2 >= resistance1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        ElectricResistance resistance1 = new(3000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(3, ElectricResistanceUnit.KiloOhm);
        ElectricResistance resistance3 = new(4, ElectricResistanceUnit.KiloOhm);
        (resistance1 != resistance2).ShouldBeFalse();
        (resistance2 != resistance1).ShouldBeFalse();
        (resistance1 != resistance3).ShouldBeTrue();
        (resistance3 != resistance1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        ElectricResistance resistance1 = new(3000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(3, ElectricResistanceUnit.KiloOhm);
        ElectricResistance resistance3 = new(4, ElectricResistanceUnit.KiloOhm);
        (resistance1 < resistance3).ShouldBeTrue();
        (resistance3 < resistance1).ShouldBeFalse();
        (resistance1 < resistance2).ShouldBeFalse();
        (resistance2 < resistance1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        ElectricResistance resistance1 = new(3000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(3, ElectricResistanceUnit.KiloOhm);
        ElectricResistance resistance3 = new(4, ElectricResistanceUnit.KiloOhm);
        (resistance1 <= resistance3).ShouldBeTrue();
        (resistance3 <= resistance1).ShouldBeFalse();
        (resistance1 <= resistance2).ShouldBeTrue();
        (resistance2 <= resistance1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        ElectricResistance resistance = new(1, ElectricResistanceUnit.Ohm);
        ElectricResistance expected = new(2, ElectricResistanceUnit.Ohm);
        (resistance * 2).ShouldBe(expected);
        (2 * resistance).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        ElectricResistance resistance1 = new(7000, ElectricResistanceUnit.Ohm);
        ElectricResistance resistance2 = new(1, ElectricResistanceUnit.KiloOhm);
        (resistance1 - resistance2).ShouldBe(new ElectricResistance(6000, ElectricResistanceUnit.Ohm));
        (resistance2 - resistance1).ShouldBe(new ElectricResistance(-6, ElectricResistanceUnit.KiloOhm));
    }

}