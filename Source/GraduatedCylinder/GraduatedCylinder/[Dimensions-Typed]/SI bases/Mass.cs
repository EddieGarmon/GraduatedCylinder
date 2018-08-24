using System;

namespace GraduatedCylinder
{
    public class Mass : Dimension,
                        IDimension<MassUnit>,
                        IEquatable<Mass>,
                        IComparable<Mass>
    {
        public Mass(double value, MassUnit units)
            : base(value, units) { }

        public Mass(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.Mass);
        }

        internal Mass(double valueInBaseUnits)
            : base(valueInBaseUnits, MassUnit.BaseUnit) { }

        public int CompareTo(Mass other) {
            return base.CompareTo(other);
        }

        public bool Equals(Mass other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            return (obj is Mass mass) && Equals(mass);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(MassUnit units) {
            return base.In(units);
        }

        public string ToString(MassUnit units) {
            return base.ToString(units);
        }

        public string ToString(MassUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static Mass Zero => new Mass(0);

        public static Mass Parse(string input) {
            return (Mass)Factory.Parse(input, DimensionType.Mass);
        }

        public static Mass operator +(Mass left, Mass right) {
            Guard.NotNull(left, nameof(left));
            Guard.NotNull(right, nameof(right));
            return new Mass(left.ValueInBaseUnits + right.ValueInBaseUnits) {
                Units = left.Units
            };
        }

        public static Mass operator /(Mass mass, double scaler) {
            Guard.NotNull(mass, nameof(mass));
            return new Mass(mass.ValueInBaseUnits / scaler) {
                Units = mass.Units
            };
        }

        public static MassDensity operator /(Mass mass, Volume volume) {
            Guard.NotNull(volume, nameof(volume));
            Guard.NotNull(mass, nameof(mass));
            double densityValue = mass.In(MassUnit.Kilogram) / volume.In(VolumeUnit.CubicMeters);
            return new MassDensity(densityValue, MassDensityUnit.KilogramsPerCubicMeter);
        }

        public static MassFlowRate operator /(Mass mass, Time time) {
            Guard.NotNull(time, nameof(time));
            Guard.NotNull(mass, nameof(mass));
            double massFlowRateValue = mass.In(MassUnit.Kilogram) / time.In(TimeUnit.Second);
            return new MassFlowRate(massFlowRateValue, MassFlowRateUnit.KilogramsPerSecond);
        }

        public static Time operator /(Mass mass, MassFlowRate massFlowRate) {
            Guard.NotNull(mass, nameof(mass));
            Guard.NotNull(massFlowRate, nameof(massFlowRate));
            double timeValue = mass.In(MassUnit.Kilogram) / massFlowRate.In(MassFlowRateUnit.KilogramsPerSecond);
            return new Time(timeValue, TimeUnit.Second);
        }

        public static Volume operator /(Mass mass, MassDensity density) {
            Guard.NotNull(mass, nameof(mass));
            Guard.NotNull(density, nameof(density));
            double volumeValue = mass.In(MassUnit.Kilogram) / density.In(MassDensityUnit.KilogramsPerCubicMeter);
            return new Volume(volumeValue, VolumeUnit.CubicMeters);
        }

        public static double operator /(Mass numerator, Mass denominator) {
            Guard.NotNull(numerator, nameof(numerator));
            Guard.NotNull(denominator, nameof(denominator));
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(Mass left, Mass right) {
            return Equals(left, right);
        }

        public static bool operator >(Mass left, Mass right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(Mass left, Mass right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(Mass left, Mass right) {
            return !Equals(left, right);
        }

        public static bool operator <(Mass left, Mass right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Mass left, Mass right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static Mass operator *(Mass mass, double scaler) {
            Guard.NotNull(mass, nameof(mass));
            return new Mass(mass.ValueInBaseUnits * scaler) {
                Units = mass.Units
            };
        }

        public static Mass operator *(double scaler, Mass mass) {
            Guard.NotNull(mass, nameof(mass));
            return new Mass(mass.ValueInBaseUnits * scaler) {
                Units = mass.Units
            };
        }

        public static Force operator *(Mass mass, Acceleration acceleration) {
            Guard.NotNull(acceleration, nameof(acceleration));
            Guard.NotNull(mass, nameof(mass));
            double forceValue = mass.In(MassUnit.Kilogram) * acceleration.In(AccelerationUnit.MeterPerSecondSquared);
            return new Force(forceValue, ForceUnit.Newtons);
        }

        public static Momentum operator *(Mass mass, Speed speed) {
            Guard.NotNull(speed, nameof(speed));
            Guard.NotNull(mass, nameof(mass));
            double momentumValue = mass.In(MassUnit.Kilogram) * speed.In(SpeedUnit.MeterPerSecond);
            return new Momentum(momentumValue, MomentumUnit.KilogramMetersPerSecond);
        }

        public static Mass operator -(Mass mass1, Mass mass2) {
            Guard.NotNull(mass1, nameof(mass1));
            Guard.NotNull(mass2, nameof(mass2));
            return new Mass(mass1.ValueInBaseUnits - mass2.ValueInBaseUnits) {
                Units = mass1.Units
            };
        }

        public static Mass operator -(Mass source) {
            Guard.NotNull(source, nameof(source));
            return new Mass(-source.ValueInBaseUnits) {
                Units = source.Units
            };
        }
    }
}