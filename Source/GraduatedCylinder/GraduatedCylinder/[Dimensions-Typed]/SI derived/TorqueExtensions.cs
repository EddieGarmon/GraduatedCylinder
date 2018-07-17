namespace GraduatedCylinder
{
    public static class TorqueExtensions
    {
        public static Torque FootPounds(this double value) {
            return new Torque(value, TorqueUnit.FootPounds);
        }

        public static Torque NewtonMeters(this double value) {
            return new Torque(value, TorqueUnit.NewtonMeters);
        }
    }
}