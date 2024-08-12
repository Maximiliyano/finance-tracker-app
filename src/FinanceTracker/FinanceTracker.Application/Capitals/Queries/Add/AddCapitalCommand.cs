using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Capitals.Queries.Add;

public sealed record AddCapitalCommand(
    string Name,
    float Balance)
    : ICommand;