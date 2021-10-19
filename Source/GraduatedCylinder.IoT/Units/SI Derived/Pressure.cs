namespace GraduatedCylinder
{
    public readonly partial struct Pressure : IDimension<Pressure, PressureUnit>
    {

        public static Force operator *(Pressure pressure, Area area) {
            pressure = pressure.In(PressureUnit.NewtonsPerSquareMeter);
            area = area.In(AreaUnit.MeterSquared);
            return new Force(pressure.Value * area.Value, ForceUnit.Newtons);
        }

    }
}