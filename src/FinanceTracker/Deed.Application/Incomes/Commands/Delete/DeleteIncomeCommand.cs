using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Incomes.Commands.Delete;

public sealed record DeleteIncomeCommand(int Id) : ICommand;
