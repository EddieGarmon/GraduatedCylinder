using System;
using Xunit.Sdk;

namespace Xunit.Should
{
    public static class ComparableShouldExtensions
    {
        public static void ShouldBeGreaterThan<T>(this T actual, T expected) where T : IComparable<T> {
            if (actual.CompareTo(expected) <= 0) {
                throw new RangeException(actual, expected, false, null, false);
            }
        }

        public static void ShouldBeGreaterThanOrEqual<T>(this T actual, T expected) where T : IComparable<T> {
            if (actual.CompareTo(expected) < 0) {
                throw new RangeException(actual, expected, true, null, false);
            }
        }

        public static void ShouldBeLessThan<T>(this T actual, T expected) where T : IComparable<T> {
            if (actual.CompareTo(expected) >= 0) {
                throw new RangeException(actual, null, false, expected, false);
            }
        }

        public static void ShouldBeLessThanOrEqual<T>(this T actual, T expected) where T : IComparable<T> {
            if (actual.CompareTo(expected) > 0) {
                throw new RangeException(actual, null, false, expected, true);
            }
        }
    }

    internal class RangeException : AssertException
    {
        private readonly string _actual;
        private readonly string _high;
        private readonly bool _highInclusive;
        private readonly string _low;
        private readonly bool _lowInclusive;

        public RangeException(object actual, object low, bool lowInclusive, object high, bool highInclusive)
            : base("Assert.InRange() Failure") {
            _actual = actual == null ? null : actual.ToString();
            _low = low == null ? null : low.ToString();
            _lowInclusive = lowInclusive;
            _high = high == null ? null : high.ToString();
            _highInclusive = highInclusive;
        }

        public string Actual {
            get { return _actual; }
        }

        public string High {
            get { return _high; }
        }

        public bool HighInclusive {
            get { return _highInclusive; }
        }

        public string Low {
            get { return _low; }
        }

        public bool LowInclusive {
            get { return _lowInclusive; }
        }

        public override string Message {
            get {
                return string.Format("{0}\r\nRange:  {1}{2} - {3}{4}\r\nActual: {5}",
                                     base.Message,
                                     LowInclusive ? "[" : "(",
                                     Low,
                                     High,
                                     HighInclusive ? "]" : ")",
                                     Actual ?? "(null)");
            }
        }
    }
}