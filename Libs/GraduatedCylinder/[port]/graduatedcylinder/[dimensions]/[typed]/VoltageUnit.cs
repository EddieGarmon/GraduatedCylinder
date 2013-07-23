namespace GraduatedCylinder
{
	/// <summary>
	///     Units of Voltage that are currently supported, Volts is the Base Unit.
	/// </summary>
	public enum VoltageUnit
	{
		/// <summary>
		///     Volts, This is the Base Unit
		/// </summary>
		BaseUnit = Volts,

		/// <summary>
		///     Volts, this is the Base Unit
		/// </summary>
		[UnitAbbreviation("V")]
		[Scale(1.0)]
		Volts = 0,

		/// <summary>
		///     MilliVolts
		/// </summary>
		[UnitAbbreviation("mV")]
		[Scale(0.001)]
		MilliVolts = 1,

		/// <summary>
		///     KiloVolts
		/// </summary>
		[UnitAbbreviation("kV")]
		[Scale(1e3)]
		KiloVolts = 2,
	}
}