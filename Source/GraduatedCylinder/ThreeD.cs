using System.Runtime.InteropServices;

namespace GraduatedCylinder;

[StructLayout(LayoutKind.Sequential)]
public readonly struct ThreeD<TDimension>
{

    public ThreeD(TDimension x, TDimension y, TDimension z) {
        X = x;
        Y = y;
        Z = z;
    }

    public TDimension X { get; }

    public TDimension Y { get; }

    public TDimension Z { get; }

}