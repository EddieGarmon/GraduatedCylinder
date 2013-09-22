using System;

namespace GraduatedCylinder
{
    /// <summary>
    ///     Represents the Dimension of Power for both Mechanical and Electrical Dimensions
    /// </summary>
    public class Power : Dimension, IEquatable<Power>, IComparable<Power>
    {
        public Power(double value, PowerUnit units)
            : base(value, units) {}

        public Power(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Power);
        }

        internal Power(double valueInBaseUnits)
            : base(valueInBaseUnits, PowerUnit.BaseUnit) {}

        public int CompareTo(Power other) {
            return base.CompareTo(other);
        }

        public bool Equals(Power other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(Power)) {
                return false;
            }
            return Equals((Power)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public static Power operator +(Power left, Power right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new Power(left.ValueInBaseUnits + right.ValueInBaseUnits) {Units = left.Units};
        }

        public static Power operator /(Power power, double scaler) {
            Guard.NotNull(power, "power");
            return new Power(power.ValueInBaseUnits / scaler) {Units = power.Units};
        }

        public static Acceleration operator /(Power power, Momentum momentum) {
            Guard.NotNull(power, "power");
            Guard.NotNull(momentum, "momentum");
            double accelerationValue = power.In(PowerUnit.Watts) / momentum.In(MomentumUnit.KilogramMetersPerSecond);
            return new Acceleration(accelerationValue, AccelerationUnit.MetersPerSecondSquared);
        }

        public static Force operator /(Power power, Speed speed) {
            Guard.NotNull(power, "power");
            Guard.NotNull(speed, "speed");
            double forceValue = power.In(PowerUnit.Watts) / speed.In(SpeedUnit.MetersPerSecond);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Momentum operator /(Power power, Acceleration acceleration) {
            Guard.NotNull(power, "power");
            Guard.NotNull(acceleration, "acceleration");
            double momentumValue = power.In(PowerUnit.Watts) / acceleration.In(AccelerationUnit.MetersPerSecondSquared);
            return new Momentum(momentumValue, MomentumUnit.KilogramMetersPerSecond);
        }

        public static AngularVelocity operator /(Power power, Torque torque) {
            Guard.NotNull(power, "power");
            Guard.NotNull(torque, "torque");
            double revolutionsValue = power.In(PowerUnit.Watts) / torque.In(TorqueUnit.NewtonMeters);
            return new AngularVelocity(revolutionsValue, AngularVelocityUnit.RevolutionsPerMinute);
        }

        public static Speed operator /(Power power, Force force) {
            Guard.NotNull(power, "power");
            Guard.NotNull(force, "force");
            double speedValue = power.In(PowerUnit.Watts) / force.In(ForceUnit.Newtons);
            return new Speed(speedValue, SpeedUnit.MetersPerSecond);
        }

        public static Torque operator /(Power power, AngularVelocity angularVelocity) {
            Guard.NotNull(power, "power");
            Guard.NotNull(angularVelocity, "angularVelocity");
            double torqueValue = power.In(PowerUnit.Watts) / angularVelocity.In(AngularVelocityUnit.RevolutionsPerSecond);
            return new Torque(torqueValue, TorqueUnit.NewtonMeters);
        }

        public static Current operator /(Power power, Voltage voltage) {
            Guard.NotNull(voltage, "voltage");
            Guard.NotNull(power, "power");
            double electricCurrentValue = power.In(PowerUnit.Watts) / voltage.In(VoltageUnit.Volts);
            return new Current(electricCurrentValue, CurrentUnit.Amperes);
        }

        public static Voltage operator /(Power power, Current current) {
            Guard.NotNull(power, "power");
            Guard.NotNull(current, "current");
            double voltageValue = power.In(PowerUnit.Watts) / current.In(CurrentUnit.Amperes);
            return new Voltage(voltageValue, VoltageUnit.Volts);
        }

        public static double operator /(Power numerator, Power denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Power left, Power right) {
            return Equals(left, right);
        }

        public static bool operator >(Power left, Power right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Power left, Power right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Power left, Power right) {
            return !Equals(left, right);
        }

        public static bool operator <(Power left, Power right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Power left, Power right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Power operator *(Power power, double scaler) {
            Guard.NotNull(power, "power");
            return new Power(power.ValueInBaseUnits * scaler) {Units = power.Units};
        }

        public static Power operator *(double scaler, Power power) {
            Guard.NotNull(power, "power");
            return new Power(power.ValueInBaseUnits * scaler) {Units = power.Units};
        }

        public static Energy operator *(Power power, Time time) {
            Guard.NotNull(power, "power");
            Guard.NotNull(time, "time");
            double energyValue = power.In(PowerUnit.Watts) * time.In(TimeUnit.Seconds);
            return new Energy(energyValue, EnergyUnit.NewtonMeters);
        }

        public static Power operator -(Power power1, Power power2) {
            Guard.NotNull(power1, "power1");
            Guard.NotNull(power2, "power2");
            return new Power(power1.ValueInBaseUnits - power2.ValueInBaseUnits) {Units = power1.Units};
        }
    }
}