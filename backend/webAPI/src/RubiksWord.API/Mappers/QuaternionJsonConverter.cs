using System.Text.Json;
using System;
using System.Text.Json.Serialization;
using RubiksWord.Core.DataTypes;

namespace RubiksWord.API.Mappers;

public class QuaternionJsonConverter : JsonConverter<Quaternion>
{
    public override Quaternion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        return Quaternion.Parse(reader.GetString()!);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Quaternion value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
