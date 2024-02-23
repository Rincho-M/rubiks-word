using System.Text.Json;
using System;
using RubiksWord.Domain.DataTypes;
using System.Text.Json.Serialization;

namespace RubiksWord.API.Mappers;

public class Vector3JsonConverter : JsonConverter<Vector3>
{ 
    public override Vector3 Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        return Vector3.Parse(reader.GetString()!);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Vector3 value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
