namespace FinanceTracker.Application.Exchange;

public sealed class PBApiSettings
{
    public required string BaseAddress { get; init; }

    public required string ExchangeQuery { get; init; }
}