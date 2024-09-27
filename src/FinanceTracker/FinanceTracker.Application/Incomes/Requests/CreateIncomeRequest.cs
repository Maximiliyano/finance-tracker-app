using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Incomes.Requests;

public sealed record CreateIncomeRequest(
    int CapitalId,
    float Amount,
    string Purpose,
    IncomeType Type);
