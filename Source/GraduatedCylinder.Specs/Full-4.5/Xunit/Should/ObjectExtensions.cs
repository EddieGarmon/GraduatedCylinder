using System;
using System.Collections.Generic;

namespace Xunit.Should
{
    /// <summary>
    ///     Extensions which provide assertions to classes derived from <see cref="object" />.
    /// </summary>
    public static class ObjectExtensions
    {
        public static void ShouldBeDerivedFrom<T>(this object @object) {
            Assert.IsAssignableFrom<T>(@object);
        }

        public static void ShouldBeDerivedFrom(this object @object, Type type) {
            Assert.IsAssignableFrom(type, @object);
        }

        public static void ShouldBeNull(this object @object) {
            Assert.Null(@object);
        }

        public static void ShouldBeSameAs(this object actual, object expected) {
            Assert.Same(expected, actual);
        }

        public static T ShouldBeType<T>(this object @object) {
            return Assert.IsType<T>(@object);
        }

        public static void ShouldBeType(this object @object, Type expectedType) {
            Assert.IsType(expectedType, @object);
        }

        public static void ShouldEqual<T>(this T actual, T expected) {
            Assert.Equal(expected, actual);
        }

        public static void ShouldEqual<T>(this T actual, T expected, IEqualityComparer<T> comparer) {
            Assert.Equal(expected, actual, comparer);
        }

        public static void ShouldNotBeNull(this object @object) {
            Assert.NotNull(@object);
        }

        public static void ShouldNotBeSameAs(this object actual, object expected) {
            Assert.NotSame(expected, actual);
        }

        public static void ShouldNotBeType<T>(this object @object) {
            Assert.IsNotType<T>(@object);
        }

        public static void ShouldNotBeType(this object @object, Type expectedType) {
            Assert.IsNotType(expectedType, @object);
        }

        public static void ShouldNotEqual<T>(this T actual, T expected) {
            Assert.NotEqual(expected, actual);
        }

        public static void ShouldNotEqual<T>(this T actual, T expected, IEqualityComparer<T> comparer) {
            Assert.NotEqual(expected, actual, comparer);
        }
    }
}