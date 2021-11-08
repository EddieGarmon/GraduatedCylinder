namespace GraduatedCylinder
{
    public partial struct MassFlowRate : IDimension<MassFlowRate, MassFlowRateUnit>
    {

        public static Mass operator *(MassFlowRate massFlowRate, Time time) {
            massFlowRate = massFlowRate.In(MassFlowRateUnit.KilogramsPerSecond);
            time = time.In(TimeUnit.Second);
            return new Mass(massFlowRate.Value * time.Value, MassUnit.Kilogram);
        }

    }
}