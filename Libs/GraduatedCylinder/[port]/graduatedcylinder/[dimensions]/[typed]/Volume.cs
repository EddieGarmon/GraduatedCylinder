using System;

namespace GraduatedCylinder
{
	/// <summary>
	///     represents the Volume Dimension.
	/// </summary>
	public class Volume : Dimension, IEquatable<Volume>, IComparable<Volume>
	{
		public Volume(double value, VolumeUnit units)
			: base(value, units) {}

		public Volume(double value, UnitOfMeasure unitOfMeasure)
			: base(value, unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Volume);
		}

		internal Volume(double valueInBaseUnits)
			: base(valueInBaseUnits, VolumeUnit.BaseUnit) {}

		public int CompareTo(Volume other) {
			return base.CompareTo(other);
		}

		public bool Equals(Volume other) {
			return CompareTo(other) == 0;
		}

		public override bool Equals(object obj) {
			if (obj == null) {
				return false;
			}
			if (ReferenceEquals(this, obj)) {
				return true;
			}
			if (obj.GetType() != typeof(Volume)) {
				return false;
			}
			return Equals((Volume)obj);
		}

		public override int GetHashCode() {
			return ValueInBaseUnits.GetHashCode();
		}

		public static Volume operator +(Volume volume1, Volume volume2) {
			Guard.NotNull(volume1, "volume1");
			Guard.NotNull(volume2, "volume2");
			return new Volume(volume1.ValueInBaseUnits + volume2.ValueInBaseUnits) {Units = volume1.Units};
		}

		public static Volume operator /(Volume volume, double scaler) {
			Guard.NotNull(volume, "volume");
			return new Volume(volume.ValueInBaseUnits / scaler) {Units = volume.Units};
		}

		public static Area operator /(Volume volume, Length length) {
			Guard.NotNull(volume, "volume");
			Guard.NotNull(length, "length");
			double areaValue = volume.In(VolumeUnit.CubicMeters) / length.In(LengthUnit.Meters);
			return new Area(areaValue, AreaUnit.SquareMeters);
		}

		public static Length operator /(Volume volume, Area area) {
			Guard.NotNull(volume, "volume");
			Guard.NotNull(area, "area");
			double lengthValue = volume.In(VolumeUnit.CubicMeters) / area.In(AreaUnit.SquareMeters);
			return new Length(lengthValue, LengthUnit.Meters);
		}

		public static Time operator /(Volume volume, VolumetricFlowRate volumetricFlowRate) {
			Guard.NotNull(volume, "volume");
			Guard.NotNull(volumetricFlowRate, "volumetricFlowRate");
			double timeValue = volume.In(VolumeUnit.Liters) / volumetricFlowRate.In(VolumetricFlowRateUnit.LitersPerSecond);
			return new Time(timeValue, TimeUnit.Seconds);
		}

		public static VolumetricFlowRate operator /(Volume volume, Time time) {
			Guard.NotNull(time, "time");
			Guard.NotNull(volume, "volume");
			double volumetricFlowRateValue = volume.In(VolumeUnit.Liters) / time.In(TimeUnit.Seconds);
			return new VolumetricFlowRate(volumetricFlowRateValue, VolumetricFlowRateUnit.LitersPerSecond);
		}

		public static double operator /(Volume numerator, Volume denominator) {
			Guard.NotNull(numerator, "numerator");
			Guard.NotNull(denominator, "denominator");
			return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
		}

		public static bool operator ==(Volume left, Volume right) {
			return Equals(left, right);
		}

		public static bool operator >(Volume left, Volume right) {
			return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) > 0;
		}

		public static bool operator >=(Volume left, Volume right) {
			return (((object)left) == null) ? (((object)right) == null) : left.CompareTo(right) >= 0;
		}

		public static bool operator !=(Volume left, Volume right) {
			return !Equals(left, right);
		}

		public static bool operator <(Volume left, Volume right) {
			return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) < 0;
		}

		public static bool operator <=(Volume left, Volume right) {
			return (((object)left) == null) ? (((object)right) != null) : left.CompareTo(right) <= 0;
		}

		public static Volume operator *(Volume volume, double scaler) {
			Guard.NotNull(volume, "volume");
			return new Volume(volume.ValueInBaseUnits * scaler) {Units = volume.Units};
		}

		public static Volume operator *(double scaler, Volume volume) {
			Guard.NotNull(volume, "volume");
			return new Volume(volume.ValueInBaseUnits * scaler) {Units = volume.Units};
		}

		public static Mass operator *(Volume volume, Density density) {
			Guard.NotNull(density, "density");
			Guard.NotNull(volume, "volume");
			double massValue = volume.In(VolumeUnit.Liters) * density.In(DensityUnit.KilogramsPerLiter);
			return new Mass(massValue, MassUnit.Kilograms);
		}

		public static Volume operator -(Volume volume1, Volume volume2) {
			Guard.NotNull(volume1, "volume1");
			Guard.NotNull(volume2, "volume2");
			return new Volume(volume1.ValueInBaseUnits - volume2.ValueInBaseUnits) {Units = volume1.Units};
		}
	}
}