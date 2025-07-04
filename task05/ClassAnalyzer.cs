using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace task05
{
    public class ClassAnalyzer
    {
        private Type _type;

        public ClassAnalyzer(Type type)
        {
            _type = type;
        }

        public IEnumerable<string> GetPublicMethods()
        {
            return _type
                .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Select(m => m.Name);
        }

        public IEnumerable<string> GetMethodParams(string methodName)
        {
            return _type
                .GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(m => m.Name == methodName)
                .SelectMany(m => new[] { $"returns: {m.ReturnType.Name}" }
                    .Concat(m.GetParameters().Select(p => p.Name)));
        }

        public IEnumerable<string> GetAllFields()
        {
            return _type
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Select(f => f.Name);
        }

        public IEnumerable<string> GetProperties()
        {
            return _type
                .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Select(p => p.Name);
        }

        public bool HasAttribute<T>() where T : Attribute
        {
            return _type.GetCustomAttributes(typeof(T), true).Length > 0;
        }
    }
}