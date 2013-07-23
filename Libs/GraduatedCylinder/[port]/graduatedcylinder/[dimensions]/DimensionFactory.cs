using System;

namespace GraduatedCylinder
{
	/// <summary>
	/// </summary>
	public static class DimensionFactory
	{
		private static readonly SafeDictionary<DimensionType, Func<double, UnitOfMeasure, Dimension>> Constructors;

		static DimensionFactory() {
			Constructors = new SafeDictionary<DimensionType, Func<double, UnitOfMeasure, Dimension>> {
				{DimensionType.Acceleration, (value, unitOfMeasure) => new Acceleration(value, unitOfMeasure)},
				{DimensionType.Angle, (value, unitOfMeasure) => new Angle(value, unitOfMeasure)},
				{DimensionType.AngularAcceleration, (value, unitOfMeasure) => new AngularAcceleration(value, unitOfMeasure)},
				{DimensionType.AngularVelocity, (value, unitOfMeasure) => new AngularVelocity(value, unitOfMeasure)},
				{DimensionType.Area, (value, unitOfMeasure) => new Area(value, unitOfMeasure)},
				{DimensionType.Current, (value, unitOfMeasure) => new Current(value, unitOfMeasure)},
				{DimensionType.Density, (value, unitOfMeasure) => new Density(value, unitOfMeasure)},
				{DimensionType.Energy, (value, unitOfMeasure) => new Energy(value, unitOfMeasure)},
				{DimensionType.Force, (value, unitOfMeasure) => new Force(value, unitOfMeasure)},
				{DimensionType.Frequency, (value, unitOfMeasure) => new Frequency(value, unitOfMeasure)},
				{DimensionType.Jerk, (value, unitOfMeasure) => new Jerk(value, unitOfMeasure)},
				{DimensionType.Length, (value, unitOfMeasure) => new Length(value, unitOfMeasure)},
				{DimensionType.Mass, (value, unitOfMeasure) => new Mass(value, unitOfMeasure)},
				{DimensionType.MassFlowRate, (value, unitOfMeasure) => new MassFlowRate(value, unitOfMeasure)},
				{DimensionType.Momentum, (value, unitOfMeasure) => new Momentum(value, unitOfMeasure)},
				{DimensionType.Numeric, (value, unitOfMeasure) => new Numeric(value, unitOfMeasure)},
				{DimensionType.Power, (value, unitOfMeasure) => new Power(value, unitOfMeasure)},
				{DimensionType.Pressure, (value, unitOfMeasure) => new Pressure(value, unitOfMeasure)},
				{DimensionType.Resistance, (value, unitOfMeasure) => new Resistance(value, unitOfMeasure)},
				{DimensionType.Speed, (value, unitOfMeasure) => new Speed(value, unitOfMeasure)},
				{DimensionType.Temperature, (value, unitOfMeasure) => new Temperature(value, unitOfMeasure)},
				{DimensionType.Time, (value, unitOfMeasure) => new Time(value, unitOfMeasure)},
				{DimensionType.Torque, (value, unitOfMeasure) => new Torque(value, unitOfMeasure)},
				{DimensionType.Voltage, (value, unitOfMeasure) => new Voltage(value, unitOfMeasure)},
				{DimensionType.Volume, (value, unitOfMeasure) => new Volume(value, unitOfMeasure)},
				{DimensionType.VolumetricFlowRate, (value, unitOfMeasure) => new VolumetricFlowRate(value, unitOfMeasure)}
			};
		}

		public static Dimension Build(double value, UnitOfMeasure units) {
			Func<double, UnitOfMeasure, Dimension> constructor = Constructors[units.DimensionType];
			if (constructor != null) {
				return constructor(value, units);
			}
			throw new Exception("Unknown Dimension");
		}

		/// <summary>
		///     Builds the specified dimension type. Units can be either the abbreviation or the full name of the units.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="units">The units.</param>
		/// <returns></returns>
		public static Dimension Build(double value, string units) {
			//todo case insensitive lookup?
			UnitOfMeasure unitOfMeasure = UnitOfMeasure.FindFirst(units);
			if (unitOfMeasure != null) {
				return Build(value, unitOfMeasure);
			}
			throw new Exception("Unknown units: " + units);
		}

		public static Dimension Clone(ISupportUnitOfMeasure measure) {
			return Build(measure.Value, measure.Units);
		}
	}
}