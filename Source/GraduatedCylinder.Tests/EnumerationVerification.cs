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
            var acceleration = new Acceleration(1, AccelerationUnit.BaseUnit);
            var angle = new Angle(1, AngleUnit.BaseUnit);
            var angularAcceleration = new AngularAcceleration(1, AngularAccelerationUnit.BaseUnit);
            var area = new Area(1, AreaUnit.BaseUnit);
            var density = new MassDensity(1, MassDensityUnit.BaseUnit);
            var electricCurrent = new ElectricCurrent(1, ElectricCurrentUnit.BaseUnit);
            var electricResistance = new ElectricResistance(1, ElectricResistanceUnit.BaseUnit);
            var electricVoltage = new ElectricPotential(1, ElectricPotentialUnit.BaseUnit);
            var energy = new Energy(1, EnergyUnit.BaseUnit);
            var force = new Force(1, ForceUnit.BaseUnit);
            var frequency = new Frequency(1, FrequencyUnit.BaseUnit);
            var jerk = new Jerk(1, JerkUnit.BaseUnit);
            var length = new Length(1, LengthUnit.BaseUnit);
            var mass = new Mass(1, MassUnit.BaseUnit);
            var massFlowRate = new MassFlowRate(1, MassFlowRateUnit.BaseUnit);
            var momentum = new Momentum(1, MomentumUnit.BaseUnit);
            var numeric = new Numeric(1, NumericUnit.BaseUnit);
            var power = new Power(1, PowerUnit.BaseUnit);
            var pressure = new Pressure(1, PressureUnit.BaseUnit);
            var speed = new Speed(1, SpeedUnit.BaseUnit);
            var temperature = new Temperature(1, TemperatureUnit.BaseUnit);
            var time = new Time(1, TimeUnit.BaseUnit);
            var torque = new Torque(1, TorqueUnit.BaseUnit);
            var volume = new Volume(1, VolumeUnit.BaseUnit);
            var volumetricFlowRate = new VolumetricFlowRate(1, VolumetricFlowRateUnit.BaseUnit);
        }
    }
}