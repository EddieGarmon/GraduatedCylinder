using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct Temperature : IDimension<Temperature, TemperatureUnit>,
                                         IComparable<Temperature>,
                                         IEquatable<Temperature>
    {

        private readonly float _value;

        private readonly TemperatureUnit _units;

        public Temperature(float value, TemperatureUnit units) {
            _value = value;
            _units = units;
        }

        public TemperatureUnit Units => _units;

        public float Value => _value;

        public int CompareTo(Temperature other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(Temperature other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is Temperature other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public Temperature In(TemperatureUnit units) {
            throw new NotImplementedException();
        }

    }
}