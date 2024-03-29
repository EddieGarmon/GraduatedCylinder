﻿#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Area : IDimension<Area, AreaUnit>
{

    public Length SquareLength() {
        Area area = In(AreaUnit.SquareMeter);
        double root = Math.Sqrt(area.Value);
#if GraduatedCylinder
        return new Length(root, LengthUnit.Meter);
#endif
#if Pipette
        return new Length((float)root, LengthUnit.Meter);
#endif
    }

    public static Length operator /(Area area, Length length) {
        area = area.In(AreaUnit.SquareMeter);
        length = length.In(LengthUnit.Meter);
        return new Length(area.Value / length.Value, LengthUnit.Meter);
    }

    public static Force operator *(Area area, Pressure pressure) {
        area = area.In(AreaUnit.SquareMeter);
        pressure = pressure.In(PressureUnit.NewtonsPerSquareMeter);
        return new Force(area.Value * pressure.Value, ForceUnit.Newtons);
    }

    public static Volume operator *(Area area, Length length) {
        area = area.In(AreaUnit.SquareMeter);
        length = length.In(LengthUnit.Meter);
        return new Volume(area.Value * length.Value, VolumeUnit.CubicMeters);
    }

    public static VolumetricFlowRate operator *(Area area, Speed speed) {
        area = area.In(AreaUnit.SquareMeter);
        speed = speed.In(SpeedUnit.MeterPerSecond);
        return new VolumetricFlowRate(area.Value * speed.Value, VolumetricFlowRateUnit.CubicMetersPerSecond);
    }

}