using System.Text.Json.Serialization;

namespace Deed.Application.Exchanges.Responses;

public class ExchangeRateData
{
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("bank")]
    public string Bank { get; set; }

    [JsonPropertyName("baseCurrency")]
    public int BaseCurrency { get; set; }

    [JsonPropertyName("baseCurrencyLit")]
    public string BaseCurrencyLit { get; set; }

    [JsonPropertyName("exchangeRate")]
    public IEnumerable<ExchangeRate> ExchangeRates { get; set; }
}

public class ExchangeRate
{
    [JsonPropertyName("baseCurrency")]
    public string BaseCurrency { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("saleRateNB")]
    public decimal SaleRateNB { get; set; }

    [JsonPropertyName("purchaseRateNB")]
    public decimal PurchaseRateNB { get; set; }

    [JsonPropertyName("saleRate")]
    public decimal? SaleRate { get; set; }

    [JsonPropertyName("purchaseRate")]
    public decimal? PurchaseRate { get; set; }
}
