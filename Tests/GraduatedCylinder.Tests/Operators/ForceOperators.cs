#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class ForceOperators
{

    [Fact]
    public void OpAddition() {
        Force force1 = new(9.81, ForceUnit.Newtons);
        Force force2 = new(1, ForceUnit.KiloGramForce);
        Force expected = new(19.62, ForceUnit.Newtons);
        (force1 + force2).ShouldBe(expected);
        (force2 + force1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Force force1 = new(19.62, ForceUnit.Newtons);
        Force force2 = new(2, ForceUnit.KiloGramForce);
        (force1 / force2).ShouldBeCloseTo(1);
        (force2 / force1).ShouldBeCloseTo(1);

        (force1 / 2).ShouldBe(new Force(9.81, ForceUnit.Newtons));
        (force2 / 2).ShouldBe(new Force(1, ForceUnit.KiloGramForce));
    }

    [Fact]
    public void OpEquals() {
        Force force1 = new(9.81, ForceUnit.Newtons);
        Force force2 = new(1, ForceUnit.KiloGramForce);
        Force force3 = new(2, ForceUnit.KiloGramForce);
        (force1 == force2).ShouldBeTrue();
        (force2 == force1).ShouldBeTrue();
        (force1 == force3).ShouldBeFalse();
        (force3 == force1).ShouldBeFalse();
        force1.Equals(force2).ShouldBeTrue();
        force1.Equals((object)force2).ShouldBeTrue();
        force2.Equals(force1).ShouldBeTrue();
        force2.Equals((object)force1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        Force force1 = new(9.81, ForceUnit.Newtons);
        Force force2 = new(1, ForceUnit.KiloGramForce);
        Force force3 = new(2, ForceUnit.KiloGramForce);
        (force1 > force3).ShouldBeFalse();
        (force3 > force1).ShouldBeTrue();
        (force1 > force2).ShouldBeFalse();
        (force2 > force1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Force force1 = new(9.81, ForceUnit.Newtons);
        Force force2 = new(1, ForceUnit.KiloGramForce);
        Force force3 = new(2, ForceUnit.KiloGramForce);
        (force1 >= force3).ShouldBeFalse();
        (force3 >= force1).ShouldBeTrue();
        (force1 >= force2).ShouldBeTrue();
        (force2 >= force1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Force force1 = new(9.81, ForceUnit.Newtons);
        Force force2 = new(1, ForceUnit.KiloGramForce);
        Force force3 = new(2, ForceUnit.KiloGramForce);
        (force1 != force2).ShouldBeFalse();
        (force2 != force1).ShouldBeFalse();
        (force1 != force3).ShouldBeTrue();
        (force3 != force1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Force force1 = new(9.81, ForceUnit.Newtons);
        Force force2 = new(1, ForceUnit.KiloGramForce);
        Force force3 = new(2, ForceUnit.KiloGramForce);
        (force1 < force3).ShouldBeTrue();
        (force3 < force1).ShouldBeFalse();
        (force1 < force2).ShouldBeFalse();
        (force2 < force1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Force force1 = new(9.81, ForceUnit.Newtons);
        Force force2 = new(1, ForceUnit.KiloGramForce);
        Force force3 = new(2, ForceUnit.KiloGramForce);
        (force1 <= force3).ShouldBeTrue();
        (force3 <= force1).ShouldBeFalse();
        (force1 <= force2).ShouldBeTrue();
        (force2 <= force1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Force force = new(1, ForceUnit.KiloGramForce);
        Force expected = new(2, ForceUnit.KiloGramForce);
        (force * 2).ShouldBe(expected);
        (2 * force).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Force force1 = new(19.62, ForceUnit.Newtons);
        Force force2 = new(1, ForceUnit.KiloGramForce);
        (force1 - force2).ShouldBe(new Force(9.81, ForceUnit.Newtons));
        (force2 - force1).ShouldBe(new Force(-1, ForceUnit.KiloGramForce));
    }

}