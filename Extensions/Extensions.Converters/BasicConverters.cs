using System.Text.Json;
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

        /// <summary>
        /// Converting from any object to json object
        /// </summary>
        /// <param name="data">Any objects</param>
        /// <returns>Json object</returns>
        public static string AsJson(this object data)
        {
            return JsonSerializer.Serialize(data);
        }

        /// <summary>
        /// Converting from string json to object
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="data">json object in string</param>
        /// <returns>TEntity</returns>
        public static TEntity AsObject<TEntity>(this string data)
        {
            return JsonSerializer.Deserialize<TEntity>(data);
        }
    }
}