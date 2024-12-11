using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Exchanges.Responses;

namespace FinanceTracker.Application.Exchanges.Queries.GetAll;

public sealed record GetAllExchangeQuery : IQuery<IEnumerable<ExchangeResponse>>;