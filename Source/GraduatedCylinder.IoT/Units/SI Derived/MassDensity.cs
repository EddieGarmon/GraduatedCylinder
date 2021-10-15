using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct MassDensity : IDimension<MassDensity, MassDensityUnit>
    {

        private readonly float _value;
        private readonly MassDensityUnit _units;

        public MassDensity(float value, MassDensityUnit units) {
            _value = value;
            _units = units;
        }

        public MassDensityUnit Units => _units;

        public float Value => _value;

    }
}