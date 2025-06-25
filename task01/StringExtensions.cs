using System;
using System.Linq;

namespace task01
{
    public static class StringExtensions
    {
        public static bool IsPalindrome(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            var cleaned = new string(input
                .Where(c => !char.IsWhiteSpace(c) && !char.IsPunctuation(c))
                .Select(char.ToLower)
                .ToArray());

            var reversed = new string(cleaned.Reverse().ToArray());

            return cleaned == reversed;
        }
    }
}