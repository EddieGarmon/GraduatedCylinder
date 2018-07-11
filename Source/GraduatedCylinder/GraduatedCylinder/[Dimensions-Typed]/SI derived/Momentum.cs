using System;

namespace GraduatedCylinder
{
    public class Momentum : Dimension,
                            IDimension<MomentumUnit>,
                            IEquatable<Momentum>,
                            IComparable<Momentum>
    {
        public Momentum(double value, MomentumUnit units)
            : base(value, units) { }

        public Momentum(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Momentum);
        }

        internal Momentum(double valueInBaseUnits)
            : base(valueInBaseUnits, MomentumUnit.BaseUnit) { }

        public int CompareTo(Momentum other) {
            return base.CompareTo(other);
        }

        public bool Equals(Momentum other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is Momentum momentum) && Equals(momentum);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(MomentumUnit units) {
            return base.In(units);
        }

        public string ToString(MomentumUnit units) {
            return base.ToString(units);
        }

        public string ToString(MomentumUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Momentum Zero => new Momentum(0);

        public static Momentum Parse(string input) {
            return (Momentum)Factory.Parse(input, DimensionType.Momentum);
        }

        public static Momentum operator +(Momentum momentum1, Momentum momentum2) {
            Guard.NotNull(momentum1, nameof(momentum1));
            Guard.NotNull(momentum2, nameof(momentum2));
            return new Momentum(momentum1.ValueInBaseUnits + momentum2.ValueInBaseUnits) {
                Units = momentum1.Units
            };
        }

        public static Momentum operator /(Momentum momentum, double scaler) {
            Guard.NotNull(momentum, nameof(momentum));
            return new Momentum(momentum.ValueInBaseUnits / scaler) {
                Units = momentum.Units
            };
        }

        public static Force operator /(Momentum momentum, Time time) {
            Guard.NotNull(momentum, nameof(momentum));
            Guard.NotNull(time, nameof(time));
            double forceValue = momentum.In(MomentumUnit.KilogramMetersPerSecond) / time.In(TimeUnit.Second);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Mass operator /(Momentum momentum, Speed speed) {
            Guard.NotNull(momentum, nameof(momentum));
            Guard.NotNull(speed, nameof(speed));
            double massValue = momentum.In(MomentumUnit.KilogramMetersPerSecond) / speed.In(SpeedUnit.MeterPerSecond);
            return new Mass(massValue, MassUnit.Kilogram);
        }

        public static Speed operator /(Momentum momentum, Mass mass) {
            Guard.NotNull(momentum, nameof(momentum));
            Guard.NotNull(mass, nameof(mass));
            double speedValue = momentum.In(MomentumUnit.KilogramMetersPerSecond) / mass.In(MassUnit.Kilogram);
            return new Speed(speedValue, SpeedUnit.MeterPerSecond);
        }

        public static Time operator /(Momentum momentum, Force force) {
            Guard.NotNull(momentum, nameof(momentum));
            Guard.NotNull(force, nameof(force));
            double timeValue = momentum.In(MomentumUnit.KilogramMetersPerSecond) / force.In(ForceUnit.Newtons);
            return new Time(timeValue, TimeUnit.Second);
        }

        public static double operator /(Momentum numerator, Momentum denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Momentum left, Momentum right) {
            return Equals(left, right);
        }

        public static bool operator >(Momentum left, Momentum right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Momentum left, Momentum right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Momentum left, Momentum right) {
            return !Equals(left, right);
        }

        public static bool operator <(Momentum left, Momentum right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Momentum left, Momentum right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Momentum operator *(Momentum momentum, double scaler) {
            Guard.NotNull(momentum, nameof(momentum));
            return new Momentum(momentum.ValueInBaseUnits * scaler) {
                Units = momentum.Units
            };
        }

        public static Momentum operator *(double scaler, Momentum momentum) {
            Guard.NotNull(momentum, nameof(momentum));
            return new Momentum(momentum.ValueInBaseUnits * scaler) {
                Units = momentum.Units
            };
        }

        public static Energy operator *(Momentum momentum, Speed speed) {
            Guard.NotNull(speed, nameof(speed));
            Guard.NotNull(momentum, nameof(momentum));
            double energyValue = momentum.In(MomentumUnit.KilogramMetersPerSecond) * speed.In(SpeedUnit.MeterPerSecond);
            return new Energy(energyValue, EnergyUnit.NewtonMeters);
        }

        public static Power operator *(Momentum momentum, Acceleration acceleration) {
            Guard.NotNull(momentum, nameof(momentum));
            Guard.NotNull(acceleration, nameof(acceleration));
            double powerValue = momentum.In(MomentumUnit.KilogramMetersPerSecond)
                                * acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Momentum operator -(Momentum momentum1, Momentum momentum2) {
            Guard.NotNull(momentum1, nameof(momentum1));
            Guard.NotNull(momentum2, nameof(momentum2));
            return new Momentum(momentum1.ValueInBaseUnits - momentum2.ValueInBaseUnits) {
                Units = momentum1.Units
            };
        }
    }
}