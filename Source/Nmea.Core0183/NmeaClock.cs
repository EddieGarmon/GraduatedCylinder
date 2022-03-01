namespace Nmea.Core0183;

public static class NmeaClock
{

    static NmeaClock() {
        GetDate = () => DateTime.UtcNow.Date;
    }

    public static Func<DateTime> GetDate { get; set; }

    public static DateTimeOffset GetDateTime(TimeSpan timeOfDay) {
        DateTime dateTime = GetDate() + timeOfDay;
        DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, TimeSpan.Zero);
        return dateTimeOffset;
    }

}