namespace GraduatedCylinder
{
    public static class AccelerationExtensions
    {
        public static Acceleration MeterPerSecondSquared(this double value) {
            return new Acceleration(value, AccelerationUnit.MeterPerSecondSquared);
        }

        public static Acceleration MilePerHourPerSecond(this double value) {
            return new Acceleration(value, AccelerationUnit.MilePerHourPerSecond);
        }
    }
}