namespace Deed.Application.Incomes.Requests;

public sealed record CreateIncomeRequest(
    int CapitalId,
    int CategoryId,
    float Amount,
    DateTimeOffset PaymentDate,
    string? Purpose);
