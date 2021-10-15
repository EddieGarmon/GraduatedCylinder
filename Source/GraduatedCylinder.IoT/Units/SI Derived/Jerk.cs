using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Jerk : IDimension<Jerk, JerkUnit>
    {

        private readonly float _value;
        private readonly JerkUnit _units;

        public Jerk(float value, JerkUnit units) {
            _value = value;
            _units = units;
        }

        public JerkUnit Units => _units;

        public float Value => _value;

    }
}