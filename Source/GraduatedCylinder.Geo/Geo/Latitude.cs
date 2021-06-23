using System;

namespace GraduatedCylinder.Geo
{
    public class Latitude
    {

        //https://gis.stackexchange.com/questions/8650/measuring-accuracy-of-latitude-and-longitude
        public Latitude(double value) {
            if (value < MinValue) {
                throw new ArgumentOutOfRangeException(nameof(value), "Value below South Pole.");
            }
            if (value > MaxValue) {
                throw new ArgumentOutOfRangeException(nameof(value), "Value above North Pole.");
            }
            Value = value;
        }

        public char Hemisphere => (Value < 0) ? 'S' : 'N';

        public double Value { get; }

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
            return Value.GetHashCode();
        }

        public override string ToString() {
            return PrettyPrinter.AsDegreesMinutesSeconds(this);
        }

        public const double MaxValue = 90.0;
        public const double MinValue = -90.0;

        public static bool operator ==(Latitude left, Latitude right) {
            return GeoComparer.AreEqual(left, right);
        }

        public static explicit operator decimal(Latitude latitude) {
            return Convert.ToDecimal(latitude.Value);
        }

        public static explicit operator Latitude(decimal value) {
            return new Latitude(Convert.ToDouble(value));
        }

        public static implicit operator double(Latitude latitude) {
            return latitude.Value;
        }

        public static implicit operator Latitude(double value) {
            return new Latitude(value);
        }

        public static bool operator !=(Latitude left, Latitude right) {
            return !GeoComparer.AreEqual(left, right);
        }

    }
}