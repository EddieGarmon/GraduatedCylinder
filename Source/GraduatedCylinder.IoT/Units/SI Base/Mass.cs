using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Mass : IDimension<Mass, MassUnit>
    {

        private readonly float _value;
        private readonly MassUnit _units;

        public Mass(float value, MassUnit units) {
            _value = value;
            _units = units;
        }

        public MassUnit Units => _units;

        public float Value => _value;

    }
}