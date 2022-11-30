using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class VolumetricFlowRateOperators
{

    [Fact]
    public void OpAddition() {
        VolumetricFlowRate volumetricFlowRate1 = new(3600, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(1, VolumetricFlowRateUnit.LitersPerMinute);
        VolumetricFlowRate expected = new(3660, VolumetricFlowRateUnit.LitersPerHour);
        (volumetricFlowRate1 + volumetricFlowRate2).ShouldBe(expected);
        (volumetricFlowRate2 + volumetricFlowRate1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        VolumetricFlowRate volumetricFlowRate1 = new(3600, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(60, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 / volumetricFlowRate2).ShouldBeCloseTo(1);
        (volumetricFlowRate2 / volumetricFlowRate1).ShouldBeCloseTo(1);

        (volumetricFlowRate1 / 2).ShouldBe(new VolumetricFlowRate(1800, VolumetricFlowRateUnit.LitersPerHour));
        (volumetricFlowRate2 / 2).ShouldBe(new VolumetricFlowRate(30, VolumetricFlowRateUnit.LitersPerMinute));
    }

    [Fact]
    public void OpEquals() {
        VolumetricFlowRate volumetricFlowRate1 = new(3600, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(60, VolumetricFlowRateUnit.LitersPerMinute);
        VolumetricFlowRate volumetricFlowRate3 = new(120, VolumetricFlowRateUnit.LitersPerMinute);
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
        VolumetricFlowRate volumetricFlowRate1 = new(3600, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(60, VolumetricFlowRateUnit.LitersPerMinute);
        VolumetricFlowRate volumetricFlowRate3 = new(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 > volumetricFlowRate3).ShouldBeFalse();
        (volumetricFlowRate3 > volumetricFlowRate1).ShouldBeTrue();
        (volumetricFlowRate1 > volumetricFlowRate2).ShouldBeFalse();
        (volumetricFlowRate2 > volumetricFlowRate1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        VolumetricFlowRate volumetricFlowRate1 = new(3600, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(60, VolumetricFlowRateUnit.LitersPerMinute);
        VolumetricFlowRate volumetricFlowRate3 = new(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 >= volumetricFlowRate3).ShouldBeFalse();
        (volumetricFlowRate3 >= volumetricFlowRate1).ShouldBeTrue();
        (volumetricFlowRate1 >= volumetricFlowRate2).ShouldBeTrue();
        (volumetricFlowRate2 >= volumetricFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        VolumetricFlowRate volumetricFlowRate1 = new(3600, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(60, VolumetricFlowRateUnit.LitersPerMinute);
        VolumetricFlowRate volumetricFlowRate3 = new(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 != volumetricFlowRate2).ShouldBeFalse();
        (volumetricFlowRate2 != volumetricFlowRate1).ShouldBeFalse();
        (volumetricFlowRate1 != volumetricFlowRate3).ShouldBeTrue();
        (volumetricFlowRate3 != volumetricFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        VolumetricFlowRate volumetricFlowRate1 = new(3600, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(60, VolumetricFlowRateUnit.LitersPerMinute);
        VolumetricFlowRate volumetricFlowRate3 = new(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 < volumetricFlowRate3).ShouldBeTrue();
        (volumetricFlowRate3 < volumetricFlowRate1).ShouldBeFalse();
        (volumetricFlowRate1 < volumetricFlowRate2).ShouldBeFalse();
        (volumetricFlowRate2 < volumetricFlowRate1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        VolumetricFlowRate volumetricFlowRate1 = new(3600, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(60, VolumetricFlowRateUnit.LitersPerMinute);
        VolumetricFlowRate volumetricFlowRate3 = new(120, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 <= volumetricFlowRate3).ShouldBeTrue();
        (volumetricFlowRate3 <= volumetricFlowRate1).ShouldBeFalse();
        (volumetricFlowRate1 <= volumetricFlowRate2).ShouldBeTrue();
        (volumetricFlowRate2 <= volumetricFlowRate1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        VolumetricFlowRate volumetricFlowRate = new(1, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate expected = new(2, VolumetricFlowRateUnit.LitersPerHour);
        (volumetricFlowRate * 2).ShouldBe(expected);
        (2 * volumetricFlowRate).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        VolumetricFlowRate volumetricFlowRate1 = new(720, VolumetricFlowRateUnit.LitersPerHour);
        VolumetricFlowRate volumetricFlowRate2 = new(1, VolumetricFlowRateUnit.LitersPerMinute);
        (volumetricFlowRate1 - volumetricFlowRate2).ShouldBe(new VolumetricFlowRate(660, VolumetricFlowRateUnit.LitersPerHour));
        (volumetricFlowRate2 - volumetricFlowRate1).ShouldBe(new VolumetricFlowRate(-11, VolumetricFlowRateUnit.LitersPerMinute));
    }

}