using FinanceTracker.Application.Abstractions;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Categories.Commands.Create;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository repository,
    IUnitOfWork unitOfWork)
    : ICommandHandler<CreateCategoryCommand, int>
{
    public async Task<Result<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name,
            Type = request.Type,
            Period = request.Period,
            PlannedPeriodAmount = request.PlannedPeriodAmount
        };
        
        repository.Create(category);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
