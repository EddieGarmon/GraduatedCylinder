namespace GraduatedCylinder.Geo;

public readonly struct Heading
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

    public Heading() {
        Value = double.NaN;
    }

    public double Value { get; }

    public override int GetHashCode() {
        return Value.GetHashCode();
    }

    public override string ToString() {
        return $"{Value:N0}{PrettyPrinter.DegreesSymbol}";
    }

    public const double MaxValue = 360;
    public const double MinValue = 0;

    public static Heading Unknown { get; } = new();

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