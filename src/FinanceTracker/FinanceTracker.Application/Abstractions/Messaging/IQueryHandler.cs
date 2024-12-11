using FinanceTracker.Domain.Results;
using MediatR;

namespace FinanceTracker.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>;