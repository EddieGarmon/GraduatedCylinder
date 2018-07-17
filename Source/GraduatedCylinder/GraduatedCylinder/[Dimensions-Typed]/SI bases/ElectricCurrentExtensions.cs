namespace GraduatedCylinder
{
    public static class ElectricCurrentExtensions
    {
        public static ElectricCurrent Amperes(this double value) {
            return new ElectricCurrent(value, ElectricCurrentUnit.Ampere);
        }

        public static ElectricCurrent Milliamperes(this double value) {
            return new ElectricCurrent(value, ElectricCurrentUnit.Milliampere);
        }
    }
}