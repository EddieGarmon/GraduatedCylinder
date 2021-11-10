using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class VolumeOperators
{
    [Fact]
    public void OpAddition() {
        var volume1 = new Volume(3600, VolumeUnit.Liters);
        var volume2 = new Volume(1, VolumeUnit.CubicMeters);
        var expected = new Volume(4600, VolumeUnit.Liters);
        (volume1 + volume2).ShouldBe(expected);
        (volume2 + volume1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var volume1 = new Volume(3600, VolumeUnit.Liters);
        var volume2 = new Volume(3.6, VolumeUnit.CubicMeters);
        (volume1 / volume2).ShouldBeWithinToleranceOf(1);
        (volume2 / volume1).ShouldBeWithinToleranceOf(1);

        (volume1 / 2).ShouldBe(new Volume(1800, VolumeUnit.Liters));
        (volume2 / 2).ShouldBe(new Volume(1.8, VolumeUnit.CubicMeters));
    }

    [Fact]
    public void OpEquals() {
        var volume1 = new Volume(3600, VolumeUnit.Liters);
        var volume2 = new Volume(3.6, VolumeUnit.CubicMeters);
        var volume3 = new Volume(5, VolumeUnit.CubicMeters);
        (volume1 == volume2).ShouldBeTrue();
        (volume2 == volume1).ShouldBeTrue();
        (volume1 == volume3).ShouldBeFalse();
        (volume3 == volume1).ShouldBeFalse();
        volume1.Equals(volume2).ShouldBeTrue();
        volume1.Equals((object)volume2).ShouldBeTrue();
        volume2.Equals(volume1).ShouldBeTrue();
        volume2.Equals((object)volume1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        var volume1 = new Volume(3600, VolumeUnit.Liters);
        var volume2 = new Volume(3.6, VolumeUnit.CubicMeters);
        var volume3 = new Volume(5, VolumeUnit.CubicMeters);
        (volume1 > volume3).ShouldBeFalse();
        (volume3 > volume1).ShouldBeTrue();
        (volume1 > volume2).ShouldBeFalse();
        (volume2 > volume1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var volume1 = new Volume(3600, VolumeUnit.Liters);
        var volume2 = new Volume(3.6, VolumeUnit.CubicMeters);
        var volume3 = new Volume(5, VolumeUnit.CubicMeters);
        (volume1 >= volume3).ShouldBeFalse();
        (volume3 >= volume1).ShouldBeTrue();
        (volume1 >= volume2).ShouldBeTrue();
        (volume2 >= volume1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var volume1 = new Volume(3600, VolumeUnit.Liters);
        var volume2 = new Volume(3.6, VolumeUnit.CubicMeters);
        var volume3 = new Volume(5, VolumeUnit.CubicMeters);
        (volume1 != volume2).ShouldBeFalse();
        (volume2 != volume1).ShouldBeFalse();
        (volume1 != volume3).ShouldBeTrue();
        (volume3 != volume1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var volume1 = new Volume(3600, VolumeUnit.Liters);
        var volume2 = new Volume(3.6, VolumeUnit.CubicMeters);
        var volume3 = new Volume(5, VolumeUnit.CubicMeters);
        (volume1 < volume3).ShouldBeTrue();
        (volume3 < volume1).ShouldBeFalse();
        (volume1 < volume2).ShouldBeFalse();
        (volume2 < volume1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var volume1 = new Volume(3600, VolumeUnit.Liters);
        var volume2 = new Volume(3.6, VolumeUnit.CubicMeters);
        var volume3 = new Volume(5, VolumeUnit.CubicMeters);
        (volume1 <= volume3).ShouldBeTrue();
        (volume3 <= volume1).ShouldBeFalse();
        (volume1 <= volume2).ShouldBeTrue();
        (volume2 <= volume1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var volume = new Volume(1, VolumeUnit.Liters);
        var expected = new Volume(2, VolumeUnit.Liters);
        (volume * 2).ShouldBe(expected);
        (2 * volume).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var volume1 = new Volume(7200, VolumeUnit.Liters);
        var volume2 = new Volume(1, VolumeUnit.CubicMeters);
        (volume1 - volume2).ShouldBe(new Volume(6200, VolumeUnit.Liters));
        (volume2 - volume1).ShouldBe(new Volume(-6.2, VolumeUnit.CubicMeters));
    }
}