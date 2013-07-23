namespace GraduatedCylinder
{
	/// <summary>
	///     List of Angle units that are supported, Degrees is the Base Unit
	/// </summary>
	public enum AngleUnit
	{
		/// <summary>
		///     Degrees, This is the Base Unit
		/// </summary>
		BaseUnit = Degrees,

		/// <summary>
		///     Degrees, This is the Base Unit
		/// </summary>
		[UnitAbbreviation("deg")]
		[Scale(1.0)]
		Degrees = 0,

		/// <summary>
		///     Milli Radians
		/// </summary>
		[UnitAbbreviation("mrad")]
		[Scale(0.0000174532925)]
		MilliRadians = 1,

		/// <summary>
		///     Micro Radians
		/// </summary>
		[UnitAbbreviation("µrad")]
		[Scale(0.0000000174532925)]
		MicroRadians = 2,

		/// <summary>
		///     Radians
		/// </summary>
		[UnitAbbreviation("rad")]
		[Scale(0.0174532925)]
		Radians = 3,

		/// <summary>
		///     Grads
		/// </summary>
		[UnitAbbreviation("grads")]
		[Scale(0.9)]
		Grads = 4,
	}
}