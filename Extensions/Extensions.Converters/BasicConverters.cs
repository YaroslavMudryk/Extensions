using System;

namespace Extensions.Converters
{
    public static class BasicConverters
    {
        public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);
        public static bool IsNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);

        public static int ToInt(this string value)
        {
            if (int.TryParse(value, out var res))
                return res;
            return default;
        }

        public static long ToLong(this string value)
        {
            if (long.TryParse(value, out var res))
                return res;
            return default;
        }

        public static double ToDouble(this string value)
        {
            if (double.TryParse(value, out var res))
                return res;
            return default;
        }

        public static float ToFloat(this string value)
        {
            if (float.TryParse(value, out var res))
                return res;
            return default;
        }

        public static bool ToBool(this string value)
        {
            if (bool.TryParse(value, out var res))
                return res;
            return default;
        }

        public static byte ToByte(this string value)
        {
            if (byte.TryParse(value, out var res))
                return res;
            return default;
        }

        public static decimal ToDecimal(this string value)
        {
            if (decimal.TryParse(value, out var res))
                return res;
            return default;
        }

        public static char ToChar(this string value)
        {
            if (char.TryParse(value, out var res))
                return res;
            return default;
        }
    }
}
