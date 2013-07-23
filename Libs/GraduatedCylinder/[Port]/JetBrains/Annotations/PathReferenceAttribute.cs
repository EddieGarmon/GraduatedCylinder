using System;

namespace JetBrains.Annotations
{
	/// <summary>
	///     Indicates that a parameter is a path to a file or a folder within a web project.
	///     Path can be relative or absolute, starting from web root (~).
	/// </summary>
	[AttributeUsage(AttributeTargets.Parameter)]
	internal class PathReferenceAttribute : Attribute
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="PathReferenceAttribute" /> class.
		/// </summary>
		public PathReferenceAttribute() {}

		/// <summary>
		///     Initializes a new instance of the <see cref="PathReferenceAttribute" /> class.
		/// </summary>
		/// <param name="basePath">The base path.</param>
		[UsedImplicitly]
		public PathReferenceAttribute([PathReference] string basePath) {
			BasePath = basePath;
		}

		/// <summary>
		///     Gets the base path.
		/// </summary>
		/// <value>The base path.</value>
		[UsedImplicitly]
		public string BasePath { get; private set; }
	}
}