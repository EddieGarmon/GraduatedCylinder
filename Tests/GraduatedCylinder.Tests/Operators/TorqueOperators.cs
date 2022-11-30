using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class TorqueOperators
{

    [Fact]
    public void OpAddition() {
        Torque torque1 = new(9.81, TorqueUnit.NewtonMeters);
        Torque torque2 = new(1, TorqueUnit.KiloGramForceMeters);
        Torque expected = new(19.62, TorqueUnit.NewtonMeters);
        (torque1 + torque2).ShouldBe(expected);
        (torque2 + torque1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Torque torque1 = new(19.62, TorqueUnit.NewtonMeters);
        Torque torque2 = new(2, TorqueUnit.KiloGramForceMeters);
        (torque1 / torque2).ShouldBeCloseTo(1);
        (torque2 / torque1).ShouldBeCloseTo(1);

        (torque1 / 2).ShouldBe(new Torque(9.81, TorqueUnit.NewtonMeters));
        (torque2 / 2).ShouldBe(new Torque(1, TorqueUnit.KiloGramForceMeters));
    }

    [Fact]
    public void OpEquals() {
        Torque torque1 = new(19.62, TorqueUnit.NewtonMeters);
        Torque torque2 = new(2, TorqueUnit.KiloGramForceMeters);
        Torque torque3 = new(3, TorqueUnit.KiloGramForceMeters);
        (torque1 == torque2).ShouldBeTrue();
        (torque2 == torque1).ShouldBeTrue();
        (torque1 == torque3).ShouldBeFalse();
        (torque3 == torque1).ShouldBeFalse();
        torque1.Equals(torque2).ShouldBeTrue();
        torque1.Equals((object)torque2).ShouldBeTrue();
        torque2.Equals(torque1).ShouldBeTrue();
        torque2.Equals((object)torque1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        Torque torque1 = new(19.62, TorqueUnit.NewtonMeters);
        Torque torque2 = new(2, TorqueUnit.KiloGramForceMeters);
        Torque torque3 = new(3, TorqueUnit.KiloGramForceMeters);
        (torque1 > torque3).ShouldBeFalse();
        (torque3 > torque1).ShouldBeTrue();
        (torque1 > torque2).ShouldBeFalse();
        (torque2 > torque1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Torque torque1 = new(19.62, TorqueUnit.NewtonMeters);
        Torque torque2 = new(2, TorqueUnit.KiloGramForceMeters);
        Torque torque3 = new(3, TorqueUnit.KiloGramForceMeters);
        (torque1 >= torque3).ShouldBeFalse();
        (torque3 >= torque1).ShouldBeTrue();
        (torque1 >= torque2).ShouldBeTrue();
        (torque2 >= torque1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Torque torque1 = new(19.62, TorqueUnit.NewtonMeters);
        Torque torque2 = new(2, TorqueUnit.KiloGramForceMeters);
        Torque torque3 = new(3, TorqueUnit.KiloGramForceMeters);
        (torque1 != torque2).ShouldBeFalse();
        (torque2 != torque1).ShouldBeFalse();
        (torque1 != torque3).ShouldBeTrue();
        (torque3 != torque1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Torque torque1 = new(19.62, TorqueUnit.NewtonMeters);
        Torque torque2 = new(2, TorqueUnit.KiloGramForceMeters);
        Torque torque3 = new(3, TorqueUnit.KiloGramForceMeters);
        (torque1 < torque3).ShouldBeTrue();
        (torque3 < torque1).ShouldBeFalse();
        (torque1 < torque2).ShouldBeFalse();
        (torque2 < torque1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Torque torque1 = new(19.62, TorqueUnit.NewtonMeters);
        Torque torque2 = new(2, TorqueUnit.KiloGramForceMeters);
        Torque torque3 = new(3, TorqueUnit.KiloGramForceMeters);
        (torque1 <= torque3).ShouldBeTrue();
        (torque3 <= torque1).ShouldBeFalse();
        (torque1 <= torque2).ShouldBeTrue();
        (torque2 <= torque1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Torque torque = new(1, TorqueUnit.NewtonMeters);
        Torque expected = new(2, TorqueUnit.NewtonMeters);
        (torque * 2).ShouldBe(expected);
        (2 * torque).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Torque torque1 = new(19.62, TorqueUnit.NewtonMeters);
        Torque torque2 = new(1, TorqueUnit.KiloGramForceMeters);
        (torque1 - torque2).ShouldBe(new Torque(9.81, TorqueUnit.NewtonMeters));
        (torque2 - torque1).ShouldBe(new Torque(-1, TorqueUnit.KiloGramForceMeters));
    }

}