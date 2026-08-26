#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial class UnitPreferences
{

    public int Precision { get; set; } = 2;

    public static UnitPreferences GetAmericanEnglishUnits() {
        return new UnitPreferences {
            AccelerationUnit = AccelerationUnit.MilePerHourPerSecond,
            AngleUnit = AngleUnit.Degree,
            AreaUnit = AreaUnit.SquareMiles,
            EnergyUnit = EnergyUnit.KiloCalories,
            ForceUnit = ForceUnit.PoundForce,
            JerkUnit = JerkUnit.MilesPerSecondCubed,
            LengthUnit = LengthUnit.Mile,
            MassUnit = MassUnit.Pounds,
            MassDensityUnit = MassDensityUnit.PoundsPerCubicFoot,
            MassFlowRateUnit = MassFlowRateUnit.PoundsPerSecond,
            MomentumUnit = MomentumUnit.PoundsMilesPerHour,
            PowerUnit = PowerUnit.Horsepower,
            PressureUnit = PressureUnit.PoundsPerSquareInch,
            SpeedUnit = SpeedUnit.MilesPerHour,
            TemperatureUnit = TemperatureUnit.Fahrenheit,
            TorqueUnit = TorqueUnit.FootPounds,
            VolumeUnit = VolumeUnit.GallonsUSLiquid,
            VolumetricFlowRateUnit = VolumetricFlowRateUnit.GallonsUsPerHour
        };
    }

    public static UnitPreferences GetBritishEnglishUnits() {
        return new UnitPreferences {
            AccelerationUnit = AccelerationUnit.MilePerHourPerSecond,
            AngleUnit = AngleUnit.Degree,
            AreaUnit = AreaUnit.SquareMiles,
            EnergyUnit = EnergyUnit.KiloCalories,
            ForceUnit = ForceUnit.PoundForce,
            JerkUnit = JerkUnit.MilesPerSecondCubed,
            LengthUnit = LengthUnit.Mile,
            MassUnit = MassUnit.Pounds,
            MassDensityUnit = MassDensityUnit.PoundsPerCubicFoot,
            MassFlowRateUnit = MassFlowRateUnit.PoundsPerSecond,
            MomentumUnit = MomentumUnit.PoundsMilesPerHour,
            PowerUnit = PowerUnit.Horsepower,
            PressureUnit = PressureUnit.PoundsPerSquareInch,
            SpeedUnit = SpeedUnit.MilesPerHour,
            TemperatureUnit = TemperatureUnit.Fahrenheit,
            TorqueUnit = TorqueUnit.FootPounds,
            VolumeUnit = VolumeUnit.GallonsUK,
            VolumetricFlowRateUnit = VolumetricFlowRateUnit.GallonsUsPerSecond
        };
    }

    public static UnitPreferences GetCultureUnits(string cultureCode) {
        cultureCode = cultureCode.ToLowerInvariant();
        return cultureCode switch {
            "en" or "en-us" => GetAmericanEnglishUnits(),
            "en-gb" => GetBritishEnglishUnits(),
            _ => GetMetricUnits()
        };
    }

    public static UnitPreferences GetMetricUnits() {
        return new UnitPreferences {
            AccelerationUnit = AccelerationUnit.KiloMeterPerHourPerSecond,
            AreaUnit = AreaUnit.SquareKiloMeter,
            EnergyUnit = EnergyUnit.NewtonMeters,
            JerkUnit = JerkUnit.KiloMetersPerSecondCubed,
            LengthUnit = LengthUnit.KiloMeter,
            PowerUnit = PowerUnit.KiloWatts,
            SpeedUnit = SpeedUnit.KiloMetersPerHour,
            VolumeUnit = VolumeUnit.Liters
        };
    }

}