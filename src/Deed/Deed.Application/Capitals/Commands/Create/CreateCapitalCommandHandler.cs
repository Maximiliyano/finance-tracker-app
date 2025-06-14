using Deed.Application.Abstractions.Messaging;
using Deed.Domain.Repositories;
using Deed.Domain.Results;

namespace Deed.Application.Capitals.Commands.Create;

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
