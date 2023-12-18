#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct ElectricResistance : IDimension<ElectricResistance, ElectricResistanceUnit>
{

    public static ElectricPotential operator *(ElectricResistance resistance, ElectricCurrent current) {
        resistance = resistance.In(ElectricResistanceUnit.Ohm);
        current = current.In(ElectricCurrentUnit.Ampere);
        return new ElectricPotential(resistance.Value * current.Value, ElectricPotentialUnit.Volt);
    }

}