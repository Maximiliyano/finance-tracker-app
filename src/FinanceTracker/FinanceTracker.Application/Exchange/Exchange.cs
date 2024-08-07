using System.Text.Json.Serialization;

namespace FinanceTracker.Application.Exchange;

public sealed class Exchange(
    string currencyCode,
    string nationalCurrencyCode,
    float buy,
    float sale)
{
    [JsonPropertyName("base_ccy")]
    public string CurrencyCode { get; } = currencyCode;

    [JsonPropertyName("ccy")]
    public string NationalCurrencyCode { get; } = nationalCurrencyCode;

    [JsonConverter(typeof(StringToFloatConverter))]
    public float Buy { get; } = buy;

    [JsonConverter(typeof(StringToFloatConverter))]
    public float Sale { get; } = sale;
}