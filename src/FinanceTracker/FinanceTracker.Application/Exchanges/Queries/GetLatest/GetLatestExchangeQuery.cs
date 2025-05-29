using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Exchanges.Responses;

namespace FinanceTracker.Application.Exchanges.Queries.GetLatest;

public sealed record GetLatestExchangeQuery : IQuery<IEnumerable<ExchangeResponse>>;
