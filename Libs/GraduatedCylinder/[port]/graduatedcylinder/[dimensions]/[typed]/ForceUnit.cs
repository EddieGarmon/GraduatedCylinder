namespace GraduatedCylinder
{
	/// <summary>
	///     Units of Force that are currently supported, Newtons is the Base Unit.
	/// </summary>
	public enum ForceUnit
	{
		/// <summary>
		///     Newtons, This is the Base Unit
		/// </summary>
		BaseUnit = Newtons,

		/// <summary>
		///     Newtons, This is the Base Unit
		/// </summary>
		[UnitAbbreviation("N")]
		[Scale(1.0)]
		Newtons = 0,

		/// <summary>
		///     Pound Force
		/// </summary>
		[UnitAbbreviation("lbf")]
		[Scale(4.44822)]
		PoundForce = 1,

		/// <summary>
		///     Kilogram Force
		/// </summary>
		[UnitAbbreviation("kgf")]
		[Scale(9.81)]
		KilogramForce = 2,
	}
}