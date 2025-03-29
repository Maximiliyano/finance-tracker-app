using FinanceTracker.Application.Abstractions.Messaging;

namespace FinanceTracker.Application.Expenses.Commands.Delete;

public sealed record DeleteExpenseCommand(int Id) : ICommand;
