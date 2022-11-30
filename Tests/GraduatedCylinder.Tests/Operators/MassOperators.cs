using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class MassOperators
{

    [Fact]
    public void OpAddition() {
        Mass mass1 = new(2000, MassUnit.Gram);
        Mass mass2 = new(1, MassUnit.KiloGram);
        Mass expected = new(3000, MassUnit.Gram);
        (mass1 + mass2).ShouldBe(expected);
        (mass2 + mass1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Mass mass1 = new(2000, MassUnit.Gram);
        Mass mass2 = new(2, MassUnit.KiloGram);
        (mass1 / mass2).ShouldBeCloseTo(1);
        (mass2 / mass1).ShouldBeCloseTo(1);

        (mass1 / 2).ShouldBe(new Mass(1000, MassUnit.Gram));
        (mass2 / 2).ShouldBe(new Mass(1, MassUnit.KiloGram));
    }

    [Fact]
    public void OpEquals() {
        Mass mass1 = new(3000, MassUnit.Gram);
        Mass mass2 = new(3, MassUnit.KiloGram);
        Mass mass3 = new(4, MassUnit.KiloGram);
        (mass1 == mass2).ShouldBeTrue();
        (mass2 == mass1).ShouldBeTrue();
        (mass1 == mass3).ShouldBeFalse();
        (mass3 == mass1).ShouldBeFalse();
        mass1.Equals(mass2).ShouldBeTrue();
        mass1.Equals((object)mass2).ShouldBeTrue();
        mass2.Equals(mass1).ShouldBeTrue();
        mass2.Equals((object)mass1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        Mass mass1 = new(3000, MassUnit.Gram);
        Mass mass2 = new(3, MassUnit.KiloGram);
        Mass mass3 = new(4, MassUnit.KiloGram);
        (mass1 > mass3).ShouldBeFalse();
        (mass3 > mass1).ShouldBeTrue();
        (mass1 > mass2).ShouldBeFalse();
        (mass2 > mass1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Mass mass1 = new(3000, MassUnit.Gram);
        Mass mass2 = new(3, MassUnit.KiloGram);
        Mass mass3 = new(4, MassUnit.KiloGram);
        (mass1 >= mass3).ShouldBeFalse();
        (mass3 >= mass1).ShouldBeTrue();
        (mass1 >= mass2).ShouldBeTrue();
        (mass2 >= mass1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Mass mass1 = new(3000, MassUnit.Gram);
        Mass mass2 = new(3, MassUnit.KiloGram);
        Mass mass3 = new(4, MassUnit.KiloGram);
        (mass1 != mass2).ShouldBeFalse();
        (mass2 != mass1).ShouldBeFalse();
        (mass1 != mass3).ShouldBeTrue();
        (mass3 != mass1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Mass mass1 = new(3000, MassUnit.Gram);
        Mass mass2 = new(3, MassUnit.KiloGram);
        Mass mass3 = new(4, MassUnit.KiloGram);
        (mass1 < mass3).ShouldBeTrue();
        (mass3 < mass1).ShouldBeFalse();
        (mass1 < mass2).ShouldBeFalse();
        (mass2 < mass1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Mass mass1 = new(3000, MassUnit.Gram);
        Mass mass2 = new(3, MassUnit.KiloGram);
        Mass mass3 = new(4, MassUnit.KiloGram);
        (mass1 <= mass3).ShouldBeTrue();
        (mass3 <= mass1).ShouldBeFalse();
        (mass1 <= mass2).ShouldBeTrue();
        (mass2 <= mass1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Mass mass = new(1, MassUnit.KiloGram);
        Mass expected = new(2, MassUnit.KiloGram);
        (mass * 2).ShouldBe(expected);
        (2 * mass).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Mass mass1 = new(7000, MassUnit.Gram);
        Mass mass2 = new(1, MassUnit.KiloGram);
        (mass1 - mass2).ShouldBe(new Mass(6000, MassUnit.Gram));
        (mass2 - mass1).ShouldBe(new Mass(-6, MassUnit.KiloGram));
    }

}