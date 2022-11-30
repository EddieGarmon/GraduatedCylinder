using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class JerkOperators
{

    [Fact]
    public void OpAddition() {
        Jerk jerk1 = new(1000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(1, JerkUnit.KiloMetersPerSecondCubed);
        Jerk expected = new(2000, JerkUnit.MetersPerSecondCubed);
        (jerk1 + jerk2).ShouldBe(expected);
        (jerk2 + jerk1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Jerk jerk1 = new(1000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(1, JerkUnit.KiloMetersPerSecondCubed);
        (jerk1 / jerk2).ShouldBeCloseTo(1);
        (jerk2 / jerk1).ShouldBeCloseTo(1);

        (jerk1 / 2).ShouldBe(new Jerk(500, JerkUnit.MetersPerSecondCubed));
        (jerk2 / 2).ShouldBe(new Jerk(.5, JerkUnit.KiloMetersPerSecondCubed));
    }

    [Fact]
    public void OpEquals() {
        Jerk jerk1 = new(3000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(3, JerkUnit.KiloMetersPerSecondCubed);
        Jerk jerk3 = new(4, JerkUnit.KiloMetersPerSecondCubed);
        (jerk1 == jerk2).ShouldBeTrue();
        (jerk2 == jerk1).ShouldBeTrue();
        (jerk1 == jerk3).ShouldBeFalse();
        (jerk3 == jerk1).ShouldBeFalse();
        jerk1.Equals(jerk2).ShouldBeTrue();
        jerk1.Equals((object)jerk2).ShouldBeTrue();
        jerk2.Equals(jerk1).ShouldBeTrue();
        jerk2.Equals((object)jerk1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        Jerk jerk1 = new(3000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(3, JerkUnit.KiloMetersPerSecondCubed);
        Jerk jerk3 = new(4, JerkUnit.KiloMetersPerSecondCubed);
        (jerk1 > jerk3).ShouldBeFalse();
        (jerk3 > jerk1).ShouldBeTrue();
        (jerk1 > jerk2).ShouldBeFalse();
        (jerk2 > jerk1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Jerk jerk1 = new(3000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(3, JerkUnit.KiloMetersPerSecondCubed);
        Jerk jerk3 = new(4, JerkUnit.KiloMetersPerSecondCubed);
        (jerk1 >= jerk3).ShouldBeFalse();
        (jerk3 >= jerk1).ShouldBeTrue();
        (jerk1 >= jerk2).ShouldBeTrue();
        (jerk2 >= jerk1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Jerk jerk1 = new(3000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(3, JerkUnit.KiloMetersPerSecondCubed);
        Jerk jerk3 = new(4, JerkUnit.KiloMetersPerSecondCubed);
        (jerk1 != jerk2).ShouldBeFalse();
        (jerk2 != jerk1).ShouldBeFalse();
        (jerk1 != jerk3).ShouldBeTrue();
        (jerk3 != jerk1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Jerk jerk1 = new(3000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(3, JerkUnit.KiloMetersPerSecondCubed);
        Jerk jerk3 = new(4, JerkUnit.KiloMetersPerSecondCubed);
        (jerk1 < jerk3).ShouldBeTrue();
        (jerk3 < jerk1).ShouldBeFalse();
        (jerk1 < jerk2).ShouldBeFalse();
        (jerk2 < jerk1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Jerk jerk1 = new(3000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(3, JerkUnit.KiloMetersPerSecondCubed);
        Jerk jerk3 = new(4, JerkUnit.KiloMetersPerSecondCubed);
        (jerk1 <= jerk3).ShouldBeTrue();
        (jerk3 <= jerk1).ShouldBeFalse();
        (jerk1 <= jerk2).ShouldBeTrue();
        (jerk2 <= jerk1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Jerk jerk = new(1, JerkUnit.KiloMetersPerSecondCubed);
        Jerk expected = new(2, JerkUnit.KiloMetersPerSecondCubed);
        (jerk * 2).ShouldBe(expected);
        (2 * jerk).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Jerk jerk1 = new(2000, JerkUnit.MetersPerSecondCubed);
        Jerk jerk2 = new(1, JerkUnit.KiloMetersPerSecondCubed);
        (jerk1 - jerk2).ShouldBe(new Jerk(1000, JerkUnit.MetersPerSecondCubed));
        (jerk2 - jerk1).ShouldBe(new Jerk(-1, JerkUnit.KiloMetersPerSecondCubed));
    }

}