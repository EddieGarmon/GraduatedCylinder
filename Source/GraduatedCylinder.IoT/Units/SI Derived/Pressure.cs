using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Pressure : IDimension<Pressure, PressureUnit>
    {

        private readonly float _value;
        private readonly PressureUnit _units;

        public Pressure(float value, PressureUnit units) {
            _value = value;
            _units = units;
        }

        public PressureUnit Units => _units;

        public float Value => _value;

    }
}