#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class EnergyOperators
{

    [Fact]
    public void OpAddition() {
        Energy energy1 = new(2000, EnergyUnit.NewtonMeters);
        Energy energy2 = new(2, EnergyUnit.KiloJoules);
        Energy expected = new(4000, EnergyUnit.NewtonMeters);
        (energy1 + energy2).ShouldBe(expected);
        (energy2 + energy1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Energy energy1 = new(2000, EnergyUnit.NewtonMeters);
        Energy energy2 = new(2, EnergyUnit.KiloJoules);
        (energy1 / energy2).ShouldBeCloseTo(1);
        (energy2 / energy1).ShouldBeCloseTo(1);

        (energy1 / 2).ShouldBe(new Energy(1000, EnergyUnit.NewtonMeters));
        (energy2 / 2).ShouldBe(new Energy(1, EnergyUnit.KiloJoules));
    }

    [Fact]
    public void OpEquals() {
        Energy energy1 = new(2000, EnergyUnit.NewtonMeters);
        Energy energy2 = new(2, EnergyUnit.KiloJoules);
        Energy energy3 = new(4000, EnergyUnit.Joules);
        (energy1 == energy2).ShouldBeTrue();
        (energy2 == energy1).ShouldBeTrue();
        (energy1 == energy3).ShouldBeFalse();
        (energy3 == energy1).ShouldBeFalse();
        energy1.Equals(energy2).ShouldBeTrue();
        energy1.Equals((object)energy2).ShouldBeTrue();
        energy2.Equals(energy1).ShouldBeTrue();
        energy2.Equals((object)energy1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        Energy energy1 = new(2000, EnergyUnit.NewtonMeters);
        Energy energy2 = new(2, EnergyUnit.KiloJoules);
        Energy energy3 = new(4000, EnergyUnit.Joules);
        (energy1 > energy3).ShouldBeFalse();
        (energy3 > energy1).ShouldBeTrue();
        (energy1 > energy2).ShouldBeFalse();
        (energy2 > energy1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Energy energy1 = new(2000, EnergyUnit.NewtonMeters);
        Energy energy2 = new(2, EnergyUnit.KiloJoules);
        Energy energy3 = new(4000, EnergyUnit.Joules);
        (energy1 >= energy3).ShouldBeFalse();
        (energy3 >= energy1).ShouldBeTrue();
        (energy1 >= energy2).ShouldBeTrue();
        (energy2 >= energy1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Energy energy1 = new(2000, EnergyUnit.NewtonMeters);
        Energy energy2 = new(2, EnergyUnit.KiloJoules);
        Energy energy3 = new(4000, EnergyUnit.Joules);
        (energy1 != energy2).ShouldBeFalse();
        (energy2 != energy1).ShouldBeFalse();
        (energy1 != energy3).ShouldBeTrue();
        (energy3 != energy1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Energy energy1 = new(2000, EnergyUnit.NewtonMeters);
        Energy energy2 = new(2, EnergyUnit.KiloJoules);
        Energy energy3 = new(4000, EnergyUnit.Joules);
        (energy1 < energy3).ShouldBeTrue();
        (energy3 < energy1).ShouldBeFalse();
        (energy1 < energy2).ShouldBeFalse();
        (energy2 < energy1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Energy energy1 = new(2000, EnergyUnit.NewtonMeters);
        Energy energy2 = new(2, EnergyUnit.KiloJoules);
        Energy energy3 = new(4000, EnergyUnit.Joules);
        (energy1 <= energy3).ShouldBeTrue();
        (energy3 <= energy1).ShouldBeFalse();
        (energy1 <= energy2).ShouldBeTrue();
        (energy2 <= energy1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Energy energy = new(1, EnergyUnit.KiloJoules);
        Energy expected = new(2, EnergyUnit.KiloJoules);
        (energy * 2).ShouldBe(expected);
        (2 * energy).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Energy energy1 = new(2000, EnergyUnit.Joules);
        Energy energy2 = new(1, EnergyUnit.KiloJoules);
        (energy1 - energy2).ShouldBe(new Energy(1000, EnergyUnit.Joules));
        (energy2 - energy1).ShouldBe(new Energy(-1, EnergyUnit.KiloJoules));
    }

}