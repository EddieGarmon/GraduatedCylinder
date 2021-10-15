using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct LuminousIntensity : IDimension<LuminousIntensity, LuminousIntensityUnit>
    {

        private readonly float _value;

        private readonly LuminousIntensityUnit _units;

        public LuminousIntensity(float value, LuminousIntensityUnit units) {
            _value = value;
            _units = units;
        }

        public LuminousIntensityUnit Units => _units;

        public float Value => _value;

    }
}