using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals;

internal sealed class CreateCapitalCommandHandler : ICommandHandler<CreateCapitalCommand>
{
    public Task<Result> Handle(CreateCapitalCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}