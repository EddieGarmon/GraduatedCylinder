namespace GraduatedCylinder.Geo;

public readonly struct Latitude : IComparable<Latitude>, IEquatable<Latitude>
{

    //https://gis.stackexchange.com/questions/8650/measuring-accuracy-of-latitude-and-longitude
    //NB: 5 or 6 decimal places max
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

    public int CompareTo(Latitude other) {
        return GeoComparer.AreEqual(this, other) ? 0 : Value.CompareTo(other.Value);
    }

    public override bool Equals(object? other) {
        return other is Latitude latitude && Equals(latitude);
    }

    public bool Equals(Latitude other) {
        return GeoComparer.AreEqual(this, other);
    }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override string ToString() {
        return PrettyPrinter.AsDegreesMinutesSeconds(this);
    }

    public const double MaxValue = 90.0;
    public const double MinValue = -90.0;

    public static Latitude NorthPole { get; } = new Latitude(MaxValue);

    public static Latitude SouthPole { get; } = new Latitude(MinValue);

    public static bool operator ==(Latitude left, Latitude right) {
        return GeoComparer.AreEqual(left, right);
    }

    public static explicit operator decimal(Latitude latitude) {
        return Convert.ToDecimal(latitude.Value);
    }

    public static explicit operator Latitude(decimal value) {
        return new Latitude(Convert.ToDouble(value));
    }

    public static bool operator >(Latitude left, Latitude right) {
        return left.CompareTo(right) > 0;
    }

    public static bool operator >=(Latitude left, Latitude right) {
        return left.CompareTo(right) >= 0;
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

    public static bool operator <(Latitude left, Latitude right) {
        return left.CompareTo(right) < 0;
    }

    public static bool operator <=(Latitude left, Latitude right) {
        return left.CompareTo(right) <= 0;
    }

}