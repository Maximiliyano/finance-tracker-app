using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Abstractions;

public interface ICommand : IRequest<Result>;

public interface ICommand<TValue> : IRequest<Result<TValue>>;