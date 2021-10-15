using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct ElectricResistance : IDimension<ElectricResistance, ElectricResistanceUnit>
    {

        private readonly float _value;
        private readonly ElectricResistanceUnit _units;

        public ElectricResistance(float value, ElectricResistanceUnit units) {
            _value = value;
            _units = units;
        }

        public ElectricResistanceUnit Units => _units;

        public float Value => _value;

    }
}