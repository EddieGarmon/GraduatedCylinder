using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class VolumetricFlowRateOperators
{
    [Fact]
    public void OpAddition() {
        var volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(1, VolumetricFlowRateUnit.LitersPerMinute);
        var expected = new VolumetricFlowRate(3660, VolumetricFlowRateUnit.LitersPerHour);
        (volumetricFlowRate1 + volumetricFlowRate2).ShouldBe(expected);
        (volumetricFlowRate2 + volumetricFlowRate1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 / volumetricFlowRate2).ShouldBeCloseTo(1);
        (volumetricFlowRate2 / volumetricFlowRate1).ShouldBeCloseTo(1);

        (volumetricFlowRate1 / 2).ShouldBe(new VolumetricFlowRate(1800, VolumetricFlowRateUnit.LitersPerHour));
        (volumetricFlowRate2 / 2).ShouldBe(new VolumetricFlowRate(30, VolumetricFlowRateUnit.LitersPerMinute));
    }

    [Fact]
    public void OpEquals() {
        var volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
        var volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 == volumetricFlowRate2).ShouldBeTrue();
        (volumetricFlowRate2 == volumetricFlowRate1).ShouldBeTrue();
        (volumetricFlowRate1 == volumetricFlowRate3).ShouldBeFalse();
        (volumetricFlowRate3 == volumetricFlowRate1).ShouldBeFalse();
        volumetricFlowRate1.Equals(volumetricFlowRate2).ShouldBeTrue();
        volumetricFlowRate1.Equals((object)volumetricFlowRate2).ShouldBeTrue();
        volumetricFlowRate2.Equals(volumetricFlowRate1).ShouldBeTrue();
        volumetricFlowRate2.Equals((object)volumetricFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        var volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
        var volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 > volumetricFlowRate3).ShouldBeFalse();
        (volumetricFlowRate3 > volumetricFlowRate1).ShouldBeTrue();
        (volumetricFlowRate1 > volumetricFlowRate2).ShouldBeFalse();
        (volumetricFlowRate2 > volumetricFlowRate1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
        var volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 >= volumetricFlowRate3).ShouldBeFalse();
        (volumetricFlowRate3 >= volumetricFlowRate1).ShouldBeTrue();
        (volumetricFlowRate1 >= volumetricFlowRate2).ShouldBeTrue();
        (volumetricFlowRate2 >= volumetricFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
        var volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 != volumetricFlowRate2).ShouldBeFalse();
        (volumetricFlowRate2 != volumetricFlowRate1).ShouldBeFalse();
        (volumetricFlowRate1 != volumetricFlowRate3).ShouldBeTrue();
        (volumetricFlowRate3 != volumetricFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
        var volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 < volumetricFlowRate3).ShouldBeTrue();
        (volumetricFlowRate3 < volumetricFlowRate1).ShouldBeFalse();
        (volumetricFlowRate1 < volumetricFlowRate2).ShouldBeFalse();
        (volumetricFlowRate2 < volumetricFlowRate1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
        var volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 <= volumetricFlowRate3).ShouldBeTrue();
        (volumetricFlowRate3 <= volumetricFlowRate1).ShouldBeFalse();
        (volumetricFlowRate1 <= volumetricFlowRate2).ShouldBeTrue();
        (volumetricFlowRate2 <= volumetricFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var volumetricFlowRate = new VolumetricFlowRate(1, VolumetricFlowRateUnit.LitersPerHour);
        var expected = new VolumetricFlowRate(2, VolumetricFlowRateUnit.LitersPerHour);
        (volumetricFlowRate * 2).ShouldBe(expected);
        (2 * volumetricFlowRate).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var volumetricFlowRate1 = new VolumetricFlowRate(720, VolumetricFlowRateUnit.LitersPerHour);
        var volumetricFlowRate2 = new VolumetricFlowRate(1, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 - volumetricFlowRate2).ShouldBe(
            new VolumetricFlowRate(660, VolumetricFlowRateUnit.LitersPerHour));
        (volumetricFlowRate2 - volumetricFlowRate1).ShouldBe(
            new VolumetricFlowRate(-11, VolumetricFlowRateUnit.LitersPerMinute));
    }
}