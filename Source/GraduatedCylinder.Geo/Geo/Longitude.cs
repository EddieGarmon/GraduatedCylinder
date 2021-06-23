using System;

namespace GraduatedCylinder.Geo
{
    public class Longitude
    {

        //https://gis.stackexchange.com/questions/8650/measuring-accuracy-of-latitude-and-longitude
        public Longitude(double value) {
            //todo should we auto correct here?
            if (value < MinValue) {
                throw new ArgumentOutOfRangeException(nameof(value), "Value below minimum.");
            }
            if (value > MaxValue) {
                throw new ArgumentOutOfRangeException(nameof(value), "Value above maximum.");
            }
            Value = value;
        }

        public char Hemisphere => (Value < 0) ? 'W' : 'E';

        public double Value { get; }

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
            return Value.GetHashCode();
        }

        public override string ToString() {
            return PrettyPrinter.AsDegreesMinutesSeconds(this);
        }

        public const double MaxValue = 180.0;
        public const double MinValue = -180.0;

        public static bool operator ==(Longitude left, Longitude right) {
            return GeoComparer.AreEqual(left, right);
        }

        public static explicit operator decimal(Longitude longitude) {
            return Convert.ToDecimal(longitude.Value);
        }

        public static explicit operator Longitude(decimal value) {
            return new Longitude(Convert.ToDouble(value));
        }

        public static implicit operator double(Longitude longitude) {
            return longitude.Value;
        }

        public static implicit operator Longitude(double value) {
            return new Longitude(value);
        }

        public static bool operator !=(Longitude left, Longitude right) {
            return !GeoComparer.AreEqual(left, right);
        }

    }
}