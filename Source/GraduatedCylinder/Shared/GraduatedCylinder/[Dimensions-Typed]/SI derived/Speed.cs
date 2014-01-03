using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents speed, which is the first derivative of position with
    ///     respect to time.
    /// </summary>
    public class Speed : Dimension,
                         IEquatable<Speed>,
                         IComparable<Speed>
    {
        public static readonly Speed Zero = new Speed(0, SpeedUnit.MeterPerSecond);

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
            if (obj.GetType() != typeof(Speed)) {
                return false;
            }
            return Equals((Speed)obj);
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

        public static Speed operator +(Speed speed1, Speed speed2) {
            Guard.NotNull(speed1, "speed1");
            Guard.NotNull(speed2, "speed2");
            return new Speed(speed1.ValueInBaseUnits + speed2.ValueInBaseUnits) {
                Units = speed1.Units
            };
        }

        public static Speed operator /(Speed speed, double scaler) {
            Guard.NotNull(speed, "speed");
            return new Speed(speed.ValueInBaseUnits / scaler) {
                Units = speed.Units
            };
        }

        public static Acceleration operator /(Speed speed, Time time) {
            Guard.NotNull(speed, "speed");
            Guard.NotNull(time, "time");
            double accelerationValue = speed.In(SpeedUnit.MeterPerSecond) / time.In(TimeUnit.Second);
            return new Acceleration(accelerationValue, AccelerationUnit.MeterPerSecondSquared);
        }

        public static Time operator /(Speed speed, Acceleration acceleration) {
            Guard.NotNull(speed, "speed");
            Guard.NotNull(acceleration, "acceleration");
            double timeValue = speed.In(SpeedUnit.MeterPerSecond) / acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            return new Time(timeValue, TimeUnit.Second);
        }

        public static double operator /(Speed numerator, Speed denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
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
            Guard.NotNull(speed, "speed");
            return new Speed(speed.ValueInBaseUnits * scaler) {
                Units = speed.Units
            };
        }

        public static Speed operator *(double scaler, Speed speed) {
            Guard.NotNull(speed, "speed");
            return new Speed(speed.ValueInBaseUnits * scaler) {
                Units = speed.Units
            };
        }

        public static SpeedSquared operator *(Speed left, Speed right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            double value = left.In(SpeedUnit.MeterPerSecond) * right.In(SpeedUnit.MeterPerSecond);
            return new SpeedSquared(value, SpeedSquaredUnit.MetersSquaredPerSecondSquared);
        }

        public static Energy operator *(Speed speed, Momentum momentum) {
            Guard.NotNull(speed, "speed");
            Guard.NotNull(momentum, "momentum");
            double energyValue = speed.In(SpeedUnit.MeterPerSecond) * momentum.In(MomentumUnit.KilogramMetersPerSecond);
            return new Energy(energyValue, EnergyUnit.NewtonMeters);
        }

        public static Length operator *(Speed speed, Time time) {
            Guard.NotNull(speed, "speed");
            Guard.NotNull(time, "time");
            double lengthValue = speed.In(SpeedUnit.MeterPerSecond) * time.In(TimeUnit.Second);
            return new Length(lengthValue, LengthUnit.Meter);
        }

        public static Momentum operator *(Speed speed, Mass mass) {
            Guard.NotNull(speed, "speed");
            Guard.NotNull(mass, "mass");
            double momentumValue = speed.In(SpeedUnit.MeterPerSecond) * mass.In(MassUnit.Kilogram);
            return new Momentum(momentumValue, MomentumUnit.KilogramMetersPerSecond);
        }

        public static Power operator *(Speed speed, Force force) {
            Guard.NotNull(force, "force");
            Guard.NotNull(speed, "speed");
            double powerValue = speed.In(SpeedUnit.MeterPerSecond) * force.In(ForceUnit.Newtons);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Speed operator -(Speed speed1, Speed speed2) {
            Guard.NotNull(speed1, "speed1");
            Guard.NotNull(speed2, "speed2");
            return new Speed(speed1.ValueInBaseUnits - speed2.ValueInBaseUnits) {
                Units = speed1.Units
            };
        }
    }
}