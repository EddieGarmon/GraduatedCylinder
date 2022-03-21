namespace GraduatedCylinder.Geo.Laser.Nmea;

internal static class Variables
{

    internal static AngleUnitsVariable AngleUnits { get; } = new();

    internal static BatteryVoltageVariable BatteryVoltage { get; } = new();

    internal static DeviceInfoVariable DeviceInfo { get; } = new();

    internal static DistanceUnitsVariable DistanceUnits { get; } = new();

    internal static MeasurementModeVariable MeasurementMode { get; } = new();

    internal static TargetModeVariable TargetMode { get; } = new();

}