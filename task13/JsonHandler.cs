using System.IO;
using System.Text.Json;

namespace task13;

public static class JsonHandler
{
    public static void SaveToFile(Student student, string path, JsonSerializerOptions options)
    {
        var json = JsonSerializer.Serialize(student, options);
        File.WriteAllText(path, json);
    }

    public static Student LoadFromFile(string path, JsonSerializerOptions options)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<Student>(json, options);
    }
}