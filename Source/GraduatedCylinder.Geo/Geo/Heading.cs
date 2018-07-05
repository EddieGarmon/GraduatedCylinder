using System;

namespace GraduatedCylinder.Geo
{
    public class Heading
    {
        public Heading(double value) {
            if (value < MinValue) {
                throw new ArgumentOutOfRangeException(nameof(value), "Value is less than the minimum.");
            }
            if (value > MaxValue) {
                throw new ArgumentOutOfRangeException(nameof(value), "Value is greater than the maximum.");
            }
            Value = value;
        }

        private Heading() {
            Value = double.NaN;
        }

        public double Value { get; }

        public override int GetHashCode() {
            return Value.GetHashCode();
        }

        public override string ToString() {
            return string.Format("{0:N0}{1}", Value, PrettyPrinter.DegreesSymbol);
        }

        public const double MaxValue = 360;
        public const double MinValue = 0;

        public static Heading Unknown => new Heading();

        public static Heading Parse(string heading) {
            return new Heading(double.Parse(heading.TrimEnd(PrettyPrinter.DegreesSymbol)));
        }

        public static implicit operator double(Heading heading) {
            return heading.Value;
        }

        public static implicit operator Heading(double value) {
            return new Heading(value);
        }
    }
}