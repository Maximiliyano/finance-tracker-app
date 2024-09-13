using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Domain.Entities;

namespace FinanceTracker.Application.Exchanges.Commands.AddRange;

public sealed record AddExchangesCommand(
    IEnumerable<ExchangeResponse> Exchanges)
    : ICommand;
