namespace GraduatedCylinder
{
	/// <summary>
	///     These units are for the Temperature Dimension that are currently supported, Celsius is the Base Unit.
	///     The base unit is Celsius
	/// </summary>
	public enum TemperatureUnit
	{
		/// <summary>
		///     Celsius, This is the Base Unit
		/// </summary>
		BaseUnit = Celsius,

		/// <summary>
		///     Celsius, This is the Base Unit
		/// </summary>
		[UnitAbbreviation("°C")]
		[ScaleAndOffset(1.0, 0.0)]
		Celsius = 0,

		/// <summary>
		///     Kelvin
		/// </summary>
		[UnitAbbreviation("°K")]
		[ScaleAndOffset(1.0, 273.15)]
		Kelvin = 1,

		/// <summary>
		///     Fahrenheit
		/// </summary>
		[UnitAbbreviation("°F")]
		[ScaleAndOffset(9.0 / 5.0, 32.0)]
		Fahrenheit = 2,
	}
}