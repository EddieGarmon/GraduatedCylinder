using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct AmountOfSubstance : IDimension<AmountOfSubstance, AmountOfSubstanceUnit>
    {

        private readonly float _value;
        private readonly AmountOfSubstanceUnit _units;

        public AmountOfSubstance(float value, AmountOfSubstanceUnit units) {
            _value = value;
            _units = units;
        }

        public AmountOfSubstanceUnit Units => _units;

        public float Value => _value;

    }
}