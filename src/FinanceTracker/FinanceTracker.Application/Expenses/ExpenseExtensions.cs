using FinanceTracker.Application.Exchanges;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Application.Expenses.Commands.Create;
using FinanceTracker.Application.Expenses.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Expenses;

internal static class ExpenseExtensions
{
    internal static ExpenseResponse ToResponse(this Expense expense)
        => new(
            expense.CapitalId,
            expense.Amount,
            expense.Purpose,
            expense.Type);

    internal static IEnumerable<ExpenseResponse> ToResponses(this IEnumerable<Expense> expenses)
        => expenses.Select(e => e.ToResponse());

    internal static Expense ToEntity(this CreateExpenseCommand command)
        => new()
        {
            Amount = command.Amount,
            Purpose = command.Purpose,
            Type = command.Type,
            CapitalId = command.CapitalId
        };
}
