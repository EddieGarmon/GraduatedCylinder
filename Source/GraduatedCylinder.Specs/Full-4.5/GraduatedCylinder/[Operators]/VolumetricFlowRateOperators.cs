using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class VolumetricFlowRateOperators
    {
        [Fact]
        public void OpAddition() {
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(1, VolumetricFlowRateUnit.LitersPerMinute);
            VolumetricFlowRate expected = new VolumetricFlowRate(3660, VolumetricFlowRateUnit.LitersPerHour);
            (volumetricFlowRate1 + volumetricFlowRate2).ShouldEqual(expected, UnitAndValueComparers.VolumetricFlowRate);
            expected.Units = VolumetricFlowRateUnit.LitersPerMinute;
            (volumetricFlowRate2 + volumetricFlowRate1).ShouldEqual(expected, UnitAndValueComparers.VolumetricFlowRate);
        }

        [Fact]
        public void OpDivision() {
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
            (volumetricFlowRate1 / volumetricFlowRate2).ShouldBeWithinEpsilonOf(1);
            (volumetricFlowRate2 / volumetricFlowRate1).ShouldBeWithinEpsilonOf(1);

            (volumetricFlowRate1 / 2).ShouldEqual(new VolumetricFlowRate(1800, VolumetricFlowRateUnit.LitersPerHour));
            (volumetricFlowRate2 / 2).ShouldEqual(new VolumetricFlowRate(30, VolumetricFlowRateUnit.LitersPerMinute));
        }

        [Fact]
        public void OpEquals() {
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
            VolumetricFlowRate volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
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
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
            VolumetricFlowRate volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
            (volumetricFlowRate1 > volumetricFlowRate3).ShouldBeFalse();
            (volumetricFlowRate3 > volumetricFlowRate1).ShouldBeTrue();
            (volumetricFlowRate1 > volumetricFlowRate2).ShouldBeFalse();
            (volumetricFlowRate2 > volumetricFlowRate1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
            VolumetricFlowRate volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
            (volumetricFlowRate1 >= volumetricFlowRate3).ShouldBeFalse();
            (volumetricFlowRate3 >= volumetricFlowRate1).ShouldBeTrue();
            (volumetricFlowRate1 >= volumetricFlowRate2).ShouldBeTrue();
            (volumetricFlowRate2 >= volumetricFlowRate1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
            VolumetricFlowRate volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
            (volumetricFlowRate1 != volumetricFlowRate2).ShouldBeFalse();
            (volumetricFlowRate2 != volumetricFlowRate1).ShouldBeFalse();
            (volumetricFlowRate1 != volumetricFlowRate3).ShouldBeTrue();
            (volumetricFlowRate3 != volumetricFlowRate1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
            VolumetricFlowRate volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
            (volumetricFlowRate1 < volumetricFlowRate3).ShouldBeTrue();
            (volumetricFlowRate3 < volumetricFlowRate1).ShouldBeFalse();
            (volumetricFlowRate1 < volumetricFlowRate2).ShouldBeFalse();
            (volumetricFlowRate2 < volumetricFlowRate1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(3600, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(60, VolumetricFlowRateUnit.LitersPerMinute);
            VolumetricFlowRate volumetricFlowRate3 = new VolumetricFlowRate(120, VolumetricFlowRateUnit.LitersPerMinute);
            (volumetricFlowRate1 <= volumetricFlowRate3).ShouldBeTrue();
            (volumetricFlowRate3 <= volumetricFlowRate1).ShouldBeFalse();
            (volumetricFlowRate1 <= volumetricFlowRate2).ShouldBeTrue();
            (volumetricFlowRate2 <= volumetricFlowRate1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            VolumetricFlowRate volumetricFlowRate = new VolumetricFlowRate(1, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate expected = new VolumetricFlowRate(2, VolumetricFlowRateUnit.LitersPerHour);
            (volumetricFlowRate * 2).ShouldEqual(expected, UnitAndValueComparers.VolumetricFlowRate);
            (2 * volumetricFlowRate).ShouldEqual(expected, UnitAndValueComparers.VolumetricFlowRate);
        }

        [Fact]
        public void OpSubtraction() {
            VolumetricFlowRate volumetricFlowRate1 = new VolumetricFlowRate(720, VolumetricFlowRateUnit.LitersPerHour);
            VolumetricFlowRate volumetricFlowRate2 = new VolumetricFlowRate(1, VolumetricFlowRateUnit.LitersPerMinute);
            (volumetricFlowRate1 - volumetricFlowRate2).ShouldEqual(new VolumetricFlowRate(660, VolumetricFlowRateUnit.LitersPerHour),
                                                                    UnitAndValueComparers.VolumetricFlowRate);
            (volumetricFlowRate2 - volumetricFlowRate1).ShouldEqual(new VolumetricFlowRate(-11, VolumetricFlowRateUnit.LitersPerMinute),
                                                                    UnitAndValueComparers.VolumetricFlowRate);
        }
    }
}