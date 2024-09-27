using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Incomes.Responses;

namespace FinanceTracker.Application.Incomes.Queries.GetAll;

public sealed record GetIncomesQuery
    : IQuery<IEnumerable<IncomeResponse>>;
