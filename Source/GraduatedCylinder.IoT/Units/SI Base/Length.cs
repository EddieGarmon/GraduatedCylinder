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

        public static Length operator +(Length left, Length right) {
            Length right2 = right.In(left.Units);
            return new Length(left.Value + right2.Value, left.Units);
        }

        public static Length operator /(Length length, float scaler) {
            return new Length(length.Value / scaler, length.Units);
        }

        public static Speed operator /(Length length, Time time) {
            Length length2 = length.In(LengthUnit.Meter);
            Time time2 = time.In(TimeUnit.Second);
            return new Speed(length2.Value / time2.Value, SpeedUnit.MeterPerSecond);
        }

        public static double operator /(Length numerator, Length denominator) {
            Length denominator2 = denominator.In(numerator.Units);
            return numerator.Value / denominator2.Value;
        }

        public static Time operator /(Length length, Speed speed) {
            Length length2 = length.In(LengthUnit.Meter);
            Speed speed2 = speed.In(SpeedUnit.MeterPerSecond);
            return new Time(length2.Value / speed2.Value, TimeUnit.Second);
        }

        public static Length operator *(Length length, float scaler) {
            return new Length(length.Value * scaler, length.Units);
        }

        public static Length operator *(float scaler, Length length) {
            return new Length(length.Value * scaler, length.Units);
        }

        public static Area operator *(Length left, Length right) {
            Length left2 = left.In(LengthUnit.Meter);
            Length right2 = right.In(LengthUnit.Meter);
            return new Area(left2.Value * right2.Value, AreaUnit.MeterSquared);
        }

        public static Volume operator *(Length length, Area area) {
            Length length2 = length.In(LengthUnit.Meter);
            Area area2 = area.In(AreaUnit.MeterSquared);
            return new Volume(length2.Value * area2.Value, VolumeUnit.CubicMeters);
        }

        public static Energy operator *(Length length, Force force) {
            Length length2 = length.In(LengthUnit.Meter);
            Force force2 = force.In(ForceUnit.Newtons);
            return new Energy(length2.Value * force2.Value, EnergyUnit.NewtonMeters);
        }

        public static Length operator -(Length left, Length right) {
            Length right2 = right.In(left.Units);
            return new Length(left.Value - right2.Value, left.Units);
        }

        public static Length operator -(Length source) {
            return new Length(-source.Value, source.Units);
        }

    }
}