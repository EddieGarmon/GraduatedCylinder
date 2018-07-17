namespace GraduatedCylinder
{
    public static class VolumeExtensions
    {
        public static Volume CubicFeet(this double value) {
            return new Volume(value, VolumeUnit.CubicFeet);
        }

        public static Volume CubicInches(this double value) {
            return new Volume(value, VolumeUnit.CubicInches);
        }

        public static Volume CubicMeters(this double value) {
            return new Volume(value, VolumeUnit.CubicMeters);
        }

        public static Volume CubicYards(this double value) {
            return new Volume(value, VolumeUnit.CubicYards);
        }

        public static Volume FluidOuncesUK(this double value) {
            return new Volume(value, VolumeUnit.FluidOuncesUK);
        }

        public static Volume FluidOuncesUS(this double value) {
            return new Volume(value, VolumeUnit.FluidOuncesUS);
        }

        public static Volume GallonsUSDry(this double value) {
            return new Volume(value, VolumeUnit.GallonsUSDry);
        }

        public static Volume GallonsUSLiquid(this double value) {
            return new Volume(value, VolumeUnit.GallonsUSLiquid);
        }

        public static Volume Liters(this double value) {
            return new Volume(value, VolumeUnit.Liters);
        }

        public static Volume PintsUSDry(this double value) {
            return new Volume(value, VolumeUnit.PintsUSDry);
        }

        public static Volume PintsUSLiquid(this double value) {
            return new Volume(value, VolumeUnit.PintsUSLiquid);
        }

        public static Volume QuartsUSDry(this double value) {
            return new Volume(value, VolumeUnit.QuartsUSDry);
        }

        public static Volume QuartsUSLiquid(this double value) {
            return new Volume(value, VolumeUnit.QuartsUSLiquid);
        }
    }
}