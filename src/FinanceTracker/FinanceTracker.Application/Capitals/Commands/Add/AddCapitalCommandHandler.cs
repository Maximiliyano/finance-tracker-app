using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Commands.Add;

public sealed class AddCapitalCommandHandler(
    ICapitalRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddCapitalCommand>
{
    public async Task<Result> Handle(AddCapitalCommand request, CancellationToken cancellationToken)
    {
        var capital = new Capital(request.Name, request.Balance);

        repository.Add(capital);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}