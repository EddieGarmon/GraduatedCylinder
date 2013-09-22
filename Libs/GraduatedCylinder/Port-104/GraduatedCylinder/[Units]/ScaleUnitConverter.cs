namespace GraduatedCylinder
{
    /// <summary>
    ///     A unit converter that supports scaling by a scale factor only.
    /// </summary>
    public class ScaleUnitConverter : IUnitConverter
    {
        private readonly double _scaleFactor;

        public ScaleUnitConverter(double scaleFactor) {
            _scaleFactor = scaleFactor;
        }

        public double FromBaseUnit(double value) {
            return value / _scaleFactor;
        }

        public double ToBaseUnit(double value) {
            return value * _scaleFactor;
        }
    }
}