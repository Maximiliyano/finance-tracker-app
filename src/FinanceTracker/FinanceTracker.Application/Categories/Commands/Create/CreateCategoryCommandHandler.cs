using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Categories.Commands.Create;

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
