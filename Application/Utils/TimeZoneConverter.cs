namespace Application.Utils;

public static class TimeZoneConverter
{
    public static DateTime ConvertToUtc(DateTime dateTime)
    {
        return TimeZoneInfo.ConvertTimeToUtc(dateTime);
    }

    public static DateTime ConvertFromUtc(DateTime dateTime, string timeZoneId)
    {
        return TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));
    }
}