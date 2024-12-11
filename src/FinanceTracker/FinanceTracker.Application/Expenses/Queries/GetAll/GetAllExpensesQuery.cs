using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Expenses.Responses;

namespace FinanceTracker.Application.Expenses.Queries.GetAll;

public sealed record GetAllExpensesQuery
    : IQuery<IEnumerable<ExpenseResponse>>;
