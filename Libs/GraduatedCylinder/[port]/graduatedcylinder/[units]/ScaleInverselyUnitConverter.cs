namespace GraduatedCylinder
{
	/// <summary>
	///     A unit converter that supports scaling by a scale factor only.
	/// </summary>
	public class ScaleInverselyUnitConverter : IUnitConverter
	{
		private readonly double _inverseScaleFactor;
		private readonly double _scaleFactor;

		public ScaleInverselyUnitConverter(double inverseScaleFactor, double scaleFactor) {
			_inverseScaleFactor = inverseScaleFactor;
			_scaleFactor = scaleFactor;
		}

		public double FromBaseUnit(double value) {
			return _inverseScaleFactor / (value / _scaleFactor);
		}

		public double ToBaseUnit(double value) {
			return (_inverseScaleFactor / value) * _scaleFactor;
		}
	}
}