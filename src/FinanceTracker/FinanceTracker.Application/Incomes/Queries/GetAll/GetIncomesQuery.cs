using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Incomes.Responses;

namespace FinanceTracker.Application.Incomes.Queries.GetAll;

public sealed record GetIncomesQuery
    : IQuery<IEnumerable<IncomeResponse>>;
