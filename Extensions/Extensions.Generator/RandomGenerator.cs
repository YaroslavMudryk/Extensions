using System;
using System.Linq;

namespace Extensions.Generator
{
    public class RandomGenerator
    {
        private static string _upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static string _lowerChars = "abcdefghijklmnopqrstuvwxyz";
        private static string _numbersChars = "0123456789";
        private static string _chars = $"{_upperChars}{_lowerChars}{_numbersChars}";

        public static string GetStringCode(int length)
        {
            string result = null;
            var rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                result += _numbersChars[rnd.Next(_numbersChars.Length)];
            }
            return result;
        }

        public static string GetString(int length, bool IsUpper = false, bool IsLowwer = false)
        {
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = _chars[random.Next(_chars.Length)];
            }
            var result = new string(stringChars);
            return IsUpper ? result.ToUpper() : IsLowwer ? result.ToLower() : result;
        }

        public static string GetUniqCode()
        {
            return GetUniqCodeUpper(4);
        }

        public static string GetUniqCode(int sections)
        {
            var commonWords = sections * 4;
            var commonCountOfSymbols = commonWords + (sections - 1);
            var stringChars = new char[commonCountOfSymbols];
            var positons = getHyphenPositions(sections);
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                if (positons.Contains(i))
                {
                    stringChars[i] = '-';
                    continue;
                }
                stringChars[i] = _chars[random.Next(_chars.Length)];
            }
            var result = new String(stringChars);
            return result;
        }

        public static string GetUniqCodeUpper(int sections)
        {
            return GetUniqCode(sections).ToUpper();
        }

        public static string GetUniqCodeLower(int sections)
        {
            return GetUniqCode(sections).ToLower();
        }

        private static int[] getHyphenPositions(int sections)
        {
            var pos = new int[sections - 1];
            var baseIndex = 4;
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = baseIndex;
                baseIndex += 4 + 1;
            }
            return pos;
        }
    }
}
