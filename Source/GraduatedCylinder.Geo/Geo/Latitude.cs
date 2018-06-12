using System;

namespace GraduatedCylinder.Geo
{
    public class Latitude
    {
        public const double MaxValue = 90.0;
        public const double MinValue = -90.0;
        private readonly double _value;

        public Latitude(double value) {
            if (value < MinValue) {
                throw new ArgumentOutOfRangeException("value", "Value below South Pole.");
            }
            if (value > MaxValue) {
                throw new ArgumentOutOfRangeException("value", "Value above North Pole.");
            }
            _value = value;
        }

        public char Hemisphere {
            get { return (_value < 0) ? 'S' : 'N'; }
        }

        public double Value {
            get { return _value; }
        }

        public override bool Equals(object other) {
            return Equals(other as Latitude);
        }

        public bool Equals(Latitude other) {
            if (other == null) {
                return false;
            }
            return ReferenceEquals(this, other) || GeoComparer.AreEqual(this, other);
        }

        public override int GetHashCode() {
            return _value.GetHashCode();
        }

        public override string ToString() {
            return PrettyPrinter.AsDegreesMinutesSeconds(this);
        }

        public static bool operator ==(Latitude left, Latitude right) {
            return GeoComparer.AreEqual(left, right);
        }

        public static explicit operator decimal(Latitude latitude) {
            return Convert.ToDecimal(latitude._value);
        }

        public static explicit operator Latitude(decimal value) {
            return new Latitude(Convert.ToDouble(value));
        }

        public static implicit operator double(Latitude latitude) {
            return latitude._value;
        }

        public static implicit operator Latitude(double value) {
            return new Latitude(value);
        }

        public static bool operator !=(Latitude left, Latitude right) {
            return !GeoComparer.AreEqual(left, right);
        }
    }
}