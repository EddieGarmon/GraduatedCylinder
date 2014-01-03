using Xunit;
using XunitShould;

namespace GraduatedCylinder
{
    public class AccelerationOperators
    {
        [Fact]
        public void OpAddition() {
            var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            (acceleration1 + acceleration2).ShouldEqual(new Acceleration(7200, AccelerationUnit.MeterPerSecondSquared));
            (acceleration2 + acceleration1).ShouldEqual(new Acceleration(7.2, AccelerationUnit.KilometerPerSecondSquared));
        }

        [Fact]
        public void OpDivision() {
            var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            (acceleration1 / acceleration2).ShouldBeWithinEpsilonOf(1);
            (acceleration2 / acceleration1).ShouldBeWithinEpsilonOf(1);

            (acceleration1 / 2).ShouldEqual(new Acceleration(1800, AccelerationUnit.MeterPerSecondSquared));
            (acceleration2 / 2).ShouldEqual(new Acceleration(1.8, AccelerationUnit.KilometerPerSecondSquared));
        }

        [Fact]
        public void OpEquals() {
            var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            var acceleration3 = new Acceleration(1200, AccelerationUnit.MeterPerSecondSquared);
            (acceleration1 == acceleration2).ShouldBeTrue();
            (acceleration2 == acceleration1).ShouldBeTrue();
            (acceleration1 == acceleration3).ShouldBeFalse();
            (acceleration3 == acceleration1).ShouldBeFalse();
            acceleration1.Equals(acceleration2)
                         .ShouldBeTrue();
            acceleration1.Equals((object)acceleration2)
                         .ShouldBeTrue();
            acceleration2.Equals(acceleration1)
                         .ShouldBeTrue();
            acceleration2.Equals((object)acceleration1)
                         .ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSecondSquared);
            (acceleration1 > acceleration3).ShouldBeFalse();
            (acceleration3 > acceleration1).ShouldBeTrue();
            (acceleration1 > acceleration2).ShouldBeFalse();
            (acceleration2 > acceleration1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSecondSquared);
            (acceleration1 >= acceleration3).ShouldBeFalse();
            (acceleration3 >= acceleration1).ShouldBeTrue();
            (acceleration1 >= acceleration2).ShouldBeTrue();
            (acceleration2 >= acceleration1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSecondSquared);
            (acceleration1 != acceleration2).ShouldBeFalse();
            (acceleration2 != acceleration1).ShouldBeFalse();
            (acceleration1 != acceleration3).ShouldBeTrue();
            (acceleration3 != acceleration1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSecondSquared);
            (acceleration1 < acceleration3).ShouldBeTrue();
            (acceleration3 < acceleration1).ShouldBeFalse();
            (acceleration1 < acceleration2).ShouldBeFalse();
            (acceleration2 < acceleration1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            var acceleration1 = new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            var acceleration3 = new Acceleration(4500, AccelerationUnit.MeterPerSecondSquared);
            (acceleration1 <= acceleration3).ShouldBeTrue();
            (acceleration3 <= acceleration1).ShouldBeFalse();
            (acceleration1 <= acceleration2).ShouldBeTrue();
            (acceleration2 <= acceleration1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            var acceleration = new Acceleration(1, AccelerationUnit.MeterPerSecondSquared);
            var expected = new Acceleration(2, AccelerationUnit.MeterPerSecondSquared);
            (acceleration * 2).ShouldEqual(expected);
            (2 * acceleration).ShouldEqual(expected);
        }

        [Fact]
        public void OpSubtraction() {
            var acceleration1 = new Acceleration(7200, AccelerationUnit.MeterPerSecondSquared);
            var acceleration2 = new Acceleration(3.6, AccelerationUnit.KilometerPerSecondSquared);
            (acceleration1 - acceleration2).ShouldEqual(new Acceleration(3600, AccelerationUnit.MeterPerSecondSquared));
            (acceleration2 - acceleration1).ShouldEqual(new Acceleration(-3.6, AccelerationUnit.KilometerPerSecondSquared));
        }
    }
}