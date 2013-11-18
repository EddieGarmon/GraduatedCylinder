using System;
using System.Collections;
using System.Collections.Generic;
using Xunit.Sdk;

namespace Xunit.Should
{
    /// <summary>
    ///     Extensions which provide assertions to classes derived from <see cref="IEnumerable" /> and
    ///     <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class IEnumerableExtensions
    {
        public static void ShouldBeEmpty(this IEnumerable collection) {
            Assert.Empty(collection);
        }

        public static void ShouldContain<T>(this IEnumerable<T> collection, T expected) {
            Assert.Contains(expected, collection);
        }

        public static void ShouldContain<T>(this IEnumerable<T> collection, T expected, IEqualityComparer<T> comparer) {
            Assert.Contains(expected, collection, comparer);
        }

        public static void ShouldEqual<T>(this IEnumerable<T> actual, params T[] expected) {
            ShouldEqual(actual, expected, Comparer<T>.Default);
        }

        public static void ShouldEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected) {
            ShouldEqual(actual, expected, Comparer<T>.Default);
        }

        public static void ShouldEqual<T>(this IEnumerable<T> actual, IEnumerable<T> expected, IComparer<T> comparer) {
            IEnumerator<T> actualEnumerator = actual.GetEnumerator();
            Assert.NotNull(actualEnumerator);
            IEnumerator<T> expectedEnumerator = expected.GetEnumerator();
            Assert.NotNull(expectedEnumerator);

            //test values
            bool actualHasValue;
            bool expectedHasValue;
            int listIndex = 0;
            while (true) {
                actualHasValue = actualEnumerator.MoveNext();
                expectedHasValue = expectedEnumerator.MoveNext();

                if (!actualHasValue || !expectedHasValue) {
                    break;
                }
                if (comparer.Compare(actualEnumerator.Current, expectedEnumerator.Current) != 0) {
                    string message = string.Format("Enumerable<{4}> not equal at position {1}.{0}Actual:    {2}{0}Expected:  {3}",
                                                   Environment.NewLine,
                                                   listIndex,
                                                   actualEnumerator.Current,
                                                   expectedEnumerator.Current,
                                                   typeof(T));
                    throw new AssertException(message);
                }
                listIndex++;
            }

            //ensure no remaining values after list compare
            if (actualHasValue || expectedHasValue) {
                string message = string.Format("Enumerables not equal in length. Matched {0} items but, {1} has more items remaining.",
                                               listIndex,
                                               actualHasValue ? "Actual" : "Expected");
                throw new AssertException(message);
            }
        }

        public static void ShouldNotBeEmpty(this IEnumerable collection) {
            Assert.NotEmpty(collection);
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> collection, T expected) {
            Assert.DoesNotContain(expected, collection);
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> collection, T expected, IEqualityComparer<T> comparer) {
            Assert.DoesNotContain(expected, collection, comparer);
        }
    }
}