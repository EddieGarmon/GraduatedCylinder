using System.Runtime.InteropServices;

namespace GraduatedCylinder;

[StructLayout(LayoutKind.Sequential)]
public readonly struct AngularAcceleration3D
{

    private readonly AngularAcceleration _x;
    private readonly AngularAcceleration _y;
    private readonly AngularAcceleration _z;

    public AngularAcceleration3D(AngularAcceleration x, AngularAcceleration y, AngularAcceleration z) {
        _x = x;
        _y = y;
        _z = z;
    }

    public AngularAcceleration X => _x;

    public AngularAcceleration Y => _y;

    public AngularAcceleration Z => _z;

}