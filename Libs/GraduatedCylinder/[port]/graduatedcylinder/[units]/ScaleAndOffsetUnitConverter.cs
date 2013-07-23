namespace GraduatedCylinder
{
	/// <summary>
	///     A unit converter that supports scaling by a scale factor and a 'zero'
	///     translating offset.
	/// </summary>
	public class ScaleAndOffsetUnitConverter : IUnitConverter
	{
		private readonly double _scaleFactor;
		private readonly double _translatingFactor;

		public ScaleAndOffsetUnitConverter(double scaleFactor, double zeroAdjustment) {
			_scaleFactor = scaleFactor;
			_translatingFactor = zeroAdjustment;
		}

		public double FromBaseUnit(double value) {
			return (value * _scaleFactor) + _translatingFactor;
		}

		public double ToBaseUnit(double value) {
			return (value - _translatingFactor) / _scaleFactor;
		}
	}
}