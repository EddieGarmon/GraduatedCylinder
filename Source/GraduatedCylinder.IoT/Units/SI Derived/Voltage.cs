using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Voltage : IDimension<Voltage, VoltageUnit>
    {

        private readonly float _value;
        private readonly VoltageUnit _units;

        public Voltage(float value, VoltageUnit units) {
            _value = value;
            _units = units;
        }

        public VoltageUnit Units => _units;

        public float Value => _value;

    }
}