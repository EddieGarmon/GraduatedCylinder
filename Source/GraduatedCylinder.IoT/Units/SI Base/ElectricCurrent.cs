using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct ElectricCurrent : IDimension<ElectricCurrent, ElectricCurrentUnit>
    {

        private readonly float _value;
        private readonly ElectricCurrentUnit _units;

        public ElectricCurrent(float value, ElectricCurrentUnit units) {
            _value = value;
            _units = units;
        }

        public ElectricCurrentUnit Units => _units;

        public float Value => _value;

        public static ElectricCurrent Zero => new ElectricCurrent(0, ElectricCurrentUnit.Ampere);

        public static Power operator *(ElectricCurrent left, ElectricPotential right) {
            var left2 = left.In(ElectricCurrentUnit.Ampere);
            var right2 = right.In(ElectricPotentialUnit.Volt);
            return new Power(left2.Value * right2.Value, PowerUnit.Watts);
        }

        public static ElectricPotential operator *(ElectricCurrent left, ElectricResistance right) {
            ElectricCurrent left2 = left.In(ElectricCurrentUnit.Ampere);
            ElectricResistance right2 = right.In(ElectricResistanceUnit.Ohm);
            return new ElectricPotential(left2.Value * right2.Value, ElectricPotentialUnit.Volt);
        }

    }
}