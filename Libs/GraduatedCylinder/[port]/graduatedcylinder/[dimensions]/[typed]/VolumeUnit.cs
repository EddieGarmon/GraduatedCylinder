namespace GraduatedCylinder
{
	/// <summary>
	///     Units of Volume that are currently supported, CubicMeters is the Base Unit.
	/// </summary>
	public enum VolumeUnit
	{
		/// <summary>
		///     Liters, This is the Base Unit
		/// </summary>
		BaseUnit = CubicMeters,

		/// <summary>
		///     Meters^3
		/// </summary>
		[UnitAbbreviation("m^3")]
		[Scale(1.0)]
		CubicMeters = 0,

		/// <summary>
		///     Millimeters^3
		/// </summary>
		[UnitAbbreviation("mm^3")]
		[Scale(0.000000001)]
		CubicMillimeters = 1,

		/// <summary>
		///     Centimeters^3
		/// </summary>
		[UnitAbbreviation("cc")]
		[Scale(0.000001)]
		CubicCentimeters = 2,

		/// <summary>
		///     Milliliters
		/// </summary>
		[UnitAbbreviation("mL")]
		[Scale(0.000001)]
		Milliliters = 3,

		/// <summary>
		///     Centiliters
		/// </summary>
		[UnitAbbreviation("cL")]
		[Scale(0.00001)]
		Centilitres = 4,

		/// <summary>
		///     Decimeters^3
		/// </summary>
		[UnitAbbreviation("dm^3")]
		[Scale(.001)]
		CubicDecimeters = 5,

		/// <summary>
		///     Liters, this is the Base Unit
		/// </summary>
		[UnitAbbreviation("L")]
		[Scale(.001)]
		Liters = 6,

		/// <summary>
		///     Inches^3
		/// </summary>
		[UnitAbbreviation("in^3")]
		[Scale(0.000016387064)]
		CubicInches = 7,

		/// <summary>
		///     US Fluid Ounces
		/// </summary>
		[UnitAbbreviation("fl-oz")]
		[Scale(0.0000295735295625)]
		FluidOuncesUS = 8,

		/// <summary>
		///     UK Fluid Ounces
		/// </summary>
		[UnitAbbreviation("fl-oz-UK")]
		[Scale(0.0000284130625)]
		FluidOuncesUK = 9,

		/// <summary>
		///     US Liquid Pints
		/// </summary>
		[UnitAbbreviation("pt")]
		[Scale(0.000473176473)]
		PintsUSLiquid = 10,

		/// <summary>
		///     US Dry Pints
		/// </summary>
		[UnitAbbreviation("pt-dry")]
		[Scale(0.0005506104713575)]
		PintsUSDry = 11,

		/// <summary>
		///     UK Pints
		/// </summary>
		[UnitAbbreviation("pt-UK")]
		[Scale(0.00056826125)]
		PintsUK = 12,

		/// <summary>
		///     US Liquid Quarts
		/// </summary>
		[UnitAbbreviation("qt")]
		[Scale(0.000946352946)]
		QuartsUSLiquid = 13,

		/// <summary>
		///     US Dry Quarts
		/// </summary>
		[UnitAbbreviation("qt-dry")]
		[Scale(.001101220942715)]
		QuartsUSDry = 14,

		/// <summary>
		///     UK Quarts
		/// </summary>
		[UnitAbbreviation("qt-UK")]
		[Scale(.0011365225)]
		QuartsUK = 15,

		/// <summary>
		///     US Liquid Gallons
		/// </summary>
		[UnitAbbreviation("gal")]
		[Scale(.003785411784)]
		GallonsUSLiquid = 16,

		/// <summary>
		///     US Dry Gallons
		/// </summary>
		[UnitAbbreviation("gal-dry")]
		[Scale(.00440488377086)]
		GallonsUSDry = 17,

		/// <summary>
		///     UK Gallons
		/// </summary>
		[UnitAbbreviation("gal-UK")]
		[Scale(.00454609)]
		GallonsUK = 18,

		/// <summary>
		///     Feet^3
		/// </summary>
		[UnitAbbreviation("ft^3")]
		[Scale(.028316846592)]
		CubicFeet = 19,

		/// <summary>
		///     Yards^3
		/// </summary>
		[UnitAbbreviation("yd^3")]
		[Scale(.764554857984)]
		CubicYards = 20,
	}
}