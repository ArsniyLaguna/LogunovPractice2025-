using System;
using System.IO;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Укажите путь к библиотеке (DLL) как аргумент командной строки.");
            return;
        }

        string path = args[0];

        if (!File.Exists(path))
        {
            Console.WriteLine($"Файл по пути '{path}' не найден.");
            return;
        }

        Assembly assembly;
        try
        {
            assembly = Assembly.LoadFrom(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка загрузки сборки: " + ex.Message);
            return;
        }

        Console.WriteLine($"Сборка: {Path.GetFileName(path)}");

        foreach (var type in assembly.GetTypes())
        {
            Console.WriteLine($"\nКласс: {type.FullName}");

            // Атрибуты класса
            foreach (var attr in type.GetCustomAttributes())
            {
                Console.WriteLine($"  Атрибут: {attr.GetType().Name}");
            }

            // Конструкторы
            foreach (var ctor in type.GetConstructors())
            {
                Console.WriteLine("  Конструктор:");
                foreach (var param in ctor.GetParameters())
                {
                    Console.WriteLine($"    Параметр: {param.Name} ({param.ParameterType.Name})");
                }
            }

            // Методы
            foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                Console.WriteLine($"  Метод: {method.Name}");

                // Атрибуты метода
                foreach (var attr in method.GetCustomAttributes())
                {
                    Console.WriteLine($"    Атрибут: {attr.GetType().Name}");
                }

                foreach (var param in method.GetParameters())
                {
                    Console.WriteLine($"    Параметр: {param.Name} ({param.ParameterType.Name})");
                }
            }
        }
    }
}