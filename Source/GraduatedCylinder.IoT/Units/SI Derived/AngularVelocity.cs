using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct AngularVelocity : IDimension<AngularVelocity, AngularVelocityUnit>
    {

        private readonly float _value;
        private readonly AngularVelocityUnit _units;

        public AngularVelocity(float value, AngularVelocityUnit units) {
            _value = value;
            _units = units;
        }

        public AngularVelocityUnit Units => _units;

        public float Value => _value;

    }
}