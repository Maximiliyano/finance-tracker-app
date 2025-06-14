namespace Deed.Application.Incomes.Requests;

public sealed record UpdateIncomeRequest(
    int Id,
    int? CategoryId,
    float? Amount,
    string? Purpose,
    DateTimeOffset? PaymentDate);
