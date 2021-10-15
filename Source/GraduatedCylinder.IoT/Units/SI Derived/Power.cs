using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Power : IDimension<Power, PowerUnit>
    {

        private readonly float _value;
        private readonly PowerUnit _units;

        public Power(float value, PowerUnit units) {
            _value = value;
            _units = units;
        }

        public PowerUnit Units => _units;

        public float Value => _value;

    }
}