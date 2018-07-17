namespace GraduatedCylinder
{
    public static class VolumetricFlowRateExtensioins
    {
        public static VolumetricFlowRate GallonsUsPerHour(this double value) {
            return new VolumetricFlowRate(value, VolumetricFlowRateUnit.GallonsUsPerHour);
        }

        public static VolumetricFlowRate GallonsUsPerSecond(this double value) {
            return new VolumetricFlowRate(value, VolumetricFlowRateUnit.GallonsUsPerSecond);
        }

        public static VolumetricFlowRate LitersPerHour(this double value) {
            return new VolumetricFlowRate(value, VolumetricFlowRateUnit.LitersPerHour);
        }

        public static VolumetricFlowRate LitersPerMinute(this double value) {
            return new VolumetricFlowRate(value, VolumetricFlowRateUnit.LitersPerMinute);
        }

        public static VolumetricFlowRate LitersPerSecond(this double value) {
            return new VolumetricFlowRate(value, VolumetricFlowRateUnit.LitersPerSecond);
        }
    }
}