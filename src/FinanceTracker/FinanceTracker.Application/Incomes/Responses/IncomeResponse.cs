namespace FinanceTracker.Application.Incomes.Responses;

public sealed record IncomeResponse(
    int Id,
    float Amount,
    string Purpose,
    string Type,
    DateTimeOffset CreatedAt,
    int? CapitalId);
