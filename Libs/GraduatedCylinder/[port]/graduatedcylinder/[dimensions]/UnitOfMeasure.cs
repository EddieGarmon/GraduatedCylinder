using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraduatedCylinder
{
	public class UnitOfMeasure : IComparable<UnitOfMeasure>
	{
		internal const string BaseUnit = "BaseUnit";

		private static readonly SafeDictionary<DimensionType, UnitOfMeasureLookup> UomLookups =
			new SafeDictionary<DimensionType, UnitOfMeasureLookup>();

		private readonly string _abbreviation;
		private readonly DimensionType _dimensionType;
		private readonly int _enumValue;
		private readonly string _name;
		private readonly IUnitConverter _unitConverter;
		private UnitOfMeasure _baseUnits;

		static UnitOfMeasure() {
			foreach (EnumValueDescriptor<DimensionType> dimensionDescriptor in EnumReflector.DescribeAllValues<DimensionType>()) {
				if (dimensionDescriptor.Value == DimensionType.Unknown) {
					continue;
				}
				UnitOfMeasureLookup lookup = new UnitOfMeasureLookup(dimensionDescriptor.Value);
				Type unitsEnumType = dimensionDescriptor.EnsureOnlyOneAttribute<UnitsTypeAttribute>().UnitsType;
				if (!unitsEnumType.IsEnum) {
					const string format = "UnitsTypeAttribute on DimensionType.{0} does not specify an enumerated type.";
					throw new Exception(string.Format(format, dimensionDescriptor.Name));
				}
				if (Enum.GetUnderlyingType(unitsEnumType) != typeof(int)) {
					const string format = "{0} is not an enumeration with an 'int' base type";
					throw new Exception(string.Format(format, unitsEnumType));
				}
				bool baseUnitsFound = false;
				int baseUnitEnumValue = int.MinValue;
				foreach (EnumValueDescriptor<int> unitDescriptor in EnumReflector.DescribeAllValuesAsInt32(unitsEnumType)) {
					if (unitDescriptor.Name == BaseUnit) {
						baseUnitEnumValue = unitDescriptor.Value;
						baseUnitsFound = true;
						continue;
					}
					// the following check is preformed by the compiler as AbbreviationAttribute is sealed
					string abbreviation = unitDescriptor.EnsureOnlyOneAttribute<UnitAbbreviationAttribute>().Value;
					// the following check is NOT preformed by the compiler as ScaleDefinitionAttribute is abstract
					IUnitConverter unitConverter = unitDescriptor.EnsureOnlyOneAttribute<ScaleDefinitionAttribute>().UnitConverter;
					UnitOfMeasure uom = new UnitOfMeasure(dimensionDescriptor.Value, unitDescriptor.Value, unitDescriptor.Name, abbreviation, unitConverter);
					lookup.Add(uom);
				}
				if (!baseUnitsFound || (lookup.ByValue(baseUnitEnumValue) == null)) {
					throw new Exception("'BaseUnit' value is missing for unit enumeration: " + unitsEnumType);
				}
				lookup.SetBase(baseUnitEnumValue);
				UomLookups.Add(dimensionDescriptor.Value, lookup);
			}
		}

		private UnitOfMeasure(DimensionType dimensionType, int dimensionUnits, string name, string abbreviation, IUnitConverter unitConverter) {
			_dimensionType = dimensionType;
			_enumValue = dimensionUnits;
			_name = name;
			_abbreviation = abbreviation;
			_unitConverter = unitConverter;
		}

		public string Abbreviation {
			get { return _abbreviation; }
		}

		public string BaseAbbreviation {
			get { return _baseUnits.Abbreviation; }
		}

		public DimensionType DimensionType {
			get { return _dimensionType; }
		}

		public string Name {
			get { return _name; }
		}

		public IUnitConverter UnitConverter {
			get { return _unitConverter; }
		}

		internal UnitOfMeasure BaseUnits {
			get { return _baseUnits; }
			set { _baseUnits = value; }
		}

		internal int EnumValue {
			get { return _enumValue; }
		}

		public int CompareTo(UnitOfMeasure other) {
			if ((other) == null) {
				return 1;
			}
			if (ReferenceEquals(this, other)) {
				return 0;
			}
			int dimensionsComparison = _dimensionType.CompareTo(other.DimensionType);
			return (dimensionsComparison != 0) ? dimensionsComparison : _enumValue.CompareTo(other.EnumValue);
		}

		public static UnitOfMeasure Find(DimensionType dimension, string abbreviationOrName) {
			return UomLookups[dimension].ByAbbreviationOrName(abbreviationOrName);
		}

		public static UnitOfMeasure FindFirst(string abbreviationOrName) {
			IEnumerable<DimensionType> dimensions =
				typeof(DimensionType).GetFields(BindingFlags.Public | BindingFlags.Static)
									 .Where(field => field.IsLiteral)
									 .Select(field => (DimensionType)field.GetValue(null));

			//IEnumerable<DimensionType> dimensions = Enum.GetValues(typeof(DimensionType))
			//											.Cast<DimensionType>();

			return dimensions.Select(dimensionType => Find(dimensionType, abbreviationOrName)).FirstOrDefault(result => result != null);
		}

		public static implicit operator AccelerationUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Acceleration);
			return (AccelerationUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator AngleUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Angle);
			return (AngleUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator AngularAccelerationUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.AngularAcceleration);
			return (AngularAccelerationUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator AngularVelocityUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.AngularVelocity);
			return (AngularVelocityUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator AreaUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Area);
			return (AreaUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator CurrentUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Current);
			return (CurrentUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator DensityUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Density);
			return (DensityUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator EnergyUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Energy);
			return (EnergyUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator ForceUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Force);
			return (ForceUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator FrequencyUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Frequency);
			return (FrequencyUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator JerkUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Jerk);
			return (JerkUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator LengthUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Length);
			return (LengthUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator MassFlowRateUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.MassFlowRate);
			return (MassFlowRateUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator MassUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Mass);
			return (MassUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator MomentumUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Momentum);
			return (MomentumUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator NumericUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Numeric);
			return (NumericUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator PowerUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Power);
			return (PowerUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator PressureUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Pressure);
			return (PressureUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator ResistanceUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Resistance);
			return (ResistanceUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator SpeedUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Speed);
			return (SpeedUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator SpeedSquaredUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.SpeedSquared);
			return (SpeedSquaredUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator TemperatureUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Temperature);
			return (TemperatureUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator TimeUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Time);
			return (TimeUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator TorqueUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Torque);
			return (TorqueUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator VoltageUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Voltage);
			return (VoltageUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator VolumetricFlowRateUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.VolumetricFlowRate);
			return (VolumetricFlowRateUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator VolumeUnit(UnitOfMeasure unitOfMeasure) {
			unitOfMeasure.DimensionType.ShouldBe(DimensionType.Volume);
			return (VolumeUnit)(unitOfMeasure.EnumValue);
		}

		public static implicit operator UnitOfMeasure(AccelerationUnit accelerationUnit) {
			return UomLookups[DimensionType.Acceleration].ByValue((int)accelerationUnit);
		}

		public static implicit operator UnitOfMeasure(AngleUnit angleUnit) {
			return UomLookups[DimensionType.Angle].ByValue((int)angleUnit);
		}

		public static implicit operator UnitOfMeasure(AngularAccelerationUnit angularAccelerationUnit) {
			return UomLookups[DimensionType.AngularAcceleration].ByValue((int)angularAccelerationUnit);
		}

		public static implicit operator UnitOfMeasure(AngularVelocityUnit angularVelocityUnit) {
			return UomLookups[DimensionType.AngularVelocity].ByValue((int)angularVelocityUnit);
		}

		public static implicit operator UnitOfMeasure(AreaUnit areaUnit) {
			return UomLookups[DimensionType.Area].ByValue((int)areaUnit);
		}

		public static implicit operator UnitOfMeasure(CurrentUnit currentUnit) {
			return UomLookups[DimensionType.Current].ByValue((int)currentUnit);
		}

		public static implicit operator UnitOfMeasure(DensityUnit densityUnit) {
			return UomLookups[DimensionType.Density].ByValue((int)densityUnit);
		}

		public static implicit operator UnitOfMeasure(EnergyUnit energyUnit) {
			return UomLookups[DimensionType.Energy].ByValue((int)energyUnit);
		}

		public static implicit operator UnitOfMeasure(ForceUnit forceUnit) {
			return UomLookups[DimensionType.Force].ByValue((int)forceUnit);
		}

		public static implicit operator UnitOfMeasure(FrequencyUnit frequencyUnit) {
			return UomLookups[DimensionType.Frequency].ByValue((int)frequencyUnit);
		}

		public static implicit operator UnitOfMeasure(JerkUnit jerkUnit) {
			return UomLookups[DimensionType.Jerk].ByValue((int)jerkUnit);
		}

		public static implicit operator UnitOfMeasure(LengthUnit lengthUnit) {
			return UomLookups[DimensionType.Length].ByValue((int)lengthUnit);
		}

		public static implicit operator UnitOfMeasure(MassFlowRateUnit massFlowRateUnit) {
			return UomLookups[DimensionType.MassFlowRate].ByValue((int)massFlowRateUnit);
		}

		public static implicit operator UnitOfMeasure(MassUnit massUnit) {
			return UomLookups[DimensionType.Mass].ByValue((int)massUnit);
		}

		public static implicit operator UnitOfMeasure(MomentumUnit momentumUnit) {
			return UomLookups[DimensionType.Momentum].ByValue((int)momentumUnit);
		}

		public static implicit operator UnitOfMeasure(NumericUnit numericUnit) {
			return UomLookups[DimensionType.Numeric].ByValue((int)numericUnit);
		}

		public static implicit operator UnitOfMeasure(PowerUnit powerUnit) {
			return UomLookups[DimensionType.Power].ByValue((int)powerUnit);
		}

		public static implicit operator UnitOfMeasure(PressureUnit pressureUnit) {
			return UomLookups[DimensionType.Pressure].ByValue((int)pressureUnit);
		}

		public static implicit operator UnitOfMeasure(ResistanceUnit resistanceUnit) {
			return UomLookups[DimensionType.Resistance].ByValue((int)resistanceUnit);
		}

		public static implicit operator UnitOfMeasure(SpeedUnit speedUnit) {
			return UomLookups[DimensionType.Speed].ByValue((int)speedUnit);
		}

		public static implicit operator UnitOfMeasure(SpeedSquaredUnit speedSquaredUnit) {
			return UomLookups[DimensionType.SpeedSquared].ByValue((int)speedSquaredUnit);
		}

		public static implicit operator UnitOfMeasure(TemperatureUnit temperatureUnit) {
			return UomLookups[DimensionType.Temperature].ByValue((int)temperatureUnit);
		}

		public static implicit operator UnitOfMeasure(TimeUnit timeUnit) {
			return UomLookups[DimensionType.Time].ByValue((int)timeUnit);
		}

		public static implicit operator UnitOfMeasure(TorqueUnit torqueUnit) {
			return UomLookups[DimensionType.Torque].ByValue((int)torqueUnit);
		}

		public static implicit operator UnitOfMeasure(VoltageUnit voltageUnit) {
			return UomLookups[DimensionType.Voltage].ByValue((int)voltageUnit);
		}

		public static implicit operator UnitOfMeasure(VolumetricFlowRateUnit volumetricFlowRateUnit) {
			return UomLookups[DimensionType.VolumetricFlowRate].ByValue((int)volumetricFlowRateUnit);
		}

		public static implicit operator UnitOfMeasure(VolumeUnit volumeUnit) {
			return UomLookups[DimensionType.Volume].ByValue((int)volumeUnit);
		}
	}
}