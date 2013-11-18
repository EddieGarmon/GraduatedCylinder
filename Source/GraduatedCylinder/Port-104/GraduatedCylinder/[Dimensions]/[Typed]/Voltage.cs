using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Represents the Voltage dimension.
    /// </summary>
    public class Voltage : Dimension, IEquatable<Voltage>, IComparable<Voltage>
    {
        public Voltage(double value, VoltageUnit units)
            : base(value, units) { }

        public Voltage(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Voltage);
        }

        internal Voltage(double valueInBaseUnits)
            : base(valueInBaseUnits, VoltageUnit.BaseUnit) { }

        public int CompareTo(Voltage other) {
            return base.CompareTo(other);
        }

        public bool Equals(Voltage other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Voltage)) {
                return false;
            }
            return Equals((Voltage)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public string ToString(VoltageUnit units) {
            return base.ToString(units);
        }

        public string ToString(VoltageUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static readonly Voltage Zero = new Voltage(0, VoltageUnit.Volts);

        public static Voltage operator +(Voltage voltage1, Voltage voltage2) {
            Guard.NotNull(voltage1, "voltage1");
            Guard.NotNull(voltage2, "voltage2");
            return new Voltage(voltage1.ValueInBaseUnits + voltage2.ValueInBaseUnits) { Units = voltage1.Units };
        }

        public static Voltage operator /(Voltage voltage, double scaler) {
            Guard.NotNull(voltage, "voltage");
            return new Voltage(voltage.ValueInBaseUnits / scaler) { Units = voltage.Units };
        }

        public static Current operator /(Voltage voltage, Resistance resistance) {
            Guard.NotNull(voltage, "voltage");
            Guard.NotNull(resistance, "resistance");
            double electricCurrentValue = voltage.In(VoltageUnit.Volts) / resistance.In(ResistanceUnit.Ohms);
            return new Current(electricCurrentValue, CurrentUnit.Amperes);
        }

        public static Resistance operator /(Voltage voltage, Current current) {
            Guard.NotNull(voltage, "voltage");
            Guard.NotNull(current, "current");
            double electricResistance = voltage.In(VoltageUnit.Volts) / current.In(CurrentUnit.Amperes);
            return new Resistance(electricResistance, ResistanceUnit.Ohms);
        }

        public static double operator /(Voltage numerator, Voltage denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Voltage left, Voltage right) {
            return Equals(left, right);
        }

        public static bool operator >(Voltage left, Voltage right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Voltage left, Voltage right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Voltage left, Voltage right) {
            return !Equals(left, right);
        }

        public static bool operator <(Voltage left, Voltage right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Voltage left, Voltage right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Voltage operator *(Voltage voltage, double scaler) {
            Guard.NotNull(voltage, "voltage");
            return new Voltage(voltage.ValueInBaseUnits * scaler) { Units = voltage.Units };
        }

        public static Voltage operator *(double scaler, Voltage voltage) {
            Guard.NotNull(voltage, "voltage");
            return new Voltage(voltage.ValueInBaseUnits * scaler) { Units = voltage.Units };
        }

        public static Power operator *(Voltage voltage, Current current) {
            Guard.NotNull(current, "current");
            Guard.NotNull(voltage, "voltage");
            double powerValue = voltage.In(VoltageUnit.Volts) * current.In(CurrentUnit.Amperes);
            return new Power(powerValue, PowerUnit.Watts);
        }

        public static Voltage operator -(Voltage voltage1, Voltage voltage2) {
            Guard.NotNull(voltage1, "voltage1");
            Guard.NotNull(voltage2, "voltage2");
            return new Voltage(voltage1.ValueInBaseUnits - voltage2.ValueInBaseUnits) { Units = voltage1.Units };
        }
    }
}