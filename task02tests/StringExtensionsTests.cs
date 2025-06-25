using Xunit;
using task02;

namespace task02tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void IsAnagram_Valid_ReturnsTrue()
        {
            string a = "Listen";
            string b = "Silent";
            Assert.True(a.IsAnagram(b));
        }

        [Fact]
        public void IsAnagram_Invalid_ReturnsFalse()
        {
            string a = "hello";
            string b = "world";
            Assert.False(a.IsAnagram(b));
        }

        [Fact]
        public void IsAnagram_EmptyStrings_ReturnsFalse()
        {
            string a = "";
            string b = "";
            Assert.False(a.IsAnagram(b));
        }

        [Fact]
        public void IsAnagram_IgnoresPunctuationAndCase()
        {
            string a = "Dormitory";
            string b = "Dirty room!";
            Assert.True(a.IsAnagram(b));
        }
    }
}