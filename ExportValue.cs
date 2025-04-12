namespace PlanningReporting.Application.Common.Models;

public class ExportValue
{
    public const string VALUE_FOR_NULL = "";
    public const int VALUE_FOR_NUMBER_NULL = 0;
    public const string DEFAULT_DATE_VALUE_FORMAT = "dd/MM/yyyy";
    public const string DEFAULT_DATETIME_VALUE_FORMAT = "dd/MM/yyyy - hh\\:mm";
    public const string DEFAULT_TIME_VALUE_FORMAT = "hh\\:mm";

    public static string From(string? value)
    {
        return value ?? VALUE_FOR_NULL;
    }

    public static int From(int? value)
    {
        return value ?? VALUE_FOR_NUMBER_NULL;
    }

    public static string FromWithZeroAsNull(decimal? value)
    {
        if(value == null || value == 0) return VALUE_FOR_NULL;

        return value.Value.ToString("0.00");
    }

    public static string FromWithDefaultEmpty(int? value)
    {
        if (value is null or 0)
            return VALUE_FOR_NULL;

        return value.Value.ToString();
    }

    public static string ToDateValue(DateTime? date)
    {
        return date == null ? VALUE_FOR_NULL : date.Value.ToString(DEFAULT_DATE_VALUE_FORMAT);
    }

    public static string ToDateTimeValue(DateTime? date)
    {
        return date == null ? VALUE_FOR_NULL : date.Value.ToString(DEFAULT_DATETIME_VALUE_FORMAT);
    }

    public static string ToDateTimeValue(DateTime? date, TimeSpan? time)
    {
        if (date == null) return VALUE_FOR_NULL;

        if (time == null) return ToDateValue(date);

        return ToDateValue(date) + " - " + ToTimeValue(time);
    }

    public static string ToTimeValue(TimeSpan? time)
    {
        return time == null ? VALUE_FOR_NULL : time.Value.ToString(DEFAULT_TIME_VALUE_FORMAT);
    }
}