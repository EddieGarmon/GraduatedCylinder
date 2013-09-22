namespace GraduatedCylinder
{
    internal class UnitAndValueComparers
    {
        public static readonly FuncComparer<Acceleration> Acceleration = new FuncComparer<Acceleration>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Angle> Angle = new FuncComparer<Angle>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<AngularAcceleration> AngularAcceleration =
            new FuncComparer<AngularAcceleration>((left, right) => {
                int unitComp = left.Units.CompareTo(right.Units);
                return (unitComp != 0) ? unitComp : left.CompareTo(right);
            });

        public static readonly FuncComparer<Area> Area = new FuncComparer<Area>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Density> Density = new FuncComparer<Density>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Current> ElectricCurrent = new FuncComparer<Current>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Resistance> ElectricResistance = new FuncComparer<Resistance>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Energy> Energy = new FuncComparer<Energy>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Force> Force = new FuncComparer<Force>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Frequency> Frequency = new FuncComparer<Frequency>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Jerk> Jerk = new FuncComparer<Jerk>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Length> Length = new FuncComparer<Length>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Mass> Mass = new FuncComparer<Mass>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<MassFlowRate> MassFlowRate = new FuncComparer<MassFlowRate>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Momentum> Momentum = new FuncComparer<Momentum>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Power> Power = new FuncComparer<Power>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Pressure> Pressure = new FuncComparer<Pressure>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<AngularVelocity> Revolutions = new FuncComparer<AngularVelocity>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Speed> Speed = new FuncComparer<Speed>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Temperature> Temperature = new FuncComparer<Temperature>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Time> Time = new FuncComparer<Time>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);

            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Torque> Torque = new FuncComparer<Torque>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Voltage> Voltage = new FuncComparer<Voltage>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<Volume> Volume = new FuncComparer<Volume>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });

        public static readonly FuncComparer<VolumetricFlowRate> VolumetricFlowRate = new FuncComparer<VolumetricFlowRate>((left, right) => {
            int unitComp = left.Units.CompareTo(right.Units);
            return (unitComp != 0) ? unitComp : left.CompareTo(right);
        });
    }
}