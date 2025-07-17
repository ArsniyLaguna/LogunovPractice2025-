using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using task13;

class Program
{
    static void Main()
    {
        var student = new Student
        {
            FirstName = "Ирина",
            LastName = "Петрова",
            BirthDate = new DateTime(2001, 3, 5),
            Grades = new List<Subject>
            {
                new Subject { Name = "Биология", Grade = 5 },
                new Subject { Name = "Химия", Grade = 4 }
            }
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonDateOnlyConverter() }
        };

        string filePath = "student.json";

        JsonHandler.SaveToFile(student, filePath, options);
        Console.WriteLine($"Объект сериализован и сохранён в файл: {filePath}");

        var loadedStudent = JsonHandler.LoadFromFile(filePath, options);
        Console.WriteLine("Объект успешно загружен:");
        Console.WriteLine($"Имя: {loadedStudent.FirstName} {loadedStudent.LastName}");
        Console.WriteLine($"Дата рождения: {loadedStudent.BirthDate:yyyy-MM-dd}");
        Console.WriteLine("Оценки:");
        foreach (var subject in loadedStudent.Grades)
        {
            Console.WriteLine($"  {subject.Name}: {subject.Grade}");
        }
    }
}