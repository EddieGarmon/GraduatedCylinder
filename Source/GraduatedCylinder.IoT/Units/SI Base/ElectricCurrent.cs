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

        //todo: operators

    }
}