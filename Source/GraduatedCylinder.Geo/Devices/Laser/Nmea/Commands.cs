using GraduatedCylinder.Devices.Laser.Modes;

namespace GraduatedCylinder.Devices.Laser.Nmea
{
    internal static class Commands
    {
        //to get a value> $Command
        //to set a value> $Command,NewValue
        internal static readonly CommandSentence<AngleUnitsMode> AngleUnits = new CommandSentence<AngleUnitsMode>("AU");
        internal static readonly CommandSentence BatteryVoltage = new CommandSentence("BV");
        internal static readonly CommandSentence<DistanceUnitsMode> DistanceUnits = new CommandSentence<DistanceUnitsMode>("DU");
        internal static readonly CommandSentence Id = new CommandSentence("ID");
        internal static readonly CommandSentence<MeasurementMode> MeasurementMode = new CommandSentence<MeasurementMode>("MM");
        internal static readonly CommandSentence PowerOff = new CommandSentence("PO");
        internal static readonly CommandSentence Start = new CommandSentence("GO");
        internal static readonly CommandSentence Stop = new CommandSentence("ST");
        internal static readonly CommandSentence<TargetMode> TargetMode = new CommandSentence<TargetMode>("TM");
    }
}