using System.Globalization;
using System.Text.Json;
using Deed.Application.Exchanges.Responses;
using Deed.Domain.Entities;
using Deed.Domain.Errors;
using Deed.Domain.Providers;
using Deed.Domain.Results;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Deed.Application.Exchanges.Service;

public sealed class ExchangeHttpService(
    IDateTimeProvider dateTimeProvider,
    ILogger<ExchangeHttpService> logger,
    IOptions<PBApiSettings> options,
    HttpClient client)
    : IExchangeHttpService
{
    private static readonly JsonSerializerOptions CaseInsensitive = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly PBApiSettings _settings = options.Value;

    private const string LogMessage = "Error getting currencies with reason: {Message}";

    public async Task<Result<IEnumerable<Exchange>>> GetCurrencyAsync()
    {
        try
        {
            logger.LogInformation("Start getting currencies");
            using var request = new HttpRequestMessage(HttpMethod.Get, string.Format(CultureInfo.CurrentCulture, _settings.ExchangeRateRoute, $"{dateTimeProvider.UtcNow.Day:D2}.{dateTimeProvider.UtcNow.Month:D2}.{dateTimeProvider.UtcNow.Year}"));

            logger.LogInformation("Sending request to Privat24API");
            using var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                logger.LogWarning(LogMessage, response.ReasonPhrase);
                return Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.HttpExecution);
            }

            var content = await response.Content.ReadAsStringAsync();

            logger.LogInformation("Deserializing a response from the content: {Content}", content);
            var exchanges = JsonSerializer.Deserialize<ExchangeRateData>(content, CaseInsensitive);

            if (exchanges is null)
            {
                logger.LogWarning(LogMessage, DomainErrors.Exchange.Serialization);
                return Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.Serialization);
            }

            var newExchanges = exchanges.ExchangeRates
                .Select(x => new Exchange
                {
                    NationalCurrencyCode = x.BaseCurrency,
                    TargetCurrencyCode = x.Currency,
                    Buy = x.PurchaseRate.HasValue ? (float)x.PurchaseRate.Value : (float)x.PurchaseRateNB,
                    Sale = x.SaleRate.HasValue ? (float)x.SaleRate : (float)x.SaleRateNB,
                    CreatedAt = dateTimeProvider.UtcNow
                });

            logger.LogInformation("Currencies successfully retrieved.");
            return Result.Success(newExchanges);
        }
        catch (Exception e)
        {
            logger.LogWarning(e, LogMessage, e.Message);
            return Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.HttpExecution);
        }
    }
}
