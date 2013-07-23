namespace GraduatedCylinder
{
	/// <summary>
	///     This interface is used to convert between units in the same dimension. Each
	///     'unit' needs a converter to go between its representation and the base
	///     representation.
	/// </summary>
	public interface IUnitConverter
	{
		/// <summary>
		///     Converts the specified value from the base units to its know units.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The value in the represented units.</returns>
		double FromBaseUnit(double value);

		/// <summary>
		///     Converts the specified value from its know units to the base units.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns>The value in base units</returns>
		double ToBaseUnit(double value);
	}
}