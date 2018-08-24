using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents speed, which is the first derivative of position with
    ///     respect to time.
    /// </summary>
    public class Speed : Dimension,
                         IDimension<SpeedUnit>,
                         IEquatable<Speed>,
                         IComparable<Speed>
    {
        public Speed(double value, SpeedUnit units)
            : base(value, units) { }

        public Speed(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Speed);
        }

        internal Speed(double valueInBaseUnits)
            : base(valueInBaseUnits, SpeedUnit.BaseUnit) { }

        public int CompareTo(Speed other) {
            return base.CompareTo(other);
        }

        public bool Equals(Speed other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is Speed speed) && Equals(speed);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(SpeedUnit units) {
            return base.In(units);
        }

        public string ToString(SpeedUnit units) {
            return base.ToString(units);
        }

        public string ToString(SpeedUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Speed Zero => new Speed(0);

        public static Speed Parse(string input) {
            return (Speed)Factory.Parse(input, DimensionType.Speed);
        }

        public static Speed operator +(Speed speed1, Speed speed2) {
            Guard.NotNull(speed1, nameof(speed1));
            Guard.NotNull(speed2, nameof(speed2));
            return new Speed(speed1.ValueInBaseUnits + speed2.ValueInBaseUnits) {
                Units = speed1.Units
            };
        }

        public static Speed operator /(Speed speed, double scaler) {
            Guard.NotNull(speed, nameof(speed));
            return new Speed(speed.ValueInBaseUnits / scaler) {
                Units = speed.Units
            };
        }

        public static Acceleration operator /(Speed speed, Time time) {
            Guard.NotNull(speed, nameof(speed));
            Guard.NotNull(time, nameof(time));
            double accelerationValue = speed.In(SpeedUnit.MeterPerSecond) / time.In(TimeUnit.Second);
            return new Acceleration(accelerationValue, AccelerationUnit.MeterPerSecondSquared);
        }

        public static Time operator /(Speed speed, Acceleration acceleration) {
            Guard.NotNull(speed, nameof(speed));
            Guard.NotNull(acceleration, nameof(acceleration));
            double timeValue = speed.In(SpeedUnit.MeterPerSecond)
                               / acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            return new Time(timeValue, TimeUnit.Second);
        }

        public static double operator /(Speed numerator, Speed denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Speed left, Speed right) {
            return Equals(left, right);
        }

        public static bool operator >(Speed left, Speed right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Speed left, Speed right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Speed left, Speed right) {
            return !Equals(left, right);
        }

        public static bool operator <(Speed left, Speed right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Speed left, Speed right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Speed operator *(Speed speed, double scaler) {
            Guard.NotNull(speed, nameof(speed));
            return new Speed(speed.ValueInBaseUnits * scaler) {
                Units = speed.Units
            };
        }

        public static Speed operator *(double scaler, Speed speed) {
            Guard.NotNull(speed, nameof(speed));
            return new Speed(speed.ValueInBaseUnits * scaler) {
                Units = speed.Units
            };
        }

        public static SpeedSquared operator *(Speed left, Speed right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            double value = left.In(SpeedUnit.MeterPerSecond) * right.In(SpeedUnit.MeterPerSecond);
            return new SpeedSquared(value, SpeedSquaredUnit.MetersSquaredPerSecondSquared);
        }

        public static Energy operator *(Speed speed, Momentum momentum) {
            Guard.NotNull(speed, nameof(speed));
            Guard.NotNull(momentum, nameof(momentum));
            double energyValue = speed.In(SpeedUnit.MeterPerSecond) * momentum.In(MomentumUnit.KilogramMetersPerSecond);
            return new Energy(energyValue, EnergyUnit.NewtonMeters);
        }

        public static Length operator *(Speed speed, Time time) {
            Guard.NotNull(speed, nameof(speed));
            Guard.NotNull(time, nameof(time));
            double lengthValue = speed.In(SpeedUnit.MeterPerSecond) * time.In(TimeUnit.Second);
            return new Length(lengthValue, LengthUnit.Meter);
        }

        public static Momentum operator *(Speed speed, Mass mass) {
            Guard.NotNull(speed, nameof(speed));
            Guard.NotNull(mass, nameof(mass));
            double momentumValue = speed.In(SpeedUnit.MeterPerSecond) * mass.In(MassUnit.Kilogram);
            return new Momentum(momentumValue, MomentumUnit.KilogramMetersPerSecond);
        }

        public static Power operator *(Speed speed, Force force) {
            Guard.NotNull(force, nameof(force));
            Guard.NotNull(speed, nameof(speed));
            double powerValue = speed.In(SpeedUnit.MeterPerSecond) * force.In(ForceUnit.Newtons);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Speed operator -(Speed speed1, Speed speed2) {
            Guard.NotNull(speed1, nameof(speed1));
            Guard.NotNull(speed2, nameof(speed2));
            return new Speed(speed1.ValueInBaseUnits - speed2.ValueInBaseUnits) {
                Units = speed1.Units
            };
        }

        public static Speed operator -(Speed source) {
            Guard.NotNull(source, nameof(source));
            return new Speed(-source.ValueInBaseUnits) {
                Units = source.Units
            };
        }
    }
}