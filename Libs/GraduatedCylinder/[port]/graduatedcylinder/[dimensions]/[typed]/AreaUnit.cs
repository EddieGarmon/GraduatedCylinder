namespace GraduatedCylinder
{
	/// <summary>
	///     Units of Area that are currently supported, Meter^2 is the Base Unit.
	/// </summary>
	public enum AreaUnit
	{
		/// <summary>
		///     Meter^2, This is the Base Unit
		/// </summary>
		BaseUnit = SquareMeters,

		/// <summary>
		///     Meter^2, This is the Base Unit
		/// </summary>
		[UnitAbbreviation("m^2")]
		[Scale(1.0)]
		SquareMeters = 0,

		/// <summary>
		///     Millimeters^2
		/// </summary>
		[UnitAbbreviation("mm^2")]
		[Scale(0.000001)]
		SquareMillimeters = 1,

		/// <summary>
		///     Centimeters^2
		/// </summary>
		[UnitAbbreviation("cm^2")]
		[Scale(0.0001)]
		SquareCentimeters = 2,

		/// <summary>
		///     Kilometers^2
		/// </summary>
		[UnitAbbreviation("km^2")]
		[Scale(1000000.0)]
		SquareKilometers = 3,

		/// <summary>
		///     Inches^2
		/// </summary>
		[UnitAbbreviation("in^2")]
		[Scale(0.00064516)]
		SquareInches = 4,

		/// <summary>
		///     Feet^2
		/// </summary>
		[UnitAbbreviation("ft^2")]
		[Scale(0.09290304)]
		SquareFeet = 5,

		/// <summary>
		///     Yards^2
		/// </summary>
		[UnitAbbreviation("yd^2")]
		[Scale(0.83612736)]
		SquareYards = 6,

		/// <summary>
		///     Acres
		/// </summary>
		[UnitAbbreviation("ac")]
		[Scale(4046.8564224)]
		Acres = 7,

		/// <summary>
		///     Miles^2
		/// </summary>
		[UnitAbbreviation("mi^2")]
		[Scale(2589988.110336)]
		SquareMiles = 8,
	}
}