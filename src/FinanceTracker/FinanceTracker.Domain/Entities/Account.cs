namespace FinanceTracker.Domain.Entities;

public sealed class Account : AuditableEntity, ISoftDeletableEntity
{
    public required string Name { get; init; }

    public required int TotalIncome { get; init; }

    public required int TotalExpense { get; init; }

    public required int TotalTransferIn { get; init; }

    public required int TotalTransferOut { get; init; }

    public required DateTimeOffset DeletedAt { get; init; }

    public required bool IsDeleted { get; init; }

    public IEnumerable<Income>? Incomes { get; init; }

    public IEnumerable<Expense>? Expenses { get; init; }

    public IEnumerable<Transfer>? Transfers { get; init; }
}
