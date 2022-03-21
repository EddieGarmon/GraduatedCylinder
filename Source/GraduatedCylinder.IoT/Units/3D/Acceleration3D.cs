using System.Runtime.InteropServices;

namespace GraduatedCylinder;

[StructLayout(LayoutKind.Sequential)]
public readonly struct Acceleration3D
{

    private readonly Acceleration _x;
    private readonly Acceleration _y;
    private readonly Acceleration _z;

    public Acceleration3D(Acceleration x, Acceleration y, Acceleration z) {
        _x = x;
        _y = y;
        _z = z;
    }

    public Acceleration X => _x;

    public Acceleration Y => _y;

    public Acceleration Z => _z;

}