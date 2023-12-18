#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class AreaOperators
{

    [Fact]
    public void OpAddition() {
        Area area1 = new(36000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        Area expected = new(72000000, AreaUnit.SquareMeter);
        (area1 + area2).ShouldBe(expected);
        (area2 + area1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        Area area1 = new(36000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        (area1 / area2).ShouldBeCloseTo(1);
        (area2 / area1).ShouldBeCloseTo(1);

        (area1 / 2).ShouldBe(new Area(18000000, AreaUnit.SquareMeter));
        (area2 / 2).ShouldBe(new Area(18, AreaUnit.SquareKiloMeter));
    }

    [Fact]
    public void OpEquals() {
        Area area1 = new(36000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        Area area3 = new(120, AreaUnit.SquareKiloMeter);
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
        Area area1 = new(36000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        Area area3 = new(120, AreaUnit.SquareKiloMeter);
        (area1 > area3).ShouldBeFalse();
        (area3 > area1).ShouldBeTrue();
        (area1 > area2).ShouldBeFalse();
        (area2 > area1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        Area area1 = new(36000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        Area area3 = new(120, AreaUnit.SquareKiloMeter);
        (area1 >= area3).ShouldBeFalse();
        (area3 >= area1).ShouldBeTrue();
        (area1 >= area2).ShouldBeTrue();
        (area2 >= area1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        Area area1 = new(36000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        Area area3 = new(120, AreaUnit.SquareKiloMeter);
        (area1 != area2).ShouldBeFalse();
        (area2 != area1).ShouldBeFalse();
        (area1 != area3).ShouldBeTrue();
        (area3 != area1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        Area area1 = new(36000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        Area area3 = new(120, AreaUnit.SquareKiloMeter);
        (area1 < area3).ShouldBeTrue();
        (area3 < area1).ShouldBeFalse();
        (area1 < area2).ShouldBeFalse();
        (area2 < area1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        Area area1 = new(36000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        Area area3 = new(120, AreaUnit.SquareKiloMeter);
        (area1 <= area3).ShouldBeTrue();
        (area3 <= area1).ShouldBeFalse();
        (area1 <= area2).ShouldBeTrue();
        (area2 <= area1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        Area area = new(1, AreaUnit.SquareKiloMeter);
        Area expected = new(2, AreaUnit.SquareKiloMeter);
        (area * 2).ShouldBe(expected);
        (2 * area).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        Area area1 = new(72000000, AreaUnit.SquareMeter);
        Area area2 = new(36, AreaUnit.SquareKiloMeter);
        (area1 - area2).ShouldBe(new Area(36000000, AreaUnit.SquareMeter));
        (area2 - area1).ShouldBe(new Area(-36, AreaUnit.SquareKiloMeter));
    }

}