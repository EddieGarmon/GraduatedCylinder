#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Torque : IDimension<Torque, TorqueUnit>
{

    public static Force operator /(Torque torque, Length length) {
        torque = torque.In(TorqueUnit.NewtonMeters);
        length = length.In(LengthUnit.Meter);
        return new Force(torque.Value / length.Value, ForceUnit.Newtons);
    }

    public static Length operator /(Torque torque, Force force) {
        torque = torque.In(TorqueUnit.NewtonMeters);
        force = force.In(ForceUnit.Newtons);
        return new Length(torque.Value / force.Value, LengthUnit.Meter);
    }

}