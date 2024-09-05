namespace FinanceTracker.Application.Capitals.Responses;

public sealed record CapitalResponse(
    int Id,
    string Name,
    float Balance);