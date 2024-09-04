using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Capitals.Commands.Add;

public sealed record AddCapitalCommand(
    string Name,
    float Balance)
    : ICommand;