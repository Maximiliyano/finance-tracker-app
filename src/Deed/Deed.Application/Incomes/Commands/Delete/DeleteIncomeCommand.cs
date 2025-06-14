using Deed.Application.Abstractions.Messaging;

namespace Deed.Application.Incomes.Commands.Delete;

public sealed record DeleteIncomeCommand(int Id) : ICommand;
