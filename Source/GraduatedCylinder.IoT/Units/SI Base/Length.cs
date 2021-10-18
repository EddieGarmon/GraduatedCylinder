using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Length : IDimension<Length, LengthUnit>
    {

        private readonly float _value;
        private readonly LengthUnit _units;

        public Length(float value, LengthUnit units) {
            _value = value;
            _units = units;
        }

        public LengthUnit Units => _units;

        public float Value => _value;

        public static Area operator *(Length left, Length right) {
            Length left2 = left.In(LengthUnit.Meter);
            Length right2 = right.In(LengthUnit.Meter);
            return new Area(left2.Value * right2.Value, AreaUnit.MeterSquared);
        }

    }
}