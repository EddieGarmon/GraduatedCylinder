#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Mass : IDimension<Mass, MassUnit>
{

    public static MassDensity operator /(Mass left, Volume right) {
        left = left.In(MassUnit.KiloGram);
        right = right.In(VolumeUnit.CubicMeters);
        return new MassDensity(left.Value / right.Value, MassDensityUnit.KiloGramsPerCubicMeter);
    }

    public static Volume operator /(Mass left, MassDensity right) {
        left = left.In(MassUnit.KiloGram);
        right = right.In(MassDensityUnit.KiloGramsPerCubicMeter);
        return new Volume(left.Value / right.Value, VolumeUnit.CubicMeters);
    }

    public static MassFlowRate operator /(Mass left, Time right) {
        left = left.In(MassUnit.KiloGram);
        right = right.In(TimeUnit.Second);
        return new MassFlowRate(left.Value / right.Value, MassFlowRateUnit.KiloGramsPerSecond);
    }

    public static Time operator /(Mass left, MassFlowRate right) {
        left = left.In(MassUnit.KiloGram);
        right = right.In(MassFlowRateUnit.KiloGramsPerSecond);
        return new Time(left.Value / right.Value, TimeUnit.Second);
    }

    public static Force operator *(Mass left, Acceleration right) {
        left = left.In(MassUnit.KiloGram);
        right = right.In(AccelerationUnit.MeterPerSquareSecond);
        return new Force(left.Value * right.Value, ForceUnit.Newtons);
    }

    public static Momentum operator *(Mass left, Speed right) {
        left = left.In(MassUnit.KiloGram);
        right = right.In(SpeedUnit.MeterPerSecond);
        return new Momentum(left.Value * right.Value, MomentumUnit.KiloGramMetersPerSecond);
    }

}