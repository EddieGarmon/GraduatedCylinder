using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Energy : IDimension<Energy, EnergyUnit>
    {

        private readonly EnergyUnit _units;
        private readonly float _value;

        public Energy(float value, EnergyUnit units) {
            _value = value;
            _units = units;
        }

        public EnergyUnit Units => _units;

        public float Value => _value;

    }
}