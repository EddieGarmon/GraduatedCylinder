namespace GraduatedCylinder
{
	/// <summary>
	///     List of Density units that are supported,Kilograms/Meter^3 is the Base Unit.
	/// </summary>
	public enum DensityUnit
	{
		/// <summary>
		///     Kilograms/Meter^3, This is the Base Unit
		/// </summary>
		BaseUnit = KilogramsPerCubicMeter,

		/// <summary>
		///     Kilograms/Meter^3, This is the Base Unit
		/// </summary>
		[UnitAbbreviation("kg/m^3")]
		[Scale(1.0)]
		KilogramsPerCubicMeter = 0,

		/// <summary>
		///     Kilograms/Liter
		/// </summary>
		[UnitAbbreviation("kg/l")]
		[Scale(1000)]
		KilogramsPerLiter = 1,

		/// <summary>
		///     Grams/Liter
		/// </summary>
		[UnitAbbreviation("g/l")]
		[Scale(1.0)]
		GramsPerLiter = 2,

		/// <summary>
		///     Grams/MilliLiter
		/// </summary>
		[UnitAbbreviation("g/ml")]
		[Scale(1000)]
		GramsPerMilliliter = 3,

		/// <summary>
		///     Grams/Centimeter^3
		/// </summary>
		[UnitAbbreviation("g/cm^3")]
		[Scale(1000)]
		GramsPerCubicCentimeter = 4,

		/// <summary>
		///     Pounds/Feet^3
		/// </summary>
		[UnitAbbreviation("lb/ft^3")]
		[Scale(16.018463)]
		PoundsPerCubicFeet = 5,
	}
}