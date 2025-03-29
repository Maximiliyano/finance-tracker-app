using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Capitals.Commands.Update;

public sealed record UpdateCapitalCommand(
    int Id,
    string? Name = null,
    float? Balance = null,
    string? Currency = null)
    : ICommand;
