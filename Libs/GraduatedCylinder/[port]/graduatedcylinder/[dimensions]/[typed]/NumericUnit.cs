namespace GraduatedCylinder
{
	/// <summary>
	/// </summary>
	public enum NumericUnit
	{
		/// <summary>
		/// </summary>
		BaseUnit = Empty,

		/// <summary>
		///     Number or Ratio, this is the Base Unit
		/// </summary>
		[UnitAbbreviation("")]
		[Scale(1.0)]
		Empty = 0,

		/// <summary>
		///     Percent
		/// </summary>
		[UnitAbbreviation("%")]
		[Scale(0.01)]
		Percent,
	}
}