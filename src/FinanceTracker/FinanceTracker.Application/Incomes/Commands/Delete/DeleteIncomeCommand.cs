using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Incomes.Commands.Delete;

public sealed record DeleteIncomeCommand(int Id) : ICommand;
