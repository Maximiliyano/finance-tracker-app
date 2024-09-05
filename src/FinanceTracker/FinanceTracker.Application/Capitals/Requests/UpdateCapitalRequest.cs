namespace FinanceTracker.Application.Capitals.Requests;

public sealed record UpdateCapitalRequest(
    int Id,
    string? Name,
    float? Balance);