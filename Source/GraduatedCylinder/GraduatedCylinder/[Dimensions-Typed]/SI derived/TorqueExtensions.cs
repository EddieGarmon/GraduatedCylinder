namespace GraduatedCylinder
{
    public static class TorqueExtensions
    {
        public static Torque FootPounds(this double value) {
            return new Torque(value, TorqueUnit.FootPounds);
        }

        public static Torque NewtonMetersOfTorque(this double value) {
            return new Torque(value, TorqueUnit.NewtonMeters);
        }
    }
}