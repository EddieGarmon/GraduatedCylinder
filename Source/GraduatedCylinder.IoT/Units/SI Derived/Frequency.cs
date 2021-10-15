using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Frequency : IDimension<Frequency, FrequencyUnit>
    {

        private readonly float _value;
        private readonly FrequencyUnit _units;

        public Frequency(float value, FrequencyUnit units) {
            _value = value;
            _units = units;
        }

        public FrequencyUnit Units => _units;

        public float Value => _value;

    }
}