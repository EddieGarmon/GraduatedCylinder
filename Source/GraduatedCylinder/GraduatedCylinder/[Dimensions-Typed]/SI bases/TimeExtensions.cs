namespace GraduatedCylinder
{
    public static class TimeExtensions
    {
        public static Time Days(this double value) {
            return new Time(value, TimeUnit.Days);
        }

        public static Time Hours(this double value) {
            return new Time(value, TimeUnit.Hours);
        }

        public static Time MilliSeconds(this double value) {
            return new Time(value, TimeUnit.MilliSecond);
        }

        public static Time Minutes(this double value) {
            return new Time(value, TimeUnit.Minutes);
        }

        public static Time Seconds(this double value) {
            return new Time(value, TimeUnit.Second);
        }

        public static Time Ticks(this double value) {
            return new Time(value, TimeUnit.Ticks);
        }

        public static Time Ticks(this long value) {
            return new Time(value, TimeUnit.Ticks);
        }
    }
}