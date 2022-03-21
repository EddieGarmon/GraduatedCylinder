using System.Runtime.InteropServices;

namespace GraduatedCylinder;

[StructLayout(LayoutKind.Sequential)]
public readonly struct AngularVelocity3D
{

    private readonly AngularVelocity _x;
    private readonly AngularVelocity _y;
    private readonly AngularVelocity _z;

    public AngularVelocity3D(AngularVelocity x, AngularVelocity y, AngularVelocity z) {
        _x = x;
        _y = y;
        _z = z;
    }

    public AngularVelocity X => _x;

    public AngularVelocity Y => _y;

    public AngularVelocity Z => _z;

}