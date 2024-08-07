namespace FinanceTracker.Application.Abstractions;

public sealed class WebUISettings
{
    public required string BaseAddress { get; init; }

    public required string LocalAddress { get; init; }
}