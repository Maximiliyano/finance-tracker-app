using FinanceTracker.Application.Abstractions;

namespace FinanceTracker.Application.Expenses.Commands.Delete;

public sealed record DeleteExpenseCommand(int Id) : ICommand;
