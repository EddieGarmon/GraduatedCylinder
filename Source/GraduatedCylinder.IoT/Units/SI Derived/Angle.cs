using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Angle : IDimension<Angle, AngleUnit>
    {

        private readonly float _value;
        private readonly AngleUnit _units;

        public Angle(float value, AngleUnit units) {
            _value = value;
            _units = units;
        }

        public AngleUnit Units => _units;

        public float Value => _value;

    }
}