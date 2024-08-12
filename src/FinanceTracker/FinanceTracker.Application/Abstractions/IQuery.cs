using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;