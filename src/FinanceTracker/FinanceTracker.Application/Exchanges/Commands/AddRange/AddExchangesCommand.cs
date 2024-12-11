using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Exchanges.Responses;

namespace FinanceTracker.Application.Exchanges.Commands.AddRange;

public sealed record AddExchangesCommand(
    IEnumerable<ExchangeResponse> Exchanges)
    : ICommand;
