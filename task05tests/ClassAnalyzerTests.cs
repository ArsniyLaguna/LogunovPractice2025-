using Xunit;
using task05;
using System;

namespace task05tests
{
    public class TestClass
    {
        public int PublicField;
        private string _privateField;
        public int Property { get; set; }

        public void Method() { }

        public string Echo(string input) => input;
    }

    [Serializable]
    public class AttributedClass { }

    public class ClassAnalyzerTests
    {
        [Fact]
        public void GetPublicMethods_ReturnsCorrectMethods()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var methods = analyzer.GetPublicMethods();

            Assert.Contains("Method", methods);
            Assert.Contains("Echo", methods);
        }

        [Fact]
        public void GetAllFields_IncludesPrivateFields()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var fields = analyzer.GetAllFields();

            Assert.Contains("_privateField", fields);
            Assert.Contains("PublicField", fields);
        }

        [Fact]
        public void GetProperties_ReturnsPropertyNames()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var props = analyzer.GetProperties();

            Assert.Contains("Property", props);
        }

        [Fact]
        public void GetMethodParams_ReturnsParameterNamesAndReturnType()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            var paramList = analyzer.GetMethodParams("Echo");

            Assert.Contains("returns: String", paramList);
            Assert.Contains("input", paramList);
        }

        [Fact]
        public void HasAttribute_ReturnsTrueForSerializableClass()
        {
            var analyzer = new ClassAnalyzer(typeof(AttributedClass));
            Assert.True(analyzer.HasAttribute<SerializableAttribute>());
        }

        [Fact]
        public void HasAttribute_ReturnsFalseForNonAttributedClass()
        {
            var analyzer = new ClassAnalyzer(typeof(TestClass));
            Assert.False(analyzer.HasAttribute<SerializableAttribute>());
        }
    }
}