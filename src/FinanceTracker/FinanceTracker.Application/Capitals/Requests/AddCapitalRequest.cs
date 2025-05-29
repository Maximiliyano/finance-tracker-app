using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Application.Capitals.Requests;

public sealed record AddCapitalRequest(
    string Name,
    float Balance,
    CurrencyType Currency);
