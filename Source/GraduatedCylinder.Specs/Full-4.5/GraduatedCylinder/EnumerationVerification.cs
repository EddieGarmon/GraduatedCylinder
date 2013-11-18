using Xunit;

namespace GraduatedCylinder
{
    public class EnumerationVerification
    {
        /// <summary>
        ///     instantiate all types to verify all enums.
        /// </summary>
        [Fact]
        public void VerifyAllEnums() {
            Acceleration acceleration = new Acceleration(1, AccelerationUnit.BaseUnit);
            Angle angle = new Angle(1, AngleUnit.BaseUnit);
            AngularAcceleration angularAcceleration = new AngularAcceleration(1, AngularAccelerationUnit.BaseUnit);
            AngularVelocity angularVelocity = new AngularVelocity(1, AngularVelocityUnit.BaseUnit);
            Area area = new Area(1, AreaUnit.BaseUnit);
            Current current = new Current(1, CurrentUnit.BaseUnit);
            Density density = new Density(1, DensityUnit.BaseUnit);
            Energy energy = new Energy(1, EnergyUnit.BaseUnit);
            Force force = new Force(1, ForceUnit.BaseUnit);
            Frequency frequency = new Frequency(1, FrequencyUnit.BaseUnit);
            Jerk jerk = new Jerk(1, JerkUnit.BaseUnit);
            Length distance = new Length(1, LengthUnit.BaseUnit);
            Mass mass = new Mass(1, MassUnit.BaseUnit);
            MassFlowRate massFlowRate = new MassFlowRate(1, MassFlowRateUnit.BaseUnit);
            Momentum momentum = new Momentum(1, MomentumUnit.BaseUnit);
            Numeric numeric = new Numeric(1, NumericUnit.BaseUnit);
            Power power = new Power(1, PowerUnit.BaseUnit);
            Pressure pressure = new Pressure(1, PressureUnit.BaseUnit);
            Resistance resistance = new Resistance(1, ResistanceUnit.BaseUnit);
            Speed speed = new Speed(1, SpeedUnit.BaseUnit);
            Temperature temperature = new Temperature(1, TemperatureUnit.BaseUnit);
            Time time = new Time(1, TimeUnit.BaseUnit);
            Torque torque = new Torque(1, TorqueUnit.BaseUnit);
            Voltage voltage = new Voltage(1, VoltageUnit.BaseUnit);
            Volume volume = new Volume(1, VolumeUnit.BaseUnit);
        }
    }
}