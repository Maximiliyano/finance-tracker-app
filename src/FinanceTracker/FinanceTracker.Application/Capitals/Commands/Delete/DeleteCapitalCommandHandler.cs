using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Commands.Delete;

internal sealed class DeleteCapitalCommandHandler(ICapitalRepository repository)
    : ICommandHandler<DeleteCapitalCommand>
{
    public async Task<Result> Handle(DeleteCapitalCommand request, CancellationToken cancellationToken)
    {
        var removed = await repository.DeleteAsync(request.Id) == 1;

        return removed is false
            ? Result.Failure(DomainErrors.Capital.NotFound)
            : Result.Success();
    }
}