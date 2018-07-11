using System;

namespace GraduatedCylinder.Nmea
{
    public static class NmeaClock
    {
        static NmeaClock() {
            GetDate = () => DateTime.Now.Date;
        }

        public static Func<DateTime> GetDate { get; set; }

        public static DateTimeOffset GetDateTime(TimeSpan timeOfDay) {
            DateTime dateTime = GetDate() + timeOfDay;
            return new DateTimeOffset(dateTime, TimeSpan.Zero);
        }
    }
}