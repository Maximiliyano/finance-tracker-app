using Deed.Domain.Results;
using MediatR;

namespace Deed.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
