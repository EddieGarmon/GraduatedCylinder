using System;

namespace GraduatedCylinder
{
	/// <summary>
	///     Interface for supporting units of measure
	/// </summary>
	public interface ISupportUnitOfMeasure : IComparable<ISupportUnitOfMeasure>, IEquatable<ISupportUnitOfMeasure>
	{
		/// <summary>
		///     Gets the type of the dimension.
		/// </summary>
		/// <remarks></remarks>
		DimensionType DimensionType { get; }

		/// <summary>
		///     Gets or sets the units.
		/// </summary>
		/// <value>The units.</value>
		UnitOfMeasure Units { get; set; }

		/// <summary>
		///     Gets the value in the current units.
		/// </summary>
		/// <value>The value.</value>
		double Value { get; }

		/// <summary>
		///     Gets the value in base units.
		/// </summary>
		/// <returns></returns>
		/// <remarks></remarks>
		double ValueInBaseUnits { get; }
	}
}