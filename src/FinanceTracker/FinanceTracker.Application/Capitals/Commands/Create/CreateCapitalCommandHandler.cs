using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Commands.Create;

internal sealed class CreateCapitalCommandHandler(
    ICapitalRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCapitalCommand, int>
{
    public async Task<Result<int>> Handle(CreateCapitalCommand command, CancellationToken cancellationToken)
    {
        var capital = command.ToEntity();

        repository.Create(capital);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success(capital.Id);
    }
}
