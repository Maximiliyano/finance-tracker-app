using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Abstractions;

internal interface IQuery : IRequest<Result>;

internal interface IQuery<TResponse> : IRequest<Result<TResponse>>;