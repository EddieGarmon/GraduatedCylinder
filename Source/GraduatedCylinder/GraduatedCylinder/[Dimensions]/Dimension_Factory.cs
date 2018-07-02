using System;

namespace GraduatedCylinder
{
    public abstract partial class Dimension
    {
        /// <summary>
        /// </summary>
        public static class Factory
        {
            static Factory() {
                Constructors = new SafeDictionary<DimensionType, Func<double, UnitOfMeasure, Dimension>> {
                    { DimensionType.Acceleration, (value, unitOfMeasure) => new Acceleration(value, unitOfMeasure) },
                    { DimensionType.Angle, (value, unitOfMeasure) => new Angle(value, unitOfMeasure) }, {
                        DimensionType.AngularAcceleration,
                        (value, unitOfMeasure) => new AngularAcceleration(value, unitOfMeasure)
                    },
                    { DimensionType.Area, (value, unitOfMeasure) => new Area(value, unitOfMeasure) }, {
                        DimensionType.ElectricCurrent,
                        (value, unitOfMeasure) => new ElectricCurrent(value, unitOfMeasure)
                    }, {
                        DimensionType.ElectricPotential,
                        (value, unitOfMeasure) => new ElectricPotential(value, unitOfMeasure)
                    },
                    { DimensionType.Energy, (value, unitOfMeasure) => new Energy(value, unitOfMeasure) },
                    { DimensionType.Force, (value, unitOfMeasure) => new Force(value, unitOfMeasure) },
                    { DimensionType.Frequency, (value, unitOfMeasure) => new Frequency(value, unitOfMeasure) },
                    { DimensionType.Jerk, (value, unitOfMeasure) => new Jerk(value, unitOfMeasure) },
                    { DimensionType.Length, (value, unitOfMeasure) => new Length(value, unitOfMeasure) },
                    { DimensionType.Mass, (value, unitOfMeasure) => new Mass(value, unitOfMeasure) },
                    { DimensionType.MassDensity, (value, unitOfMeasure) => new MassDensity(value, unitOfMeasure) },
                    { DimensionType.MassFlowRate, (value, unitOfMeasure) => new MassFlowRate(value, unitOfMeasure) },
                    { DimensionType.Momentum, (value, unitOfMeasure) => new Momentum(value, unitOfMeasure) },
                    { DimensionType.Numeric, (value, unitOfMeasure) => new Numeric(value, unitOfMeasure) },
                    { DimensionType.Power, (value, unitOfMeasure) => new Power(value, unitOfMeasure) },
                    { DimensionType.Pressure, (value, unitOfMeasure) => new Pressure(value, unitOfMeasure) }, {
                        DimensionType.ElectricResistance,
                        (value, unitOfMeasure) => new ElectricResistance(value, unitOfMeasure)
                    },
                    { DimensionType.Speed, (value, unitOfMeasure) => new Speed(value, unitOfMeasure) },
                    { DimensionType.Temperature, (value, unitOfMeasure) => new Temperature(value, unitOfMeasure) },
                    { DimensionType.Time, (value, unitOfMeasure) => new Time(value, unitOfMeasure) },
                    { DimensionType.Torque, (value, unitOfMeasure) => new Torque(value, unitOfMeasure) },
                    { DimensionType.Volume, (value, unitOfMeasure) => new Volume(value, unitOfMeasure) }, {
                        DimensionType.VolumetricFlowRate,
                        (value, unitOfMeasure) => new VolumetricFlowRate(value, unitOfMeasure)
                    }
                };
            }

            private static readonly SafeDictionary<DimensionType, Func<double, UnitOfMeasure, Dimension>> Constructors;

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

            public static Dimension Parse(string value) {
                throw new NotImplementedException();
                // parse floating point number, then units
            }

            public static T Parse<T>(string value)
                where T : Dimension {
                Dimension dimension = Parse(value);
                return (T)dimension;
            }
        }
    }
}