using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Force : IDimension<Force, ForceUnit>
    {

        private readonly float _value;
        private readonly ForceUnit _units;

        public Force(float value, ForceUnit units) {
            _value = value;
            _units = units;
        }

        public ForceUnit Units => _units;

        public float Value => _value;

    }
}