using Deed.Application.Abstractions.Messaging;

namespace Deed.Application.Expenses.Commands.Delete;

public sealed record DeleteExpenseCommand(int Id) : ICommand;
