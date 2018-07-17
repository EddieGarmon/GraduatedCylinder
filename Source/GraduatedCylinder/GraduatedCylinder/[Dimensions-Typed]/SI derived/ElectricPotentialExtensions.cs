namespace GraduatedCylinder
{
    public static class ElectricPotentialExtensions
    {
        public static ElectricPotential Kilovolts(this double value) {
            return new ElectricPotential(value, ElectricPotentialUnit.Kilovolt);
        }

        public static ElectricPotential Millivolts(this double value) {
            return new ElectricPotential(value, ElectricPotentialUnit.Millivolt);
        }

        public static ElectricPotential Volts(this double value) {
            return new ElectricPotential(value, ElectricPotentialUnit.Volt);
        }
    }
}