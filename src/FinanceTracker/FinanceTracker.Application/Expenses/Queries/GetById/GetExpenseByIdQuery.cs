using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Expenses.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Expenses.Queries.GetById;

public sealed record GetExpenseByIdQuery(int Id) : IQuery<IEnumerable<ExpenseResponse>>;