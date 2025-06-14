namespace FinanceTracker.Application.Incomes.Responses;

public sealed record IncomeResponse(
    int Id,
    int CategoryId,
    float Amount,
    string? Purpose,
    DateTimeOffset CreatedAt,
    int? CapitalId);
