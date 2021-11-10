namespace GraduatedCylinder;

public partial struct Length : IDimension<Length, LengthUnit>
{

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

    public static Area operator *(Length left, Length right) {
        left = left.In(LengthUnit.Meter);
        right = right.In(LengthUnit.Meter);
        return new Area(left.Value * right.Value, AreaUnit.MeterSquared);
    }

    public static Volume operator *(Length length, Area area) {
        length = length.In(LengthUnit.Meter);
        area = area.In(AreaUnit.MeterSquared);
        return new Volume(length.Value * area.Value, VolumeUnit.CubicMeters);
    }

    public static Energy operator *(Length length, Force force) {
        length = length.In(LengthUnit.Meter);
        force = force.In(ForceUnit.Newtons);
        return new Energy(length.Value * force.Value, EnergyUnit.NewtonMeters);
    }

}