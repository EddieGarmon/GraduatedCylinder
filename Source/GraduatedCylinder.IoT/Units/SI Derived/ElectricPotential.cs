using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct ElectricPotential : IDimension<ElectricPotential, ElectricPotentialUnit>
    {

        private readonly float _value;
        private readonly ElectricPotentialUnit _units;

        public ElectricPotential(float value, ElectricPotentialUnit units) {
            _value = value;
            _units = units;
        }

        public ElectricPotentialUnit Units => _units;

        public float Value => _value;

    }
}