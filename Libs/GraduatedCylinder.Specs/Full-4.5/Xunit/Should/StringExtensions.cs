using System;
using Xunit.Sdk;

namespace Xunit.Should
{
    /// <summary>
    ///     Extensions which provide assertions to classes derived from <see cref="string" />.
    /// </summary>
    /// <remarks></remarks>
    public static class StringExtensions
    {
        public static void ShouldContain(this string actual,
                                         string fragment,
                                         StringComparison comparisonType = StringComparison.CurrentCulture) {
            Assert.Contains(fragment, actual, comparisonType);
        }

        public static void ShouldEndWith(this string actual,
                                         string ending,
                                         StringComparison stringComparison = StringComparison.CurrentCulture) {
            if (actual.Length < ending.Length) {
                throw new EqualException(ending, actual);
            }
            string temp = actual.Substring(actual.Length - ending.Length);
            Assert.Equal(ending, temp, stringComparison.GetComparer());
        }

        public static void ShouldEqual(this string actual,
                                       string expected,
                                       StringComparison comparisonType = StringComparison.CurrentCulture) {
            Assert.Equal(expected, actual, comparisonType.GetComparer());
        }

        public static void ShouldNotContain(this string actual,
                                            string fragment,
                                            StringComparison comparisonType = StringComparison.CurrentCulture) {
            Assert.DoesNotContain(fragment, actual, comparisonType);
        }

        public static void ShouldNotEndWith(this string actual,
                                            string ending,
                                            StringComparison comparisonType = StringComparison.CurrentCulture) {
            if (actual.Length < ending.Length) {
                return;
            }
            string temp = actual.Substring(actual.Length - ending.Length);
            Assert.NotEqual(ending, temp, comparisonType.GetComparer());
        }

        public static void ShouldNotStartWith(this string actual,
                                              string begining,
                                              StringComparison comparisonType = StringComparison.CurrentCulture) {
            if (actual.Length < begining.Length) {
                return;
            }
            string temp = actual.Substring(0, begining.Length);
            Assert.NotEqual(begining, temp, comparisonType.GetComparer());
        }

        public static void ShouldStartWith(this string actual,
                                           string begining,
                                           StringComparison comparisonType = StringComparison.CurrentCulture) {
            if (actual.Length < begining.Length) {
                throw new EqualException(begining, actual);
            }
            string temp = actual.Substring(0, begining.Length);
            Assert.Equal(begining, temp, comparisonType.GetComparer());
        }
    }
}