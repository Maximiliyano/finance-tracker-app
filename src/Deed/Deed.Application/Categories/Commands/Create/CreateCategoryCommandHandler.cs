using Deed.Application.Abstractions.Messaging;
using Deed.Domain.Repositories;
using Deed.Domain.Results;

namespace Deed.Application.Categories.Commands.Create;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, int>
{
    public async Task<Result<int>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = command.ToEntity();

        repository.Create(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
