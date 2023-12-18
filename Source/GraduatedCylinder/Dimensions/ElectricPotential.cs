#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct ElectricPotential : IDimension<ElectricPotential, ElectricPotentialUnit>
{

    public static ElectricCurrent operator /(ElectricPotential voltage, ElectricResistance resistance) {
        voltage = voltage.In(ElectricPotentialUnit.Volt);
        resistance = resistance.In(ElectricResistanceUnit.Ohm);
        return new ElectricCurrent(voltage.Value / resistance.Value, ElectricCurrentUnit.Ampere);
    }

    public static ElectricResistance operator /(ElectricPotential voltage, ElectricCurrent current) {
        voltage = voltage.In(ElectricPotentialUnit.Volt);
        current = current.In(ElectricCurrentUnit.Ampere);
        return new ElectricResistance(voltage.Value / current.Value, ElectricResistanceUnit.Ohm);
    }

    public static Power operator *(ElectricPotential voltage, ElectricCurrent current) {
        voltage = voltage.In(ElectricPotentialUnit.Volt);
        current = current.In(ElectricCurrentUnit.Ampere);
        return new Power(voltage.Value * current.Value, PowerUnit.Watts);
    }

}