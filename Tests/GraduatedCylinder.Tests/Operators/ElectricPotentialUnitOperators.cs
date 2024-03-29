#if GraduatedCylinder
namespace GraduatedCylinder.Operators;
#endif
#if Pipette
namespace Pipette.Operators;
#endif

public class ElectricPotentialUnitOperators
{

    [Fact]
    public void OpAddition() {
        ElectricPotential voltage1 = new(3000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(1, ElectricPotentialUnit.KiloVolt);
        ElectricPotential expected = new(4000, ElectricPotentialUnit.Volt);
        (voltage1 + voltage2).ShouldBe(expected);
        (voltage2 + voltage1).ShouldBe(expected);
    }

    [Fact]
    public void OpDivision() {
        ElectricPotential voltage1 = new(3000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(3, ElectricPotentialUnit.KiloVolt);
        (voltage1 / voltage2).ShouldBeCloseTo(1);
        (voltage2 / voltage1).ShouldBeCloseTo(1);

        (voltage1 / 2).ShouldBe(new ElectricPotential(1500, ElectricPotentialUnit.Volt));
        (voltage2 / 2).ShouldBe(new ElectricPotential(1.5, ElectricPotentialUnit.KiloVolt));
    }

    [Fact]
    public void OpEquals() {
        ElectricPotential voltage1 = new(3000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(3, ElectricPotentialUnit.KiloVolt);
        ElectricPotential voltage3 = new(10, ElectricPotentialUnit.KiloVolt);
        (voltage1 == voltage2).ShouldBeTrue();
        (voltage2 == voltage1).ShouldBeTrue();
        (voltage1 == voltage3).ShouldBeFalse();
        (voltage3 == voltage1).ShouldBeFalse();
        voltage1.Equals(voltage2).ShouldBeTrue();
        voltage1.Equals((object)voltage2).ShouldBeTrue();
        voltage2.Equals(voltage1).ShouldBeTrue();
        voltage2.Equals((object)voltage1).ShouldBeTrue();
    }

    [Fact]
    public void OpGreaterThan() {
        ElectricPotential voltage1 = new(3000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(3, ElectricPotentialUnit.KiloVolt);
        ElectricPotential voltage3 = new(10, ElectricPotentialUnit.KiloVolt);
        (voltage1 > voltage3).ShouldBeFalse();
        (voltage3 > voltage1).ShouldBeTrue();
        (voltage1 > voltage2).ShouldBeFalse();
        (voltage2 > voltage1).ShouldBeFalse();
    }

    [Fact]
    public void OpGreaterThanOrEqual() {
        ElectricPotential voltage1 = new(3000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(3, ElectricPotentialUnit.KiloVolt);
        ElectricPotential voltage3 = new(10, ElectricPotentialUnit.KiloVolt);
        (voltage1 >= voltage3).ShouldBeFalse();
        (voltage3 >= voltage1).ShouldBeTrue();
        (voltage1 >= voltage2).ShouldBeTrue();
        (voltage2 >= voltage1).ShouldBeTrue();
    }

    [Fact]
    public void OpInverseEquals() {
        ElectricPotential voltage1 = new(3000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(3, ElectricPotentialUnit.KiloVolt);
        ElectricPotential voltage3 = new(10, ElectricPotentialUnit.KiloVolt);
        (voltage1 != voltage2).ShouldBeFalse();
        (voltage2 != voltage1).ShouldBeFalse();
        (voltage1 != voltage3).ShouldBeTrue();
        (voltage3 != voltage1).ShouldBeTrue();
    }

    [Fact]
    public void OpLessThan() {
        ElectricPotential voltage1 = new(3000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(3, ElectricPotentialUnit.KiloVolt);
        ElectricPotential voltage3 = new(10, ElectricPotentialUnit.KiloVolt);
        (voltage1 < voltage3).ShouldBeTrue();
        (voltage3 < voltage1).ShouldBeFalse();
        (voltage1 < voltage2).ShouldBeFalse();
        (voltage2 < voltage1).ShouldBeFalse();
    }

    [Fact]
    public void OpLessThanOrEqual() {
        ElectricPotential voltage1 = new(3000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(3, ElectricPotentialUnit.KiloVolt);
        ElectricPotential voltage3 = new(10, ElectricPotentialUnit.KiloVolt);
        (voltage1 <= voltage3).ShouldBeTrue();
        (voltage3 <= voltage1).ShouldBeFalse();
        (voltage1 <= voltage2).ShouldBeTrue();
        (voltage2 <= voltage1).ShouldBeTrue();
    }

    [Fact]
    public void OpMultiplicationScaler() {
        ElectricPotential voltage = new(1, ElectricPotentialUnit.Volt);
        ElectricPotential expected = new(2, ElectricPotentialUnit.Volt);
        (voltage * 2).ShouldBe(expected);
        (2 * voltage).ShouldBe(expected);
    }

    [Fact]
    public void OpSubtraction() {
        ElectricPotential voltage1 = new(7000, ElectricPotentialUnit.Volt);
        ElectricPotential voltage2 = new(1, ElectricPotentialUnit.KiloVolt);
        (voltage1 - voltage2).ShouldBe(new ElectricPotential(6000, ElectricPotentialUnit.Volt));
        (voltage2 - voltage1).ShouldBe(new ElectricPotential(-6, ElectricPotentialUnit.KiloVolt));
    }

}