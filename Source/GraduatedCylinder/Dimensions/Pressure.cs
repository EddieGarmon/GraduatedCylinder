#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Pressure : IDimension<Pressure, PressureUnit>
{

    public static Force operator *(Pressure pressure, Area area) {
        pressure = pressure.In(PressureUnit.NewtonsPerSquareMeter);
        area = area.In(AreaUnit.SquareMeter);
        return new Force(pressure.Value * area.Value, ForceUnit.Newtons);
    }

}