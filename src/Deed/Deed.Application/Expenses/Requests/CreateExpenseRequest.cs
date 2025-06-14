namespace Deed.Application.Expenses.Requests;

public sealed record CreateExpenseRequest(
    int CapitalId,
    int CategoryId,
    float Amount,
    DateTimeOffset PaymentDate,
    string? Purpose);
