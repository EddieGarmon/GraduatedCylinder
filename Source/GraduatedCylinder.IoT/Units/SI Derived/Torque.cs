using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Torque : IDimension<Torque, TorqueUnit>
    {

        private readonly float _value;
        private readonly TorqueUnit _units;

        public Torque(float value, TorqueUnit units) {
            _value = value;
            _units = units;
        }

        public TorqueUnit Units => _units;

        public float Value => _value;

    }
}