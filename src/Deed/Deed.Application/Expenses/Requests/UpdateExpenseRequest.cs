namespace Deed.Application.Expenses.Requests;

public sealed record UpdateExpenseRequest(
    int Id,
    int? CategoryId,
    float? Amount,
    string? Purpose,
    DateTimeOffset? Date);
