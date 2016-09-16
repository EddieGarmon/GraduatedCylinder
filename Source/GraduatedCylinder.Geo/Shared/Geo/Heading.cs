using System;

namespace GraduatedCylinder.Geo
{
    public class Heading
    {
        public const double MaxValue = 360;
        public const double MinValue = 0;

        private static readonly Heading _unknown = new Heading();
        private readonly double _value;

        public Heading(double value) {
            if (value < MinValue) {
                throw new ArgumentOutOfRangeException("value", "Value is less than the minimum.");
            }
            if (value > MaxValue) {
                throw new ArgumentOutOfRangeException("value", "Value is greater than the maximum.");
            }
            _value = value;
        }

        private Heading() {
            _value = double.NaN;
        }

        public double Value {
            get { return _value; }
        }

        public static Heading Unknown {
            get { return _unknown; }
        }

        public override int GetHashCode() {
            return _value.GetHashCode();
        }

        public override string ToString() {
            return string.Format("{0:N0}{1}", _value, PrettyPrinter.DegreesSymbol);
        }

        public static implicit operator double(Heading heading) {
            return heading._value;
        }

        public static implicit operator Heading(double value) {
            return new Heading(value);
        }
    }
}