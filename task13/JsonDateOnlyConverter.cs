using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace task13;

public class JsonDateOnlyConverter : JsonConverter<DateTime>
{
    private readonly string format = "yyyy-MM-dd";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString(), format, null);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(format));
    }
}