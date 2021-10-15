using System;
using System.Runtime.InteropServices;
using GraduatedCylinder.Units;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct MassFlowRate : IDimension<MassFlowRate, MassFlowRateUnit>,
                                          IComparable<MassFlowRate>,
                                          IEquatable<MassFlowRate>
    {

        private readonly float _value;
        private readonly MassFlowRateUnit _units;

        public MassFlowRate(float value, MassFlowRateUnit units) {
            _value = value;
            _units = units;
        }

        public MassFlowRateUnit Units => _units;

        public float Value => _value;

        public int CompareTo(MassFlowRate other) {
            int unitsComparison = _units.CompareTo(other._units);
            if (unitsComparison != 0) {
                return unitsComparison;
            }
            return _value.CompareTo(other._value);
        }

        public bool Equals(MassFlowRate other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object? obj) {
            return obj is MassFlowRate other && Equals(other);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)_units, _value);
        }

        public MassFlowRate In(MassFlowRateUnit units) {
            throw new NotImplementedException();
        }

    }
}