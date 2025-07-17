using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using task13;
using Xunit;

namespace task13tests;

public class StudentTests
{
    [Fact]
    public void Serialize_And_Deserialize_Student_Should_Match()
    {
        var student = new Student
        {
            FirstName = "Алексей",
            LastName = "Иванов",
            BirthDate = new DateTime(2000, 4, 10),
            Grades = new List<Subject>
            {
                new Subject { Name = "Математика", Grade = 5 },
                new Subject { Name = "Физика", Grade = 4 }
            }
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = { new JsonDateOnlyConverter() }
        };

        var json = JsonSerializer.Serialize(student, options);
        var deserialized = JsonSerializer.Deserialize<Student>(json, options);

        Assert.NotNull(deserialized);
        Assert.Equal(student.FirstName, deserialized.FirstName);
        Assert.Equal(student.LastName, deserialized.LastName);
        Assert.Equal(student.BirthDate, deserialized.BirthDate);
        Assert.Equal(student.Grades.Count, deserialized.Grades.Count);
    }
}