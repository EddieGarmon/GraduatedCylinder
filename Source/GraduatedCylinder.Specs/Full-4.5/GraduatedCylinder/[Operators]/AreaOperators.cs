using Xunit;
using Xunit.Should;

namespace GraduatedCylinder
{
    public class AreaOperators
    {
        [Fact]
        public void OpAddition() {
            Area area1 = new Area(36000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            Area expected = new Area(72000000, AreaUnit.SquareMeters);
            (area1 + area2).ShouldEqual(expected, UnitAndValueComparers.Area);
            expected.Units = AreaUnit.SquareKilometers;
            (area2 + area1).ShouldEqual(expected, UnitAndValueComparers.Area);
        }

        [Fact]
        public void OpDivision() {
            Area area1 = new Area(36000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            (area1 / area2).ShouldBeWithinEpsilonOf(1);
            (area2 / area1).ShouldBeWithinEpsilonOf(1);

            (area1 / 2).ShouldEqual(new Area(18000000, AreaUnit.SquareMeters));
            (area2 / 2).ShouldEqual(new Area(18, AreaUnit.SquareKilometers));
        }

        [Fact]
        public void OpEquals() {
            Area area1 = new Area(36000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            Area area3 = new Area(120, AreaUnit.SquareKilometers);
            (area1 == area2).ShouldBeTrue();
            (area2 == area1).ShouldBeTrue();
            (area1 == area3).ShouldBeFalse();
            (area3 == area1).ShouldBeFalse();
            area1.Equals(area2).ShouldBeTrue();
            area1.Equals((object)area2).ShouldBeTrue();
            area2.Equals(area1).ShouldBeTrue();
            area2.Equals((object)area1).ShouldBeTrue();
        }

        [Fact]
        public void OpGreaterThan() {
            Area area1 = new Area(36000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            Area area3 = new Area(120, AreaUnit.SquareKilometers);
            (area1 > area3).ShouldBeFalse();
            (area3 > area1).ShouldBeTrue();
            (area1 > area2).ShouldBeFalse();
            (area2 > area1).ShouldBeFalse();
        }

        [Fact]
        public void OpGreaterThanOrEqual() {
            Area area1 = new Area(36000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            Area area3 = new Area(120, AreaUnit.SquareKilometers);
            (area1 >= area3).ShouldBeFalse();
            (area3 >= area1).ShouldBeTrue();
            (area1 >= area2).ShouldBeTrue();
            (area2 >= area1).ShouldBeTrue();
        }

        [Fact]
        public void OpInverseEquals() {
            Area area1 = new Area(36000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            Area area3 = new Area(120, AreaUnit.SquareKilometers);
            (area1 != area2).ShouldBeFalse();
            (area2 != area1).ShouldBeFalse();
            (area1 != area3).ShouldBeTrue();
            (area3 != area1).ShouldBeTrue();
        }

        [Fact]
        public void OpLessThan() {
            Area area1 = new Area(36000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            Area area3 = new Area(120, AreaUnit.SquareKilometers);
            (area1 < area3).ShouldBeTrue();
            (area3 < area1).ShouldBeFalse();
            (area1 < area2).ShouldBeFalse();
            (area2 < area1).ShouldBeFalse();
        }

        [Fact]
        public void OpLessThanOrEqual() {
            Area area1 = new Area(36000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            Area area3 = new Area(120, AreaUnit.SquareKilometers);
            (area1 <= area3).ShouldBeTrue();
            (area3 <= area1).ShouldBeFalse();
            (area1 <= area2).ShouldBeTrue();
            (area2 <= area1).ShouldBeTrue();
        }

        [Fact]
        public void OpMultiplicationScaler() {
            Area area = new Area(1, AreaUnit.SquareKilometers);
            Area expected = new Area(2, AreaUnit.SquareKilometers);
            (area * 2).ShouldEqual(expected, UnitAndValueComparers.Area);
            (2 * area).ShouldEqual(expected, UnitAndValueComparers.Area);
        }

        [Fact]
        public void OpSubtraction() {
            Area area1 = new Area(72000000, AreaUnit.SquareMeters);
            Area area2 = new Area(36, AreaUnit.SquareKilometers);
            (area1 - area2).ShouldEqual(new Area(36000000, AreaUnit.SquareMeters), UnitAndValueComparers.Area);
            (area2 - area1).ShouldEqual(new Area(-36, AreaUnit.SquareKilometers), UnitAndValueComparers.Area);
        }
    }
}