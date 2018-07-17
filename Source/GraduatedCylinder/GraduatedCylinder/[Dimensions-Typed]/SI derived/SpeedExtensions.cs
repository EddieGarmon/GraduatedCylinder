namespace GraduatedCylinder
{
    public static class SpeedExtensions
    {
        public static Speed FeetPerSecond(this double value) {
            return new Speed(value, SpeedUnit.FeetPerSecond);
        }

        public static Speed KilometersPerHour(this double value) {
            return new Speed(value, SpeedUnit.KilometersPerHour);
        }

        public static Speed MetersPerSecond(this double value) {
            return new Speed(value, SpeedUnit.MeterPerSecond);
        }

        public static Speed MilesPerHour(this double value) {
            return new Speed(value, SpeedUnit.MilesPerHour);
        }
    }
}