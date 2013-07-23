using Xunit.Should;

namespace GraduatedCylinder
{
	internal static class TestConstants
	{
		internal const double Epsilon = 1e-6; //shrink this to increase required precision

		public static void ShouldBeWithinEpsilonOf(this double value, double expectedValue) {
			(expectedValue - value).ShouldBeLessThanOrEqual(Epsilon);
			(value - expectedValue).ShouldBeLessThanOrEqual(Epsilon);
		}
	}
}