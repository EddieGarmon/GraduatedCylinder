namespace GraduatedCylinder
{
	/// <summary>
	///     Units of Length that are currently supported, Meters is the Base Unit.
	/// </summary>
	public enum LengthUnit
	{
		/// <summary>
		///     Meters, This is the Base Unit
		/// </summary>
		BaseUnit = Meters,

		/// <summary>
		///     Meters, This is the Base Unit
		/// </summary>
		[UnitAbbreviation("m")]
		[Scale(1.0)]
		Meters = 0,

		/// <summary>
		///     Millimeters
		/// </summary>
		[UnitAbbreviation("mm")]
		[Scale(1e-3)]
		Millimeters = 1,

		/// <summary>
		///     Centimeters
		/// </summary>
		[UnitAbbreviation("cm")]
		[Scale(1e-2)]
		Centimeters = 2,

		/// <summary>
		///     Decimeters
		/// </summary>
		[UnitAbbreviation("dm")]
		[Scale(1e-1)]
		Decimeters = 3,

		/// <summary>
		///     Kilometers
		/// </summary>
		[UnitAbbreviation("km")]
		[Scale(1e3)]
		Kilometers = 4,

		/// <summary>
		///     Inches
		/// </summary>
		[UnitAbbreviation("in")]
		[Scale(0.0254)]
		Inches = 5,

		/// <summary>
		///     Feet
		/// </summary>
		[UnitAbbreviation("ft")]
		[Scale(0.3048)]
		Feet = 6,

		/// <summary>
		///     Yards
		/// </summary>
		[UnitAbbreviation("yd")]
		[Scale(0.9144)]
		Yards = 7,

		/// <summary>
		///     Fathoms
		/// </summary>
		[UnitAbbreviation("fath")]
		[Scale(1.8288)]
		Fathoms = 8,

		/// <summary>
		///     Miles
		/// </summary>
		[UnitAbbreviation("mi")]
		[Scale(1609.344)]
		Miles = 9,

		/// <summary>
		///     Nautical Miles
		/// </summary>
		[UnitAbbreviation("nmi")]
		[Scale(1852.0)]
		NauticalMiles = 10,
	}
}