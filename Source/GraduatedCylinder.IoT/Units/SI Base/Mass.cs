using System.Runtime.InteropServices;

namespace GraduatedCylinder
{
    [StructLayout(LayoutKind.Sequential)]
    public readonly partial struct Mass : IDimension<Mass, MassUnit>
    {

        private readonly float _value;
        private readonly MassUnit _units;

        public Mass(float value, MassUnit units) {
            _value = value;
            _units = units;
        }

        public MassUnit Units => _units;

        public float Value => _value;

        public static MassDensity operator /(Mass left, Volume right) {
            Mass left2 = left.In(MassUnit.Kilogram);
            Volume right2 = right.In(VolumeUnit.CubicMeters);
            return new MassDensity(left2.Value / right2.Value, MassDensityUnit.KilogramsPerCubicMeter);
        }

        public static MassFlowRate operator /(Mass left, Time right) {
            Mass left2 = left.In(MassUnit.Kilogram);
            Time right2 = right.In(TimeUnit.Second);
            return new MassFlowRate(left2.Value / right2.Value, MassFlowRateUnit.KilogramsPerSecond);
        }

        public static Time operator /(Mass left, MassFlowRate right) {
            Mass left2 = left.In(MassUnit.Kilogram);
            MassFlowRate right2 = right.In(MassFlowRateUnit.KilogramsPerSecond);
            return new Time(left2.Value / right2.Value, TimeUnit.Second);
        }

        public static Volume operator /(Mass left, MassDensity right) {
            Mass left2 = left.In(MassUnit.Kilogram);
            MassDensity right2 = right.In(MassDensityUnit.KilogramsPerCubicMeter);
            return new Volume(left2.Value / right2.Value, VolumeUnit.CubicMeters);
        }

        public static Force operator *(Mass left, Acceleration right) {
            Mass left2 = left.In(MassUnit.Kilogram);
            Acceleration right2 = right.In(AccelerationUnit.MegameterPerSecondSquared);
            return new Force(left2.Value * right2.Value, ForceUnit.Newtons);
        }

        public static Momentum operator *(Mass left, Speed right) {
            Mass left2 = left.In(MassUnit.Kilogram);
            Speed right2 = right.In(SpeedUnit.MeterPerSecond);
            return new Momentum(left2.Value * right2.Value, MomentumUnit.KilogramMetersPerSecond);
        }

    }
}