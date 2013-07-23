namespace GraduatedCylinder
{
	/// <summary>
	///     Units of Power that are currently supported, Watts is the Base Unit.
	/// </summary>
	public enum PowerUnit
	{
		/// <summary>
		///     Watts, This is the Base Unit
		/// </summary>
		BaseUnit = Watts,

		/// <summary>
		///     Watts, this is the Base Unit
		/// </summary>
		[UnitAbbreviation("W")]
		[Scale(1.0)]
		Watts = 0,

		/// <summary>
		///     Newtons x Meters/Second
		/// </summary>
		[UnitAbbreviation("Nm/s")]
		[Scale(1.0)]
		NewtonMetersPerSecond = 1,

		/// <summary>
		///     Calories/Hour
		/// </summary>
		[UnitAbbreviation("cal/h")]
		[Scale(0.001163)]
		CaloriesPerHour = 2,

		/// <summary>
		///     Joules/Hour
		/// </summary>
		[UnitAbbreviation("J/h")]
		[Scale(1.0 / 3600.0)]
		JoulesPerHour = 3,

		/// <summary>
		///     Calories/Minute
		/// </summary>
		[UnitAbbreviation("cal/min")]
		[Scale(0.06978)]
		CaloriesPerMinute = 4,

		/// <summary>
		///     Joules/Minute
		/// </summary>
		[UnitAbbreviation("J/min")]
		[Scale(1.0 / 60.0)]
		JoulesPerMinute = 5,

		/// <summary>
		///     Joules/Second
		/// </summary>
		[UnitAbbreviation("J/s")]
		[Scale(1.0)]
		JoulesPerSecond = 6,

		/// <summary>
		///     Calories/Second
		/// </summary>
		[UnitAbbreviation("cal/s")]
		[Scale(4.1868)]
		CaloriesPerSecond = 7,

		/// <summary>
		///     Kilowatts
		/// </summary>
		[UnitAbbreviation("kW")]
		[Scale(1000.0)]
		Kilowatts = 8,

		/// <summary>
		///     Megawatts
		/// </summary>
		[UnitAbbreviation("MW")]
		[Scale(1000000.0)]
		Megawatts = 9,

		/// <summary>
		///     Horse Power
		/// </summary>
		[UnitAbbreviation("hp")]
		[Scale(0.7457e3)]
		Horsepower = 10,
	}
}