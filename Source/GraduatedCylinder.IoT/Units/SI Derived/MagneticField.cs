using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct MagneticField : IDimension<MagneticField, MagneticFieldUnit>
    {

        private readonly float _value;
        private readonly MagneticFieldUnit _units;

        public MagneticField(float value, MagneticFieldUnit units) {
            _value = value;
            _units = units;
        }

        public MagneticFieldUnit Units => _units;

        public float Value => _value;

    }
}