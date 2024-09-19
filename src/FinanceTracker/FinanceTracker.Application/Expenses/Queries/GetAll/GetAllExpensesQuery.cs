using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Responses;

namespace FinanceTracker.Application.Expenses.Queries.GetAll;

public sealed record GetAllExpensesQuery(
    int? Id)
    : IQuery<IEnumerable<ExpenseResponse>>;
