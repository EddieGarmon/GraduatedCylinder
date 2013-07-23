namespace GraduatedCylinder
{
	/// <summary>
	///     Units of Speed that are currently supported, Meters/Second is the Base Unit.
	/// </summary>
	public enum SpeedUnit
	{
		/// <summary>
		///     Meters/Second, This is the Base Unit
		/// </summary>
		BaseUnit = MetersPerSecond,

		/// <summary>
		///     Meters/Second, this is the Base Unit
		/// </summary>
		[UnitAbbreviation("m/s")]
		[Scale(1.0)]
		MetersPerSecond = 0,

		/// <summary>
		///     Meters/Hour
		/// </summary>
		[UnitAbbreviation("m/h")]
		[Scale(1.0 / 3600.0)]
		MetersPerHour = 1,

		/// <summary>
		///     Meters/Hour
		/// </summary>
		[UnitAbbreviation("m/min")]
		[Scale(1.0 / 60.0)]
		MetersPerMinute = 2,

		/// <summary>
		///     Kilometers/Hour
		/// </summary>
		[UnitAbbreviation("km/h")]
		[Scale(1.0 / 3.6)]
		KilometersPerHour = 3,

		/// <summary>
		///     Feet/hour
		/// </summary>
		[UnitAbbreviation("ft/h")]
		[Scale(1.0 / 11811.0)]
		FeetPerHour = 4,

		/// <summary>
		///     Feet/Minute
		/// </summary>
		[UnitAbbreviation("ft/min")]
		[Scale(0.00508)]
		FeetPerMinute = 5,

		/// <summary>
		///     Feet/Second
		/// </summary>
		[UnitAbbreviation("ft/s")]
		[Scale(0.3048)]
		FeetPerSecond = 6,

		/// <summary>
		///     Miles/hour
		/// </summary>
		[UnitAbbreviation("mph")]
		[Scale(0.44704)]
		MilesPerHour = 7,

		/// <summary>
		///     Nautical Miles/hour
		/// </summary>
		[UnitAbbreviation("knots")]
		[Scale(0.514444)]
		NauticalMilesPerHour = 8,

		/// <summary>
		///     Yards/Second
		/// </summary>
		[UnitAbbreviation("yd/s")]
		[Scale(0.9144)]
		YardsPerSecond = 9,
	}
}