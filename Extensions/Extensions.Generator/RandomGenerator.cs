using System;
using System.Linq;
using System.Text;

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
            return GetUniqCode(4, 4);
        }

        public static string GetUniqCode(int countInSection, int sections)
        {
            if (sections <= 0)
                sections = 1;
            var commonLength = countInSection * sections + (sections - 1);

            var positions = GetHyphenPositions(countInSection, sections);

            int item = 0;

            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(commonLength)
                .ToList().ForEach(e =>
                {
                    if (positions.Contains(item))
                    {
                        builder.Append("-");
                    }
                    else
                    {
                        builder.Append(e);
                    }
                    item++;
                });

            return builder.ToString();
        }

        private static int[] GetHyphenPositions(int countInSection, int sections)
        {
            var pos = new int[sections - 1];
            var baseIndex = countInSection;
            for (int i = 0; i < pos.Length; i++)
            {
                pos[i] = baseIndex;
                baseIndex += countInSection + 1;
            }
            return pos;
        }
    }
}
