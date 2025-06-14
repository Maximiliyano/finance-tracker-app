using Deed.Application.Abstractions.Messaging;
using Deed.Application.Expenses.Responses;

namespace Deed.Application.Expenses.Queries.GetById;

public sealed record GetExpenseByIdQuery(
    int Id)
    : IQuery<ExpenseResponse>;
