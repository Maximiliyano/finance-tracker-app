using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Abstractions;

internal interface ICommand : IRequest<Result>;

internal interface ICommand<TResponse> : IRequest<Result<TResponse>>;