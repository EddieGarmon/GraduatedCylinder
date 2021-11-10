using Xunit.Sdk;

namespace GraduatedCylinder;

public class ToleranceException : XunitException
{

    public ToleranceException(double actual, double expected, double delta) {
        Actual = actual;
        Expected = expected;
        Delta = delta;
    }

    public double Actual { get; }

    public double Delta { get; }

    public double Expected { get; }

    public override string Message {
        get => $"Actual:    {Actual}\r\nExpected:  {Expected}\r\nDelta:     {Delta}";
    }

}