using System;

namespace GraduatedCylinder
{
    public class VolumetricFlowRate : Dimension,
                                      IEquatable<VolumetricFlowRate>,
                                      IComparable<VolumetricFlowRate>
    {
        public VolumetricFlowRate(double value, VolumetricFlowRateUnit units)
            : base(value, units) { }

        public VolumetricFlowRate(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {
            unitOfMeasure.DimensionType.ShouldBe(DimensionType.VolumetricFlowRate);
        }

        internal VolumetricFlowRate(double valueInBaseUnits)
            : base(valueInBaseUnits, VolumetricFlowRateUnit.BaseUnit) { }

        public int CompareTo(VolumetricFlowRate other) {
            return base.CompareTo(other);
        }

        public bool Equals(VolumetricFlowRate other) {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != typeof(VolumetricFlowRate)) {
                return false;
            }
            return Equals((VolumetricFlowRate)obj);
        }

        public override int GetHashCode() {
            return ValueInBaseUnits.GetHashCode();
        }

        public double In(VolumetricFlowRateUnit units) {
            return base.In(units);
        }

        public string ToString(VolumetricFlowRateUnit units) {
            return base.ToString(units);
        }

        public string ToString(VolumetricFlowRateUnit units, int precision) {
            return base.ToString(units, precision);
        }

        public static VolumetricFlowRate operator +(VolumetricFlowRate volumetricFlowRate1,
                                                    VolumetricFlowRate volumetricFlowRate2) {
            Guard.NotNull(volumetricFlowRate1, "volumetricFlowRate1");
            Guard.NotNull(volumetricFlowRate2, "volumetricFlowRate2");
            return new VolumetricFlowRate(volumetricFlowRate1.ValueInBaseUnits + volumetricFlowRate2.ValueInBaseUnits) {
                Units = volumetricFlowRate1.Units
            };
        }

        public static VolumetricFlowRate operator /(VolumetricFlowRate volumetricFlowRate, double scaler) {
            Guard.NotNull(volumetricFlowRate, "volumetricFlowRate");
            return new VolumetricFlowRate(volumetricFlowRate.ValueInBaseUnits / scaler) {
                Units = volumetricFlowRate.Units
            };
        }

        public static double operator /(VolumetricFlowRate numerator, VolumetricFlowRate denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static bool operator ==(VolumetricFlowRate left, VolumetricFlowRate right) {
            return Equals(left, right);
        }

        public static bool operator >(VolumetricFlowRate left, VolumetricFlowRate right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
        }

        public static bool operator >=(VolumetricFlowRate left, VolumetricFlowRate right) {
            return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
        }

        public static bool operator !=(VolumetricFlowRate left, VolumetricFlowRate right) {
            return !Equals(left, right);
        }

        public static bool operator <(VolumetricFlowRate left, VolumetricFlowRate right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(VolumetricFlowRate left, VolumetricFlowRate right) {
            return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
        }

        public static VolumetricFlowRate operator *(VolumetricFlowRate volumetricFlowRate, double scaler) {
            Guard.NotNull(volumetricFlowRate, "volumetricFlowRate");
            return new VolumetricFlowRate(volumetricFlowRate.ValueInBaseUnits * scaler) {
                Units = volumetricFlowRate.Units
            };
        }

        public static VolumetricFlowRate operator *(double scaler, VolumetricFlowRate volumetricFlowRate) {
            Guard.NotNull(volumetricFlowRate, "volumetricFlowRate");
            return new VolumetricFlowRate(volumetricFlowRate.ValueInBaseUnits * scaler) {
                Units = volumetricFlowRate.Units
            };
        }

        public static Volume operator *(VolumetricFlowRate volumetricFlowRate, Time time) {
            Guard.NotNull(volumetricFlowRate, "volumetricFlowRate");
            Guard.NotNull(time, "time");
            double volumeValue = volumetricFlowRate.In(VolumetricFlowRateUnit.CubicMetersPerSecond)
                                 * time.In(TimeUnit.Second);
            return new Volume(volumeValue, VolumeUnit.CubicMeters);
        }

        public static VolumetricFlowRate operator -(VolumetricFlowRate volumetricFlowRate1,
                                                    VolumetricFlowRate volumetricFlowRate2) {
            Guard.NotNull(volumetricFlowRate1, "volumetricFlowRate1");
            Guard.NotNull(volumetricFlowRate2, "volumetricFlowRate2");
            return new VolumetricFlowRate(volumetricFlowRate1.ValueInBaseUnits - volumetricFlowRate2.ValueInBaseUnits) {
                Units = volumetricFlowRate1.Units
            };
        }
    }
}