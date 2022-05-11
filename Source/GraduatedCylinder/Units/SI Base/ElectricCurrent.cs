namespace GraduatedCylinder;

public partial struct ElectricCurrent : IDimension<ElectricCurrent, ElectricCurrentUnit>
{

    public static ElectricPotential operator *(ElectricCurrent left, ElectricResistance right) {
        left = left.In(ElectricCurrentUnit.Ampere);
        right = right.In(ElectricResistanceUnit.Ohm);
        return new ElectricPotential(left.Value * right.Value, ElectricPotentialUnit.Volt);
    }

    public static Power operator *(ElectricCurrent left, ElectricPotential right) {
        left = left.In(ElectricCurrentUnit.Ampere);
        right = right.In(ElectricPotentialUnit.Volt);
        return new Power(left.Value * right.Value, PowerUnit.Watts);
    }

}