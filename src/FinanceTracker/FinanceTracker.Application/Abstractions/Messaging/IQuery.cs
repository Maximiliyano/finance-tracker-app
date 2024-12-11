using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;