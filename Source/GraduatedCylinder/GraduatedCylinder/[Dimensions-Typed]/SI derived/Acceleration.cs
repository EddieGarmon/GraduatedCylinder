using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents acceleration,
    ///     which is the second derivative of position with respect to time,
    ///     and the first derivative of speed with respect to time.
    /// </summary>
    /// <remarks></remarks>
    public class Acceleration : Dimension,
                                IEquatable<Acceleration>,
                                IComparable<Acceleration>
    {
        public Acceleration(double value, AccelerationUnit units)
            : base(value, units) { }

        public Acceleration(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            DimensionType.ShouldBe(DimensionType.Acceleration);
        }

        internal Acceleration(double baseUnitsValue)
            : base(baseUnitsValue, AccelerationUnit.BaseUnit) { }

        public int CompareTo(Acceleration other) {
            return base.CompareTo(other);
        }

        public bool Equals(Acceleration other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Acceleration)) {
                return false;
            }
            return Equals((Acceleration)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(AccelerationUnit units) {
            return base.In(units);
        }

        public string ToString(AccelerationUnit units) {
            return base.ToString(units);
        }

        public string ToString(AccelerationUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static readonly Acceleration Gravity = new Acceleration(9.80665, AccelerationUnit.MeterPerSecondSquared);

        public static Acceleration operator +(Acceleration left, Acceleration right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Acceleration(left.ValueInBaseUnits + right.ValueInBaseUnits) {
                Units = left.Units
            };
        }

        public static double operator /(Acceleration numerator, Acceleration denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static Acceleration operator /(Acceleration acceleration, double scaler) {
            Guard.NotNull(acceleration, "acceleration");
            return new Acceleration(acceleration.ValueInBaseUnits / scaler) {
                Units = acceleration.Units
            };
        }

        public static Time operator /(Acceleration acceleration, Jerk jerk) {
            Guard.NotNull(acceleration, "acceleration");
            Guard.NotNull(jerk, "jerk");
            double timeValue = acceleration.In(AccelerationUnit.MeterPerSecondSquared)
                               / jerk.In(JerkUnit.MetersPerSecondCubed);
            return new Time(timeValue, TimeUnit.Second);
        }

        public static Jerk operator /(Acceleration acceleration, Time time) {
            Guard.NotNull(acceleration, "acceleration");
            Guard.NotNull(time, "time");
            double jerkValue = acceleration.In(AccelerationUnit.MeterPerSecondSquared) / time.In(TimeUnit.Second);
            return new Jerk(jerkValue, JerkUnit.MetersPerSecondCubed);
        }

        public static bool operator >(Acceleration left, Acceleration right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Acceleration left, Acceleration right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) >= 0;
        }

        public static implicit operator Acceleration(string value) {
            //todo: decide where to go here
            return Factory.Parse<Acceleration>(value);
        }

        public static bool operator <(Acceleration left, Acceleration right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Acceleration left, Acceleration right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) <= 0;
        }

        public static Acceleration operator *(Acceleration acceleration, double scaler) {
            Guard.NotNull(acceleration, "acceleration");
            return new Acceleration(acceleration.ValueInBaseUnits * scaler) {
                Units = acceleration.Units
            };
        }

        public static Acceleration operator *(double scaler, Acceleration acceleration) {
            Guard.NotNull(acceleration, "acceleration");
            return new Acceleration(acceleration.ValueInBaseUnits * scaler) {
                Units = acceleration.Units
            };
        }

        public static Force operator *(Acceleration acceleration, Mass mass) {
            Guard.NotNull(acceleration, "acceleration");
            Guard.NotNull(mass, "mass");
            double forceValue = acceleration.In(AccelerationUnit.MeterPerSecondSquared) * mass.In(MassUnit.Kilogram);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Power operator *(Acceleration acceleration, Momentum momentum) {
            Guard.NotNull(momentum, "momentum");
            Guard.NotNull(acceleration, "acceleration");
            double powerValue = momentum.In(MomentumUnit.KilogramMetersPerSecond)
                                * acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Speed operator *(Acceleration acceleration, Time time) {
            Guard.NotNull(acceleration, "acceleration");
            Guard.NotNull(time, "time");
            double speedValue = acceleration.In(AccelerationUnit.MeterPerSecondSquared) * time.In(TimeUnit.Second);
            return new Speed(speedValue, SpeedUnit.MeterPerSecond);
        }

        public static Acceleration operator -(Acceleration left, Acceleration right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Acceleration(left.ValueInBaseUnits - right.ValueInBaseUnits) {
                Units = left.Units
            };
        }
    }
}