using System;
using Xunit.Sdk;

namespace Xunit.Should
{
    /// <summary>
    ///     Extensions which provide assertions to classes derived from <see cref="bool" />.
    /// </summary>
    public static class BooleanExtensions
    {
        public static void ShouldBeFalse(this bool condition) {
            Assert.False(condition);
        }

        public static void ShouldBeFalse(this bool condition, string userMessage) {
            Assert.False(condition, userMessage);
        }

        public static void ShouldBeFalse(this bool condition, Func<string> messageGenerator) {
            if (condition) {
                throw new FalseException(messageGenerator());
            }
        }

        public static void ShouldBeTrue(this bool condition) {
            Assert.True(condition);
        }

        public static void ShouldBeTrue(this bool condition, string userMessage) {
            Assert.True(condition, userMessage);
        }

        public static void ShouldBeTrue(this bool condition, Func<string> messageGenerator) {
            if (!condition) {
                throw new TrueException(messageGenerator());
            }
        }
    }
}