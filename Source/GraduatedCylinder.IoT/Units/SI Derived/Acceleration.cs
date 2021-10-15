using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Acceleration : IDimension<Acceleration, AccelerationUnit>
    {

        private readonly float _value;
        private readonly AccelerationUnit _units;

        public Acceleration(float value, AccelerationUnit units) {
            _value = value;
            _units = units;
        }

        public AccelerationUnit Units => _units;

        public float Value => _value;

    }
}