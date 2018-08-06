using System;

namespace GraduatedCylinder
{
    public class Time : Dimension,
                        IDimension<TimeUnit>,
                        IEquatable<Time>,
                        IComparable<Time>
    {
        public Time(double value, TimeUnit units)
            : base(value, units) { }

        public Time(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Time);
        }

        internal Time(double valueInBaseUnits)
            : base(valueInBaseUnits, TimeUnit.BaseUnit) { }

        public int CompareTo(Time other) {
            return base.CompareTo(other);
        }

        public bool Equals(Time other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is Time time) && Equals(time);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(TimeUnit units) {
            return base.In(units);
        }

        public string ToString(TimeUnit units) {
            return base.ToString(units);
        }

        public string ToString(TimeUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Time Zero => new Time(0);

        public static Time Parse(string input) {
            return (Time)Factory.Parse(input, DimensionType.Time);
        }

        public static Time operator +(Time left, Time right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            return new Time(left.ValueInBaseUnits + right.ValueInBaseUnits) {
                Units = left.Units
            };
        }

        public static Time operator /(Time time, double scaler) {
            Guard.NotNull(time, nameof(time));
            return new Time(time.ValueInBaseUnits / scaler) {
                Units = time.Units
            };
        }

        public static double operator /(Time numerator, Time denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Time left, Time right) {
            return Equals(left, right);
        }

        public static bool operator >(Time left, Time right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Time left, Time right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static implicit operator Time(TimeSpan source) {
            return new Time(source.TotalSeconds, TimeUnit.Second);
        }

        public static implicit operator TimeSpan(Time source) {
            return new TimeSpan((long)source.In(TimeUnit.Ticks));
        }

        public static bool operator !=(Time left, Time right) {
            return !Equals(left, right);
        }

        public static bool operator <(Time left, Time right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Time left, Time right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Time operator *(Time time, double scaler) {
            Guard.NotNull(time, nameof(time));
            return new Time(time.ValueInBaseUnits * scaler) {
                Units = time.Units
            };
        }

        public static Time operator *(double scaler, Time time) {
            Guard.NotNull(time, nameof(time));
            return new Time(time.ValueInBaseUnits * scaler) {
                Units = time.Units
            };
        }

        public static Length operator *(Time time, Speed speed) {
            Guard.NotNull(time, nameof(time));
            Guard.NotNull(speed, nameof(speed));
            double lengthValue = time.In(TimeUnit.Second) * speed.In(SpeedUnit.MeterPerSecond);
            return new Length(lengthValue, LengthUnit.Meter);
        }

        public static Speed operator *(Time time, Acceleration acceleration) {
            Guard.NotNull(time, nameof(time));
            Guard.NotNull(acceleration, nameof(acceleration));
            double value = time.In(TimeUnit.Second) * acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            return new Speed(value, SpeedUnit.MeterPerSecond);
        }

        public static Energy operator *(Time time, Power power) {
            Guard.NotNull(time, nameof(time));
            Guard.NotNull(power, nameof(power));
            double value = time.In(TimeUnit.Second) * power.In(PowerUnit.NewtonMetersPerSecond);
            return new Energy(value, EnergyUnit.NewtonMeters);
        }

        public static Mass operator *(Time time, MassFlowRate massFlowRate) {
            Guard.NotNull(time, nameof(time));
            Guard.NotNull(massFlowRate, nameof(massFlowRate));
            double value = time.In(TimeUnit.Second) * massFlowRate.In(MassFlowRateUnit.KilogramsPerSecond);
            return new Mass(value, MassUnit.Kilogram);
        }

        public static Momentum operator *(Time time, Force force) {
            Guard.NotNull(time, nameof(time));
            Guard.NotNull(force, nameof(force));
            double value = time.In(TimeUnit.Second) * force.In(ForceUnit.Newtons);
            return new Momentum(value, MomentumUnit.KilogramMetersPerSecond);
        }

        public static Volume operator *(Time time, VolumetricFlowRate volumetricFlowRate) {
            Guard.NotNull(time, nameof(time));
            Guard.NotNull(volumetricFlowRate, nameof(volumetricFlowRate));
            double value = time.In(TimeUnit.Second)
                           * volumetricFlowRate.In(VolumetricFlowRateUnit.CubicMetersPerSecond);
            return new Volume(value, VolumeUnit.CubicMeters);
        }

        public static Acceleration operator *(Time time, Jerk jerk) {
            Guard.NotNull(jerk, nameof(jerk));
            Guard.NotNull(time, nameof(time));
            double accelerationValue = time.In(TimeUnit.Second) * jerk.In(JerkUnit.MetersPerSecondCubed);
            return new Acceleration(accelerationValue, AccelerationUnit.MeterPerSecondSquared);
        }

        public static Time operator -(Time time1, Time time2) {
            Guard.NotNull(time1, nameof(time1));
            Guard.NotNull(time2, nameof(time2));
            return new Time(time1.ValueInBaseUnits - time2.ValueInBaseUnits) {
                Units = time1.Units
            };
        }
    }
}