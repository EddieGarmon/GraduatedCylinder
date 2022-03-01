using System.Runtime.InteropServices;

namespace GraduatedCylinder;

[StructLayout(LayoutKind.Sequential)]
public readonly struct MagneticField3D
{

    private readonly MagneticField _x;
    private readonly MagneticField _y;
    private readonly MagneticField _z;

    public MagneticField3D(MagneticField x, MagneticField y, MagneticField z) {
        _x = x;
        _y = y;
        _z = z;
    }

    public MagneticField X => _x;

    public MagneticField Y => _y;

    public MagneticField Z => _z;

}