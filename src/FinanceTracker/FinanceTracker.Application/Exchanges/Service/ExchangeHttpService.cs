using System.Text.Json;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Results;
using Microsoft.Extensions.Options;

namespace FinanceTracker.Application.Exchanges.Service;

public sealed class ExchangeHttpService(
    IOptions<PBApiSettings> options,
    HttpClient client)
    : IExchangeHttpService
{
    private static readonly JsonSerializerOptions CaseInsensitive = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly PBApiSettings _settings = options.Value;

    public async Task<Result<IEnumerable<Exchange>>> GetCurrencyAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_settings.BaseAddress}{_settings.ExchangeQuery}");

        var response = await client.SendAsync(request);

        request.Dispose();

        if (!response.IsSuccessStatusCode)
        {
            return Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.HttpExecution);
        }

        var content = await response.Content.ReadAsStringAsync();

        var exchanges = JsonSerializer.Deserialize<IEnumerable<Exchange>>(content, CaseInsensitive);

        return exchanges is null
            ? Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.Serialization)
            : Result.Success(exchanges);
    }
}