using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents energy, work, or quantity of heat.
    /// </summary>
    public class Energy : Dimension,
                          IEquatable<Energy>,
                          IComparable<Energy>
    {
        public Energy(double value, EnergyUnit units)
            : base(value, units) { }

        public Energy(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Energy);
        }

        internal Energy(double valueInBaseUnits)
            : base(valueInBaseUnits, EnergyUnit.BaseUnit) { }

        public int CompareTo(Energy other) {
            return base.CompareTo(other);
        }

        public bool Equals(Energy other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Energy)) {
                return false;
            }
            return Equals((Energy)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(EnergyUnit units) {
            return base.In(units);
        }

        public string ToString(EnergyUnit units) {
            return base.ToString(units);
        }

        public string ToString(EnergyUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Energy operator +(Energy energy1, Energy energy2) {
            Guard.NotNull(energy1, "energy1");
            Guard.NotNull(energy2, "energy2");
            return new Energy(energy1.ValueInBaseUnits + energy2.ValueInBaseUnits) {
                Units = energy1.Units
            };
        }

        public static Energy operator /(Energy energy, double scaler) {
            Guard.NotNull(energy, "energy");
            return new Energy(energy.ValueInBaseUnits / scaler) {
                Units = energy.Units
            };
        }

        public static Force operator /(Energy energy, Length length) {
            Guard.NotNull(energy, "energy");
            Guard.NotNull(length, "length");
            double forceValue = energy.In(EnergyUnit.NewtonMeters) / length.In(LengthUnit.Meter);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Length operator /(Energy energy, Force force) {
            Guard.NotNull(energy, "energy");
            Guard.NotNull(force, "force");
            double lengthValue = energy.In(EnergyUnit.NewtonMeters) / force.In(ForceUnit.Newtons);
            return new Length(lengthValue, LengthUnit.Meter);
        }

        public static Momentum operator /(Energy energy, Speed speed) {
            Guard.NotNull(speed, "speed");
            Guard.NotNull(energy, "energy");
            double momentumValue = energy.In(EnergyUnit.NewtonMeters) / speed.In(SpeedUnit.MeterPerSecond);
            return new Momentum(momentumValue, MomentumUnit.KilogramMetersPerSecond);
        }

        public static Power operator /(Energy energy, Time time) {
            Guard.NotNull(energy, "energy");
            Guard.NotNull(time, "time");
            double powerValue = energy.In(EnergyUnit.NewtonMeters) / time.In(TimeUnit.Second);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Speed operator /(Energy energy, Momentum momentum) {
            Guard.NotNull(momentum, "momentum");
            Guard.NotNull(energy, "energy");
            double speedValue = energy.In(EnergyUnit.NewtonMeters) / momentum.In(MomentumUnit.KilogramMetersPerSecond);
            return new Speed(speedValue, SpeedUnit.MeterPerSecond);
        }

        public static Time operator /(Energy energy, Power power) {
            Guard.NotNull(energy, "energy");
            Guard.NotNull(power, "power");
            double timeValue = energy.In(EnergyUnit.Joules) / power.In(PowerUnit.Watts);
            return new Time(timeValue, TimeUnit.Second);
        }

        public static double operator /(Energy numerator, Energy denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Energy left, Energy right) {
            return Equals(left, right);
        }

        public static bool operator >(Energy left, Energy right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Energy left, Energy right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Energy left, Energy right) {
            return !Equals(left, right);
        }

        public static bool operator <(Energy left, Energy right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Energy left, Energy right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Energy operator *(Energy energy, double scaler) {
            Guard.NotNull(energy, "energy");
            return new Energy(energy.ValueInBaseUnits * scaler) {
                Units = energy.Units
            };
        }

        public static Energy operator *(double scaler, Energy energy) {
            Guard.NotNull(energy, "energy");
            return new Energy(energy.ValueInBaseUnits * scaler) {
                Units = energy.Units
            };
        }

        public static Energy operator -(Energy energy1, Energy energy2) {
            Guard.NotNull(energy1, "energy1");
            Guard.NotNull(energy2, "energy2");
            return new Energy(energy1.ValueInBaseUnits - energy2.ValueInBaseUnits) {
                Units = energy1.Units
            };
        }
    }
}