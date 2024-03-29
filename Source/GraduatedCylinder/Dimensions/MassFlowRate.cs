﻿#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct MassFlowRate : IDimension<MassFlowRate, MassFlowRateUnit>
{

    public static Mass operator *(MassFlowRate massFlowRate, Time time) {
        massFlowRate = massFlowRate.In(MassFlowRateUnit.KiloGramsPerSecond);
        time = time.In(TimeUnit.Second);
        return new Mass(massFlowRate.Value * time.Value, MassUnit.KiloGram);
    }

}