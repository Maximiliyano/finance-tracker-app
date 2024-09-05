using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Exchanges.Queries.GetAll;

public sealed record GetAllExchangeQuery : IQuery<IEnumerable<ExchangeResponse>>;