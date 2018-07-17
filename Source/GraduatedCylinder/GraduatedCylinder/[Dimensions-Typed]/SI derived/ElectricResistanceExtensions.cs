namespace GraduatedCylinder
{
    public static class ElectricResistanceExtensions
    {
        public static ElectricResistance Kiloohms(this double value) {
            return new ElectricResistance(value, ElectricResistanceUnit.Kiloohm);
        }

        public static ElectricResistance Megaogms(this double value) {
            return new ElectricResistance(value, ElectricResistanceUnit.Megaogm);
        }

        public static ElectricResistance Ohms(this double value) {
            return new ElectricResistance(value, ElectricResistanceUnit.Ohm);
        }
    }
}