using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceCore
{
    public static class DateTimeExtension
    {
        public static string ToStandardDate(this DateTime? time)
        {
            if (!time.HasValue) return string.Empty;
            return time.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }
        public static string ToStandardDate(this DateTime time)
        {
            return time.ToString("yyyy-MM-dd HH:mm:ss");
        }
        //是否是工作日
        public static bool IsWorkDay(this DateTime? time)
        {
            if (!time.HasValue) return true;
            return time.Value.DayOfWeek != DayOfWeek.Sunday && time.Value.DayOfWeek != DayOfWeek.Tuesday;
        }
        //假装是今天的数
        public static string ToNowStandardDate(this DateTime? time)
        {
            if (!time.HasValue) return string.Empty;

            return time.Value.ToString($"{DateTime.Today.ToString("yyyy-MM-dd")} HH:mm:ss");
        }

        public static DateTime ToDateTime(this DateTime time, string format)
        {
            DateTime.TryParse(time.ToString(format), out DateTime newTime);
            return newTime;
        }
    }
}
