using System;
using System.Reflection;

public static class ReflectionHelper
{
    public static void PrintTypeInfo(Type type)
    {
        var displayAttr = type.GetCustomAttribute<DisplayNameAttribute>();
        if (displayAttr != null)
        {
            Console.WriteLine($"Класс: {displayAttr.DisplayName}");
        }

        var versionAttr = type.GetCustomAttribute<VersionAttribute>();
        if (versionAttr != null)
        {
            Console.WriteLine($"Версия: {versionAttr.Major}.{versionAttr.Minor}");
        }

        foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
        {
            var methodAttr = method.GetCustomAttribute<DisplayNameAttribute>();
            if (methodAttr != null)
            {
                Console.WriteLine($"Метод: {methodAttr.DisplayName}");
            }
        }

        foreach (var prop in type.GetProperties())
        {
            var propAttr = prop.GetCustomAttribute<DisplayNameAttribute>();
            if (propAttr != null)
            {
                Console.WriteLine($"Свойство: {propAttr.DisplayName}");
            }
        }
    }
}