using Deed.Domain.Results;
using MediatR;

namespace Deed.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TValue> : IRequest<Result<TValue>>;
