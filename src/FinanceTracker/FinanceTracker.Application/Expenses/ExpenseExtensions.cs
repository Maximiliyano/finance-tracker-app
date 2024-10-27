using FinanceTracker.Application.Capitals;
using FinanceTracker.Application.Categories;
using FinanceTracker.Application.Expenses.Commands.Create;
using FinanceTracker.Application.Expenses.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Expenses;

internal static class ExpenseExtensions
{
    internal static ExpenseResponse ToResponse(this Expense expense)
        => new(
            expense.Id,
            expense.CapitalId,
            expense.Capital.ToResponse(),
            expense.CategoryId,
            expense.Category.ToResponse(),
            expense.Amount,
            expense.PaymentDate,
            expense.Purpose);

    internal static IEnumerable<ExpenseResponse> ToResponses(this IEnumerable<Expense> expenses)
        => expenses.Select(e => e.ToResponse());

    internal static Expense ToEntity(this CreateExpenseCommand command)
        => new()
        {
            Amount = command.Amount,
            Purpose = command.Purpose,
            CategoryId = command.CategoryId,
            CapitalId = command.CapitalId,
            PaymentDate = command.PaymentDate
        };
}
