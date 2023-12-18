#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Volume : IDimension<Volume, VolumeUnit>
{

    public Length CubeLength() {
        Volume cube = In(VolumeUnit.CubicMeters);
#if GraduatedCylinder
        return new Length(Math.Pow(cube.Value, 1.0 / 3.0), LengthUnit.Meter);
#endif
#if Pipette
        return new Length((float)Math.Pow(cube.Value, 1.0 / 3.0), LengthUnit.Meter);
#endif
    }

    public static Area operator /(Volume volume, Length length) {
        volume = volume.In(VolumeUnit.CubicMeters);
        length = length.In(LengthUnit.Meter);
        return new Area(volume.Value / length.Value, AreaUnit.SquareMeter);
    }

    public static Length operator /(Volume volume, Area area) {
        volume = volume.In(VolumeUnit.CubicMeters);
        area = area.In(AreaUnit.SquareMeter);
        return new Length(volume.Value / area.Value, LengthUnit.Meter);
    }

    public static Time operator /(Volume volume, VolumetricFlowRate volumetricFlowRate) {
        volume = volume.In(VolumeUnit.Liters);
        volumetricFlowRate = volumetricFlowRate.In(VolumetricFlowRateUnit.LitersPerSecond);
        return new Time(volume.Value / volumetricFlowRate.Value, TimeUnit.Second);
    }

    public static VolumetricFlowRate operator /(Volume volume, Time time) {
        volume = volume.In(VolumeUnit.Liters);
        time = time.In(TimeUnit.Second);
        return new VolumetricFlowRate(volume.Value / time.Value, VolumetricFlowRateUnit.LitersPerSecond);
    }

    public static Mass operator *(Volume volume, MassDensity density) {
        volume = volume.In(VolumeUnit.Liters);
        density = density.In(MassDensityUnit.KiloGramsPerLiter);
        return new Mass(volume.Value * density.Value, MassUnit.KiloGram);
    }

    public static Length operator *(Volume volume, FuelEconomy fuelEconomy) {
        volume = volume.In(VolumeUnit.Liters);
        fuelEconomy = fuelEconomy.In(FuelEconomyUnit.KiloMetersPerLiter);
        return new Length(volume.Value * fuelEconomy.Value, LengthUnit.KiloMeter);
    }

}