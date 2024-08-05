using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Abstractions;

internal interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand;

internal interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>;