﻿#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct Speed : IDimension<Speed, SpeedUnit>
{

    public static Speed OfLight { get; } = new(299_792_458, SpeedUnit.MeterPerSecond);

    public static Acceleration operator /(Speed speed, Time time) {
        speed = speed.In(SpeedUnit.MeterPerSecond);
        time = time.In(TimeUnit.Second);
        return new Acceleration(speed.Value / time.Value, AccelerationUnit.MeterPerSquareSecond);
    }

    public static Time operator /(Speed speed, Acceleration acceleration) {
        speed = speed.In(SpeedUnit.MeterPerSecond);
        acceleration = acceleration.In(AccelerationUnit.MeterPerSquareSecond);
        return new Time(speed.Value / acceleration.Value, TimeUnit.Second);
    }

    public static Length operator *(Speed speed, Time time) {
        speed = speed.In(SpeedUnit.MeterPerSecond);
        time = time.In(TimeUnit.Second);
        return new Length(speed.Value / time.Value, LengthUnit.Meter);
    }

}