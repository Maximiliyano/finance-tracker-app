using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Responses;

namespace FinanceTracker.Application.Expenses.Queries.GetById;

public sealed record GetExpenseByIdQuery(int Id) : IQuery<ExpenseResponse>;
