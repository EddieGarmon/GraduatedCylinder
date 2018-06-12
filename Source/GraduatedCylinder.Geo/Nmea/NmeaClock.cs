using System;

namespace GraduatedCylinder.Nmea
{
    public static class NmeaClock
    {
        static NmeaClock() {
            GetTime = () => DateTime.Now;
        }

        public static Func<DateTime> GetTime { get; set; }
    }
}