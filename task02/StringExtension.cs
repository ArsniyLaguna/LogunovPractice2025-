using System;
using System.Linq;

namespace task02
{
    public static class StringExtensions
    {
        public static bool IsAnagram(this string word1, string word2)
        {
            if (string.IsNullOrWhiteSpace(word1) || string.IsNullOrWhiteSpace(word2))
                return false;

            var cleaned1 = new string(word1
                .Where(char.IsLetterOrDigit)
                .Select(char.ToLower)
                .OrderBy(c => c)
                .ToArray());

            var cleaned2 = new string(word2
                .Where(char.IsLetterOrDigit)
                .Select(char.ToLower)
                .OrderBy(c => c)
                .ToArray());

            return cleaned1 == cleaned2;
        }
    }
}