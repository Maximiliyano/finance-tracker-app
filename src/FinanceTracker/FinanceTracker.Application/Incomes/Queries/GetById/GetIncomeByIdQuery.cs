using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Incomes.Responses;

namespace FinanceTracker.Application.Incomes.Queries.GetById;

public sealed record GetIncomeByIdQuery(int Id)
    : IQuery<IncomeResponse>;
