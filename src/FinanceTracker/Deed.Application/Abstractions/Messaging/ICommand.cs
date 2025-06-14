using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TValue> : IRequest<Result<TValue>>;