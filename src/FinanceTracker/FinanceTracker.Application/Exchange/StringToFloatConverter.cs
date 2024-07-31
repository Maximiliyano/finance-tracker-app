using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FinanceTracker.Application.Exchange;

public class StringToFloatConverter : JsonConverter<float>
{
    public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && float.TryParse(reader.GetString(), out var value))
        {
            return value;
        }

        throw new JsonException($"Unable to convert \"{reader.GetString()}\" to {typeof(float)}.");
    }

    public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
    {
        var roundedValue = Math.Round(value, 2);

        writer.WriteStringValue(roundedValue.ToString(CultureInfo.InvariantCulture));
    }
}