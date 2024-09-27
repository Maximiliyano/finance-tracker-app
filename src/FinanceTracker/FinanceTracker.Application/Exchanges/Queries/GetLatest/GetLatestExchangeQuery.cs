using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Exchanges.Responses;

namespace FinanceTracker.Application.Exchanges.Queries.GetLatest;

public sealed record GetLatestExchangeQuery : IQuery<IEnumerable<ExchangeResponse>>;
