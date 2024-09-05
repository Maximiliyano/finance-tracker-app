using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Capitals.Commands.Create;

public sealed record CreateCapitalCommand(
    string Name,
    float Balance)
    : ICommand<int>;