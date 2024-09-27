using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Incomes.Requests;

public sealed record UpdateIncomeRequest(
    int Id,
    float Amount,
    string Purpose,
    IncomeType Type);
