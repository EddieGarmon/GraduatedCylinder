using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Temperature : IDimension<Temperature, TemperatureUnit>
    {

        private readonly float _value;

        private readonly TemperatureUnit _units;

        public Temperature(float value, TemperatureUnit units) {
            _value = value;
            _units = units;
        }

        public TemperatureUnit Units => _units;

        public float Value => _value;

    }
}