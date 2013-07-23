using System;

namespace JetBrains.Annotations
{
	/// <summary>
	///     This attribute is intended to mark publicly available API which should not be removed and so is treated as used.
	/// </summary>
	[MeansImplicitUse]
	internal sealed class PublicAPIAttribute : Attribute
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="PublicAPIAttribute" /> class.
		/// </summary>
		public PublicAPIAttribute() {}

		/// <summary>
		///     Initializes a new instance of the <see cref="PublicAPIAttribute" /> class.
		/// </summary>
		/// <param name="comment">The comment.</param>
		public PublicAPIAttribute(string comment) {}
	}
}