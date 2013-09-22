namespace GraduatedCylinder
{
    public class SpeedSquared : Dimension
    {
        public SpeedSquared(double value, SpeedSquaredUnit units)
            : base(value, units) {}

        public SpeedSquared(double value, UnitOfMeasure unitOfMeasure)
            : base(value, unitOfMeasure) {}

        internal SpeedSquared(double baseUnitsValue)
            : base(baseUnitsValue, SpeedSquaredUnit.BaseUnit) {}

        public static SpeedSquared operator +(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new SpeedSquared(left.ValueInBaseUnits + right.ValueInBaseUnits) {Units = left.Units};
        }

        public static double operator /(SpeedSquared numerator, SpeedSquared denominator) {
            Guard.NotNull(numerator, "numerator");
            Guard.NotNull(denominator, "denominator");
            return numerator.ValueInBaseUnits / denominator.ValueInBaseUnits;
        }

        public static SpeedSquared operator /(SpeedSquared speedSquared, double scaler) {
            Guard.NotNull(speedSquared, "speedSquared");
            return new SpeedSquared(speedSquared.ValueInBaseUnits / scaler) {Units = speedSquared.Units};
        }

        public static Acceleration operator /(SpeedSquared speedSquared, Length length) {
            Guard.NotNull(speedSquared, "speedSquared");
            Guard.NotNull(length, "length");
            double accelerationValue = speedSquared.In(SpeedSquaredUnit.MetersSquaredPerSecondSquared) / length.In(LengthUnit.Meters);
            return new Acceleration(accelerationValue, AccelerationUnit.MetersPerSecondSquared);
        }

        public static bool operator >(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) >= 0;
        }

        public static bool operator <(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return left.CompareTo(right) <= 0;
        }

        public static SpeedSquared operator *(SpeedSquared value, double scaler) {
            Guard.NotNull(value, "value");
            return new SpeedSquared(value.ValueInBaseUnits * scaler) {Units = value.Units};
        }

        public static SpeedSquared operator *(double scaler, SpeedSquared value) {
            Guard.NotNull(value, "value");
            return new SpeedSquared(value.ValueInBaseUnits * scaler) {Units = value.Units};
        }

        public static SpeedSquared operator -(SpeedSquared left, SpeedSquared right) {
            Guard.NotNull(left, "left");
            Guard.NotNull(right, "right");
            return new SpeedSquared(left.ValueInBaseUnits - right.ValueInBaseUnits) {Units = left.Units};
        }
    }
}