using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class PowerOperators
{

    [Fact]
    public void OpAddition() {
        Power power1 = new(6000, PowerUnit.Watts);
        Power power2 = new(1, PowerUnit.KiloWatts);
        Power expected = new(7000, PowerUnit.Watts);
        (power1 + power2).ShouldBe(expected);
        (power2 + power1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Power power1 = new(2000, PowerUnit.Watts);
        Power power2 = new(2, PowerUnit.KiloWatts);
        (power1 / power2).ShouldBeCloseTo(1);
        (power2 / power1).ShouldBeCloseTo(1);

        (power1 / 2).ShouldBe(new Power(1000, PowerUnit.Watts));
        (power2 / 2).ShouldBe(new Power(1, PowerUnit.KiloWatts));
    }

    [Fact]
    public void OpEquals() {
        Power power1 = new(3000, PowerUnit.Watts);
        Power power2 = new(3, PowerUnit.KiloWatts);
        Power power3 = new(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 == power2).ShouldBeTrue();
        (power2 == power1).ShouldBeTrue();
        (power1 == power3).ShouldBeFalse();
        (power3 == power1).ShouldBeFalse();
        power1.Equals(power2).ShouldBeTrue();
        power1.Equals((object)power2).ShouldBeTrue();
        power2.Equals(power1).ShouldBeTrue();
        power2.Equals((object)power1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        Power power1 = new(3000, PowerUnit.Watts);
        Power power2 = new(3, PowerUnit.KiloWatts);
        Power power3 = new(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 > power3).ShouldBeFalse();
        (power3 > power1).ShouldBeTrue();
        (power1 > power2).ShouldBeFalse();
        (power2 > power1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Power power1 = new(3000, PowerUnit.Watts);
        Power power2 = new(3, PowerUnit.KiloWatts);
        Power power3 = new(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 >= power3).ShouldBeFalse();
        (power3 >= power1).ShouldBeTrue();
        (power1 >= power2).ShouldBeTrue();
        (power2 >= power1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Power power1 = new(3000, PowerUnit.Watts);
        Power power2 = new(3, PowerUnit.KiloWatts);
        Power power3 = new(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 != power2).ShouldBeFalse();
        (power2 != power1).ShouldBeFalse();
        (power1 != power3).ShouldBeTrue();
        (power3 != power1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Power power1 = new(3000, PowerUnit.Watts);
        Power power2 = new(3, PowerUnit.KiloWatts);
        Power power3 = new(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 < power3).ShouldBeTrue();
        (power3 < power1).ShouldBeFalse();
        (power1 < power2).ShouldBeFalse();
        (power2 < power1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Power power1 = new(3000, PowerUnit.Watts);
        Power power2 = new(3, PowerUnit.KiloWatts);
        Power power3 = new(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 <= power3).ShouldBeTrue();
        (power3 <= power1).ShouldBeFalse();
        (power1 <= power2).ShouldBeTrue();
        (power2 <= power1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Power power = new(1, PowerUnit.KiloWatts);
        Power expected = new(2, PowerUnit.KiloWatts);
        (power * 2).ShouldBe(expected);
        (2 * power).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Power power1 = new(5000, PowerUnit.Watts);
        Power power2 = new(1, PowerUnit.KiloWatts);
        (power1 - power2).ShouldBe(new Power(4000, PowerUnit.Watts));
        (power2 - power1).ShouldBe(new Power(-4, PowerUnit.KiloWatts));
    }

}