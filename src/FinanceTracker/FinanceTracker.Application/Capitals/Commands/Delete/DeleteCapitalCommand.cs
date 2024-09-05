using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Capitals.Commands.Delete;

public sealed record DeleteCapitalCommand(int Id) : ICommand;