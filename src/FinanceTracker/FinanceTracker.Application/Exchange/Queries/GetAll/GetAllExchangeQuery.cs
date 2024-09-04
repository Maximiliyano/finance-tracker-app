using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Exchange.Queries.GetAll;

public sealed record GetAllExchangeQuery() : IQuery<IEnumerable<Exchange>>;