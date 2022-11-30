using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class VolumeOperators
{

    [Fact]
    public void OpAddition() {
        Volume volume1 = new(3600, VolumeUnit.Liters);
        Volume volume2 = new(1, VolumeUnit.CubicMeters);
        Volume expected = new(4600, VolumeUnit.Liters);
        (volume1 + volume2).ShouldBe(expected);
        (volume2 + volume1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Volume volume1 = new(3600, VolumeUnit.Liters);
        Volume volume2 = new(3.6, VolumeUnit.CubicMeters);
        (volume1 / volume2).ShouldBeCloseTo(1);
        (volume2 / volume1).ShouldBeCloseTo(1);

        (volume1 / 2).ShouldBe(new Volume(1800, VolumeUnit.Liters));
        (volume2 / 2).ShouldBe(new Volume(1.8, VolumeUnit.CubicMeters));
    }

    [Fact]
    public void OpEquals() {
        Volume volume1 = new(3600, VolumeUnit.Liters);
        Volume volume2 = new(3.6, VolumeUnit.CubicMeters);
        Volume volume3 = new(5, VolumeUnit.CubicMeters);
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
        Volume volume1 = new(3600, VolumeUnit.Liters);
        Volume volume2 = new(3.6, VolumeUnit.CubicMeters);
        Volume volume3 = new(5, VolumeUnit.CubicMeters);
        (volume1 > volume3).ShouldBeFalse();
        (volume3 > volume1).ShouldBeTrue();
        (volume1 > volume2).ShouldBeFalse();
        (volume2 > volume1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Volume volume1 = new(3600, VolumeUnit.Liters);
        Volume volume2 = new(3.6, VolumeUnit.CubicMeters);
        Volume volume3 = new(5, VolumeUnit.CubicMeters);
        (volume1 >= volume3).ShouldBeFalse();
        (volume3 >= volume1).ShouldBeTrue();
        (volume1 >= volume2).ShouldBeTrue();
        (volume2 >= volume1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Volume volume1 = new(3600, VolumeUnit.Liters);
        Volume volume2 = new(3.6, VolumeUnit.CubicMeters);
        Volume volume3 = new(5, VolumeUnit.CubicMeters);
        (volume1 != volume2).ShouldBeFalse();
        (volume2 != volume1).ShouldBeFalse();
        (volume1 != volume3).ShouldBeTrue();
        (volume3 != volume1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Volume volume1 = new(3600, VolumeUnit.Liters);
        Volume volume2 = new(3.6, VolumeUnit.CubicMeters);
        Volume volume3 = new(5, VolumeUnit.CubicMeters);
        (volume1 < volume3).ShouldBeTrue();
        (volume3 < volume1).ShouldBeFalse();
        (volume1 < volume2).ShouldBeFalse();
        (volume2 < volume1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Volume volume1 = new(3600, VolumeUnit.Liters);
        Volume volume2 = new(3.6, VolumeUnit.CubicMeters);
        Volume volume3 = new(5, VolumeUnit.CubicMeters);
        (volume1 <= volume3).ShouldBeTrue();
        (volume3 <= volume1).ShouldBeFalse();
        (volume1 <= volume2).ShouldBeTrue();
        (volume2 <= volume1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Volume volume = new(1, VolumeUnit.Liters);
        Volume expected = new(2, VolumeUnit.Liters);
        (volume * 2).ShouldBe(expected);
        (2 * volume).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Volume volume1 = new(7200, VolumeUnit.Liters);
        Volume volume2 = new(1, VolumeUnit.CubicMeters);
        (volume1 - volume2).ShouldBe(new Volume(6200, VolumeUnit.Liters));
        (volume2 - volume1).ShouldBe(new Volume(-6.2, VolumeUnit.CubicMeters));
    }

}