using System;
namespace Extensions.DateTime.Converters
{
    public static class DateTimeExtensions
    {
        public static long ToUnix(this System.DateTime dateTime)
        {
            var dTime = new System.DateTime(1970, 0, 0, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTime - dTime).TotalSeconds;
        }

        public static System.DateTime ToDateTime(long unixTime)
        {
            var dTime = new System.DateTime(1970, 0, 0, 0, 0, 0, DateTimeKind.Utc);
            return dTime.AddSeconds(unixTime);
        }
    }
}