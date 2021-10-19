namespace GraduatedCylinder
{
    public readonly partial struct Area : IDimension<Area, AreaUnit>
    {

        public static Length operator /(Area area, Length length) {
            area = area.In(AreaUnit.MeterSquared);
            length = length.In(LengthUnit.Meter);
            return new Length(area.Value / length.Value, LengthUnit.Meter);
        }

        public static Force operator *(Area area, Pressure pressure) {
            area = area.In(AreaUnit.MeterSquared);
            pressure = pressure.In(PressureUnit.NewtonsPerSquareMeter);
            return new Force(area.Value * pressure.Value, ForceUnit.Newtons);
        }

        public static Volume operator *(Area area, Length length) {
            area = area.In(AreaUnit.MeterSquared);
            length = length.In(LengthUnit.Meter);
            return new Volume(area.Value * length.Value, VolumeUnit.CubicMeters);
        }

    }
}