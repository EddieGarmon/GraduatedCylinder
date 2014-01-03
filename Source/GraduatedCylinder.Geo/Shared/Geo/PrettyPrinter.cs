using System;

namespace GraduatedCylinder.Geo
{
    public struct PrettyPrinter
    {
        public const char DegreesSymbol = '\xB0';
        public const char MinutesSymbol = '\x27';
        public const char SecondsSymbol = '\x22';
        private readonly double _degrees;
        private readonly char _hemisphere;
        private readonly double _minutes;
        private readonly int _roundedDegrees;
        private readonly int _roundedMinutes;
        private readonly double _seconds;

        public PrettyPrinter(Latitude latitude)
            : this(Math.Abs(latitude.Value), latitude.Hemisphere) { }

        public PrettyPrinter(Longitude longitude)
            : this(Math.Abs(longitude.Value), longitude.Hemisphere) { }

        private PrettyPrinter(double value, char hemisphere) {
            _degrees = value;
            _roundedDegrees = (int)value;
            _minutes = (_degrees - _roundedDegrees) * 60;
            _roundedMinutes = (int)_minutes;
            _seconds = (_minutes - _roundedMinutes) * 60;
            _hemisphere = hemisphere;
        }

        public string AsDegrees() {
            return string.Format("{0:N5}{1} {2}", _degrees, DegreesSymbol, _hemisphere);
        }

        public string AsDegreesMinutes() {
            return string.Format("{0}{1} {2:N4}{3} {4}", _roundedDegrees, DegreesSymbol, _minutes, MinutesSymbol, _hemisphere);
        }

        public string AsDegreesMinutesSeconds() {
            return string.Format("{0}{1} {2}{3} {4:N4}{5} {6}",
                                 _roundedDegrees,
                                 DegreesSymbol,
                                 _roundedMinutes,
                                 MinutesSymbol,
                                 _seconds,
                                 SecondsSymbol,
                                 _hemisphere);
        }
    }
}