using DigitalHammer.Testing;
using Xunit;

namespace GraduatedCylinder.Operators;

public class AreaOperators
{

    [Fact]
    public void OpAddition() {
        var area1 = new Area(36000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        var expected = new Area(72000000, AreaUnit.SquareMeter);
        (area1 + area2).ShouldBe(expected);
        (area2 + area1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        var area1 = new Area(36000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        (area1 / area2).ShouldBeCloseTo(1);
        (area2 / area1).ShouldBeCloseTo(1);

        (area1 / 2).ShouldBe(new Area(18000000, AreaUnit.SquareMeter));
        (area2 / 2).ShouldBe(new Area(18, AreaUnit.SquareKilometer));
    }

    [Fact]
    public void OpEquals() {
        var area1 = new Area(36000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        var area3 = new Area(120, AreaUnit.SquareKilometer);
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
        var area1 = new Area(36000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        var area3 = new Area(120, AreaUnit.SquareKilometer);
        (area1 > area3).ShouldBeFalse();
        (area3 > area1).ShouldBeTrue();
        (area1 > area2).ShouldBeFalse();
        (area2 > area1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        var area1 = new Area(36000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        var area3 = new Area(120, AreaUnit.SquareKilometer);
        (area1 >= area3).ShouldBeFalse();
        (area3 >= area1).ShouldBeTrue();
        (area1 >= area2).ShouldBeTrue();
        (area2 >= area1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        var area1 = new Area(36000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        var area3 = new Area(120, AreaUnit.SquareKilometer);
        (area1 != area2).ShouldBeFalse();
        (area2 != area1).ShouldBeFalse();
        (area1 != area3).ShouldBeTrue();
        (area3 != area1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        var area1 = new Area(36000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        var area3 = new Area(120, AreaUnit.SquareKilometer);
        (area1 < area3).ShouldBeTrue();
        (area3 < area1).ShouldBeFalse();
        (area1 < area2).ShouldBeFalse();
        (area2 < area1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        var area1 = new Area(36000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        var area3 = new Area(120, AreaUnit.SquareKilometer);
        (area1 <= area3).ShouldBeTrue();
        (area3 <= area1).ShouldBeFalse();
        (area1 <= area2).ShouldBeTrue();
        (area2 <= area1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        var area = new Area(1, AreaUnit.SquareKilometer);
        var expected = new Area(2, AreaUnit.SquareKilometer);
        (area * 2).ShouldBe(expected);
        (2 * area).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        var area1 = new Area(72000000, AreaUnit.SquareMeter);
        var area2 = new Area(36, AreaUnit.SquareKilometer);
        (area1 - area2).ShouldBe(new Area(36000000, AreaUnit.SquareMeter));
        (area2 - area1).ShouldBe(new Area(-36, AreaUnit.SquareKilometer));
    }

}