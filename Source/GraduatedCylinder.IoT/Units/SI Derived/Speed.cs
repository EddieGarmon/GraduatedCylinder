using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Speed : IDimension<Speed, SpeedUnit>
    {

        private readonly float _value;
        private readonly SpeedUnit _units;

        public Speed(float value, SpeedUnit units) {
            _value = value;
            _units = units;
        }

        public SpeedUnit Units => _units;

        public float Value => _value;

    }
}