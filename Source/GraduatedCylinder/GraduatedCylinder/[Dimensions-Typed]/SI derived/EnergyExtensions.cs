namespace GraduatedCylinder
{
    public static class EnergyExtensions
    {
        public static Energy Calories(this double value) {
            return new Energy(value, EnergyUnit.Calories);
        }

        public static Energy Joules(this double value) {
            return new Energy(value, EnergyUnit.Joules);
        }

        public static Energy Kilojoules(this double value) {
            return new Energy(value, EnergyUnit.Kilojoules);
        }

        public static Energy KilowattHours(this double value) {
            return new Energy(value, EnergyUnit.KilowattHours);
        }

        public static Energy NewtonMetersOfEnergy(this double value) {
            return new Energy(value, EnergyUnit.NewtonMeters);
        }

        public static Energy WattHours(this double value) {
            return new Energy(value, EnergyUnit.WattHours);
        }
    }
}