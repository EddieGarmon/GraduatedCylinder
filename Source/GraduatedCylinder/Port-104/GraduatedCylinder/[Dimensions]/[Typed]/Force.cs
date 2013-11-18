using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     This dimension represents force.
    /// </summary>
    public class Force : Dimension, IEquatable<Force>, IComparable<Force>
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
            if (obj.GetType() != typeof(Force)) {
                return false;
            }
            return Equals((Force)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public string ToString(ForceUnit units) {
            return base.ToString(units);
        }

        public string ToString(ForceUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Force operator +(Force force1, Force force2) {
            Guard.NotNull(force1, "force1");
            Guard.NotNull(force2, "force2");
            return new Force(force1.ValueInBaseUnits + force2.ValueInBaseUnits) { Units = force1.Units };
        }

        public static Force operator /(Force force, double scaler) {
            Guard.NotNull(force, "force");
            return new Force(force.ValueInBaseUnits / scaler) { Units = force.Units };
        }

        public static Acceleration operator /(Force force, Mass mass) {
            Guard.NotNull(force, "force");
            Guard.NotNull(mass, "mass");
            double accelerationValue = force.In(ForceUnit.Newtons) / mass.In(MassUnit.Kilograms);
            return new Acceleration(accelerationValue, AccelerationUnit.MetersPerSecondSquared);
        }

        public static Area operator /(Force force, Pressure pressure) {
            Guard.NotNull(force, "force");
            Guard.NotNull(pressure, "pressure");
            double areaValue = force.In(ForceUnit.Newtons) / pressure.In(PressureUnit.NewtonsPerSquareMeter);
            return new Area(areaValue, AreaUnit.SquareMeters);
        }

        public static Mass operator /(Force force, Acceleration acceleration) {
            Guard.NotNull(force, "force");
            Guard.NotNull(acceleration, "acceleration");
            double massValue = force.In(ForceUnit.Newtons) / acceleration.In(AccelerationUnit.MetersPerSecondSquared);
            return new Mass(massValue, MassUnit.Kilograms);
        }

        public static Pressure operator /(Force force, Area area) {
            Guard.NotNull(force, "force");
            Guard.NotNull(area, "area");
            double pressureValue = force.In(ForceUnit.Newtons) / area.In(AreaUnit.SquareMeters);
            return new Pressure(pressureValue, PressureUnit.NewtonsPerSquareMeter);
        }

        public static double operator /(Force numerator, Force denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
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
            Guard.NotNull(force, "force");
            return new Force(force.ValueInBaseUnits * scaler) { Units = force.Units };
        }

        public static Force operator *(double scaler, Force force) {
            Guard.NotNull(force, "force");
            return new Force(force.ValueInBaseUnits * scaler) { Units = force.Units };
        }

        public static Energy operator *(Force force, Length length) {
            Guard.NotNull(length, "length");
            Guard.NotNull(force, "force");
            double energyValue = force.In(ForceUnit.Newtons) * length.In(LengthUnit.Meters);
            return new Energy(energyValue, EnergyUnit.NewtonMeters);
        }

        public static Momentum operator *(Force force, Time time) {
            Guard.NotNull(force, "force");
            Guard.NotNull(time, "time");
            double momentumVlaue = force.In(ForceUnit.Newtons) * time.In(TimeUnit.Seconds);
            return new Momentum(momentumVlaue, MomentumUnit.KilogramMetersPerSecond);
        }

        public static Power operator *(Force force, Speed speed) {
            Guard.NotNull(force, "force");
            Guard.NotNull(speed, "speed");
            double powerValue = force.In(ForceUnit.Newtons) * speed.In(SpeedUnit.MetersPerSecond);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Force operator -(Force force1, Force force2) {
            Guard.NotNull(force1, "force1");
            Guard.NotNull(force2, "force2");
            return new Force(force1.ValueInBaseUnits - force2.ValueInBaseUnits) { Units = force1.Units };
        }
    }
}