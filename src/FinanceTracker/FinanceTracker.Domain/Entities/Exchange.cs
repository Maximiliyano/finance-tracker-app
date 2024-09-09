using System.Text.Json.Serialization;
using FinanceTracker.Domain.Conventers;

namespace FinanceTracker.Domain.Entities;

public sealed class Exchange(
    string nationalCurrencyCode,
    string targetCurrencyCode,
    float buy,
    float sale)
{
    [JsonPropertyName("base_ccy")]
    public string NationalCurrencyCode { get; } = nationalCurrencyCode;

    [JsonPropertyName("ccy")]
    public string TargetCurrencyCode { get; } = targetCurrencyCode;

    [JsonConverter(typeof(StringToFloatConverter))]
    public float Buy { get; } = buy;

    [JsonConverter(typeof(StringToFloatConverter))]
    public float Sale { get; } = sale;
}
