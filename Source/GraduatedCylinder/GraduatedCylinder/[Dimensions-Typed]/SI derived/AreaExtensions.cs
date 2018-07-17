namespace GraduatedCylinder
{
    public static class AreaExtensions
    {
        public static Area Acres(this double value) {
            return new Area(value, AreaUnit.Acres);
        }

        public static Area SquareCentimeters(this double value) {
            return new Area(value, AreaUnit.CentimeterSquared);
        }

        public static Area SquareFeet(this double value) {
            return new Area(value, AreaUnit.FootSquared);
        }

        public static Area SquareInches(this double value) {
            return new Area(value, AreaUnit.InchSquared);
        }

        public static Area SquareKilometer(this double value) {
            return new Area(value, AreaUnit.KilometerSquared);
        }

        public static Area SquareMeter(this double value) {
            return new Area(value, AreaUnit.MeterSquared);
        }

        public static Area SquareMiles(this double value) {
            return new Area(value, AreaUnit.SquareMiles);
        }

        public static Area SquareYards(this double value) {
            return new Area(value, AreaUnit.YardSquared);
        }
    }
}