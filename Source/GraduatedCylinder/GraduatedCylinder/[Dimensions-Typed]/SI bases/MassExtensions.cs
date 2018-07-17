namespace GraduatedCylinder
{
    public static class MassExtensions
    {
        public static Mass Carats(this double value) {
            return new Mass(value, MassUnit.Carats);
        }

        public static Mass Grams(this double value) {
            return new Mass(value, MassUnit.Gram);
        }

        public static Mass Kilograms(this double value) {
            return new Mass(value, MassUnit.Kilogram);
        }

        public static Mass OuncesTroy(this double value) {
            return new Mass(value, MassUnit.OuncesTroy);
        }

        public static Mass TonsUK(this double value) {
            return new Mass(value, MassUnit.TonsUK);
        }

        public static Mass TonsUS(this double value) {
            return new Mass(value, MassUnit.TonsUS);
        }
    }
}