using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class PowerOperators
{
    [Fact]
    public void OpAddition() {
        var power1 = new Power(6000, PowerUnit.Watts);
        var power2 = new Power(1, PowerUnit.Kilowatts);
        var expected = new Power(7000, PowerUnit.Watts);
        (power1 + power2).ShouldBe(expected);
        (power2 + power1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var power1 = new Power(2000, PowerUnit.Watts);
        var power2 = new Power(2, PowerUnit.Kilowatts);
        (power1 / power2).ShouldBeWithinToleranceOf(1);
        (power2 / power1).ShouldBeWithinToleranceOf(1);

        (power1 / 2).ShouldBe(new Power(1000, PowerUnit.Watts));
        (power2 / 2).ShouldBe(new Power(1, PowerUnit.Kilowatts));
    }

    [Fact]
    public void OpEquals() {
        var power1 = new Power(3000, PowerUnit.Watts);
        var power2 = new Power(3, PowerUnit.Kilowatts);
        var power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
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
        var power1 = new Power(3000, PowerUnit.Watts);
        var power2 = new Power(3, PowerUnit.Kilowatts);
        var power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 > power3).ShouldBeFalse();
        (power3 > power1).ShouldBeTrue();
        (power1 > power2).ShouldBeFalse();
        (power2 > power1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var power1 = new Power(3000, PowerUnit.Watts);
        var power2 = new Power(3, PowerUnit.Kilowatts);
        var power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 >= power3).ShouldBeFalse();
        (power3 >= power1).ShouldBeTrue();
        (power1 >= power2).ShouldBeTrue();
        (power2 >= power1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var power1 = new Power(3000, PowerUnit.Watts);
        var power2 = new Power(3, PowerUnit.Kilowatts);
        var power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 != power2).ShouldBeFalse();
        (power2 != power1).ShouldBeFalse();
        (power1 != power3).ShouldBeTrue();
        (power3 != power1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var power1 = new Power(3000, PowerUnit.Watts);
        var power2 = new Power(3, PowerUnit.Kilowatts);
        var power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 < power3).ShouldBeTrue();
        (power3 < power1).ShouldBeFalse();
        (power1 < power2).ShouldBeFalse();
        (power2 < power1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var power1 = new Power(3000, PowerUnit.Watts);
        var power2 = new Power(3, PowerUnit.Kilowatts);
        var power3 = new Power(5000, PowerUnit.NewtonMetersPerSecond);
        (power1 <= power3).ShouldBeTrue();
        (power3 <= power1).ShouldBeFalse();
        (power1 <= power2).ShouldBeTrue();
        (power2 <= power1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var power = new Power(1, PowerUnit.Kilowatts);
        var expected = new Power(2, PowerUnit.Kilowatts);
        (power * 2).ShouldBe(expected);
        (2 * power).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var power1 = new Power(5000, PowerUnit.Watts);
        var power2 = new Power(1, PowerUnit.Kilowatts);
        (power1 - power2).ShouldBe(new Power(4000, PowerUnit.Watts));
        (power2 - power1).ShouldBe(new Power(-4, PowerUnit.Kilowatts));
    }
}