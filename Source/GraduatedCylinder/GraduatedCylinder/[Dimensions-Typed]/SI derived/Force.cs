using System;

namespace GraduatedCylinder
{
    public class Force : Dimension,
                         IDimension<ForceUnit>,
                         IEquatable<Force>,
                         IComparable<Force>
    {
        public Force(double value, ForceUnit units)
            : base(value, units) { }

        public Force(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Force);
        }

        internal Force(double valueInBaseUnits)
            : base(valueInBaseUnits, ForceUnit.BaseUnit) { }

        public int CompareTo(Force other) {
            return base.CompareTo(other);
        }

        public bool Equals(Force other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is Force force) && Equals(force);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(ForceUnit units) {
            return base.In(units);
        }

        public string ToString(ForceUnit units) {
            return base.ToString(units);
        }

        public string ToString(ForceUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Force Zero => new Force(0);

        public static Force Parse(string input) {
            return (Force)Factory.Parse(input, DimensionType.Force);
        }

        public static Force operator +(Force force1, Force force2) {
            Guard.NotNull(force1, nameof(force1));
            Guard.NotNull(force2, nameof(force2));
            return new Force(force1.ValueInBaseUnits + force2.ValueInBaseUnits) {
                Units = force1.Units
            };
        }

        public static Force operator /(Force force, double scaler) {
            Guard.NotNull(force, nameof(force));
            return new Force(force.ValueInBaseUnits / scaler) {
                Units = force.Units
            };
        }

        public static Acceleration operator /(Force force, Mass mass) {
            Guard.NotNull(force, nameof(force));
            Guard.NotNull(mass, nameof(mass));
            double accelerationValue = force.In(ForceUnit.Newtons) / mass.In(MassUnit.Kilogram);
            return new Acceleration(accelerationValue, AccelerationUnit.MeterPerSecondSquared);
        }

        public static Area operator /(Force force, Pressure pressure) {
            Guard.NotNull(force, nameof(force));
            Guard.NotNull(pressure, nameof(pressure));
            double areaValue = force.In(ForceUnit.Newtons) / pressure.In(PressureUnit.NewtonsPerSquareMeter);
            return new Area(areaValue, AreaUnit.MeterSquared);
        }

        public static Mass operator /(Force force, Acceleration acceleration) {
            Guard.NotNull(force, nameof(force));
            Guard.NotNull(acceleration, nameof(acceleration));
            double massValue = force.In(ForceUnit.Newtons) / acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            return new Mass(massValue, MassUnit.Kilogram);
        }

        public static Pressure operator /(Force force, Area area) {
            Guard.NotNull(force, nameof(force));
            Guard.NotNull(area, nameof(area));
            double pressureValue = force.In(ForceUnit.Newtons) / area.In(AreaUnit.MeterSquared);
            return new Pressure(pressureValue, PressureUnit.NewtonsPerSquareMeter);
        }

        public static double operator /(Force numerator, Force denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Force left, Force right) {
            return Equals(left, right);
        }

        public static bool operator >(Force left, Force right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Force left, Force right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Force left, Force right) {
            return !Equals(left, right);
        }

        public static bool operator <(Force left, Force right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Force left, Force right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Force operator *(Force force, double scaler) {
            Guard.NotNull(force, nameof(force));
            return new Force(force.ValueInBaseUnits * scaler) {
                Units = force.Units
            };
        }

        public static Force operator *(double scaler, Force force) {
            Guard.NotNull(force, nameof(force));
            return new Force(force.ValueInBaseUnits * scaler) {
                Units = force.Units
            };
        }

        public static Energy operator *(Force force, Length length) {
            Guard.NotNull(length, nameof(length));
            Guard.NotNull(force, nameof(force));
            double energyValue = force.In(ForceUnit.Newtons) * length.In(LengthUnit.Meter);
            return new Energy(energyValue, EnergyUnit.NewtonMeters);
        }

        public static Momentum operator *(Force force, Time time) {
            Guard.NotNull(force, nameof(force));
            Guard.NotNull(time, nameof(time));
            double momentumVlaue = force.In(ForceUnit.Newtons) * time.In(TimeUnit.Second);
            return new Momentum(momentumVlaue, MomentumUnit.KilogramMetersPerSecond);
        }

        public static Power operator *(Force force, Speed speed) {
            Guard.NotNull(force, nameof(force));
            Guard.NotNull(speed, nameof(speed));
            double powerValue = force.In(ForceUnit.Newtons) * speed.In(SpeedUnit.MeterPerSecond);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Force operator -(Force force1, Force force2) {
            Guard.NotNull(force1, nameof(force1));
            Guard.NotNull(force2, nameof(force2));
            return new Force(force1.ValueInBaseUnits - force2.ValueInBaseUnits) {
                Units = force1.Units
            };
        }
    }
}