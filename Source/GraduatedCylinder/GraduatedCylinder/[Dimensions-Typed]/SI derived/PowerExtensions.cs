namespace GraduatedCylinder
{
    public static class PowerExtensions
    {
        public static Power CaloriesPerHour(this double value) {
            return new Power(value, PowerUnit.CaloriesPerHour);
        }

        public static Power Horsepower(this double value) {
            return new Power(value, PowerUnit.Horsepower);
        }

        public static Power Kilowatts(this double value) {
            return new Power(value, PowerUnit.Kilowatts);
        }

        public static Power Megawatts(this double value) {
            return new Power(value, PowerUnit.Megawatts);
        }

        public static Power Watts(this double value) {
            return new Power(value, PowerUnit.Watts);
        }
    }
}