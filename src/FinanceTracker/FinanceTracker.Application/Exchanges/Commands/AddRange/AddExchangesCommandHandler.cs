using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Exchanges.Commands.AddRange;

internal sealed class AddExchangesCommandHandler(
    IExchangeRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<AddExchangesCommand>
{
    public async Task<Result> Handle(AddExchangesCommand command, CancellationToken cancellationToken)
    {
        var exchanges = command.Exchanges.ToEntities();
        
        repository.AddRange(exchanges);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
