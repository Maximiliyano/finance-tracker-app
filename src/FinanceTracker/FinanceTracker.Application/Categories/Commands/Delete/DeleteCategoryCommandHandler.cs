using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Categories.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Categories.Commands.Delete;

internal sealed class DeleteCategoryCommandHandler(
    ICategoryRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteCategoryCommand>
{
    public async Task<Result> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await repository.GetAsync(new CategoryByIdSpecification(command.Id));

        if (category is null)
        {
            return Result.Failure(DomainErrors.General.NotFound(nameof(category)));
        }

        repository.Delete(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
