using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Commands.Create;

internal sealed class CreateCapitalCommandHandler(
    ICapitalRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCapitalCommand, int>
{
    public async Task<Result<int>> Handle(CreateCapitalCommand request, CancellationToken cancellationToken)
    {
        var capital = new Capital
        {
            Name = request.Name,
            Balance = request.Balance
        };

        repository.Create(capital);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(capital.Id);
    }
}