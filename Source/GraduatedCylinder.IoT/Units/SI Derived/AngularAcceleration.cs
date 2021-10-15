using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct AngularAcceleration : IDimension<AngularAcceleration, AngularAccelerationUnit>
    {

        private readonly float _value;
        private readonly AngularAccelerationUnit _units;

        public AngularAcceleration(float value, AngularAccelerationUnit units) {
            _value = value;
            _units = units;
        }

        public AngularAccelerationUnit Units => _units;

        public float Value => _value;

    }
}