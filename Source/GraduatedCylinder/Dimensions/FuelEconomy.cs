#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct FuelEconomy : IDimension<FuelEconomy, FuelEconomyUnit>
{

    public static Length operator *(FuelEconomy fuelEconomy, Volume volume) {
        fuelEconomy = fuelEconomy.In(FuelEconomyUnit.KiloMetersPerLiter);
        volume = volume.In(VolumeUnit.Liters);
        return new Length(fuelEconomy.Value * volume.Value, LengthUnit.KiloMeter);
    }

}