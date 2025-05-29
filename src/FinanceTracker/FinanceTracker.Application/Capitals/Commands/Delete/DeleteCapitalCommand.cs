using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Capitals.Commands.Delete;

public sealed record DeleteCapitalCommand(
    int Id)
    : ICommand;
