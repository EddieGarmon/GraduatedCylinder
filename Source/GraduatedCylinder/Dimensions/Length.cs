#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Length : IDimension<Length, LengthUnit>
{

    public WaveNumber ToWaveNumber() {
        return new WaveNumber(1 / In(LengthUnit.Meter).Value, WaveNumberUnit.ReciprocalMeter);
    }

    public static Speed operator /(Length length, Time time) {
        length = length.In(LengthUnit.Meter);
        time = time.In(TimeUnit.Second);
        return new Speed(length.Value / time.Value, SpeedUnit.MeterPerSecond);
    }

    public static Time operator /(Length length, Speed speed) {
        length = length.In(LengthUnit.Meter);
        speed = speed.In(SpeedUnit.MeterPerSecond);
        return new Time(length.Value / speed.Value, TimeUnit.Second);
    }

    public static FuelEconomy operator /(Length length, Volume volume) {
        length = length.In(LengthUnit.KiloMeter);
        volume = volume.In(VolumeUnit.Liters);
        return new FuelEconomy(length.Value / volume.Value, FuelEconomyUnit.KiloMetersPerLiter);
    }

    public static Volume operator /(Length length, FuelEconomy fuelEconomy) {
        length = length.In(LengthUnit.KiloMeter);
        fuelEconomy = fuelEconomy.In(FuelEconomyUnit.KiloMetersPerLiter);
        return new Volume(length.Value / fuelEconomy.Value, VolumeUnit.Liters);
    }

    public static Area operator *(Length left, Length right) {
        left = left.In(LengthUnit.Meter);
        right = right.In(LengthUnit.Meter);
        return new Area(left.Value * right.Value, AreaUnit.SquareMeter);
    }

    public static Volume operator *(Length length, Area area) {
        length = length.In(LengthUnit.Meter);
        area = area.In(AreaUnit.SquareMeter);
        return new Volume(length.Value * area.Value, VolumeUnit.CubicMeters);
    }

    public static Energy operator *(Length length, Force force) {
        length = length.In(LengthUnit.Meter);
        force = force.In(ForceUnit.Newtons);
        return new Energy(length.Value * force.Value, EnergyUnit.NewtonMeters);
    }

}