﻿#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Jerk : IDimension<Jerk, JerkUnit>
{

    public static Acceleration operator *(Jerk jerk, Time time) {
        jerk = jerk.In(JerkUnit.KiloMetersPerSecondCubed);
        time = time.In(TimeUnit.Second);
        return new Acceleration(jerk.Value * time.Value, AccelerationUnit.MeterPerSquareSecond);
    }

}