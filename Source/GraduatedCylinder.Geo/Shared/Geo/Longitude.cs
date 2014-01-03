using System;

namespace GraduatedCylinder.Geo
{
    public class Longitude
    {
        public const double MaxValue = 180.0;
        public const double MinValue = -180.0;
        private readonly double _value;

        public Longitude(double value) {
            //todo should we auto correct here?
            if (value < MinValue) {
                throw new ArgumentOutOfRangeException("value", "Value below minimum.");
            }
            if (value > MaxValue) {
                throw new ArgumentOutOfRangeException("value", "Value above maximum.");
            }
            _value = value;
        }

        public char Hemisphere {
            get { return (_value < 0) ? 'W' : 'E'; }
        }

        public double Value {
            get { return _value; }
        }

        public override bool Equals(object other) {
            return Equals(other as Longitude);
        }

        public bool Equals(Longitude other) {
            if (other == null) {
                return false;
            }
            return ReferenceEquals(this, other) || GeoComparer.AreEqual(this, other);
        }

        public override int GetHashCode() {
            return _value.GetHashCode();
        }

        public override string ToString() {
            return new PrettyPrinter(this).AsDegreesMinutesSeconds();
        }

        public static bool operator ==(Longitude left, Longitude right) {
            return GeoComparer.AreEqual(left, right);
        }

        public static explicit operator decimal(Longitude longitude) {
            return Convert.ToDecimal(longitude._value);
        }

        public static explicit operator Longitude(decimal value) {
            return new Longitude(Convert.ToDouble(value));
        }

        public static implicit operator double(Longitude longitude) {
            return longitude._value;
        }

        public static implicit operator Longitude(double value) {
            return new Longitude(value);
        }

        public static bool operator !=(Longitude left, Longitude right) {
            return !GeoComparer.AreEqual(left, right);
        }
    }
}