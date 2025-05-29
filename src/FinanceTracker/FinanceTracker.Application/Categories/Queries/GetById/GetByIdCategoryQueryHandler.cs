using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Categories.Response;
using FinanceTracker.Application.Categories.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Categories.Queries.GetById;

internal sealed class GetByIdCategoryQueryHandler(
    ICategoryRepository repository)
    : IQueryHandler<GetByIdCategoryQuery, CategoryResponse>
{
    public async Task<Result<CategoryResponse>> Handle(GetByIdCategoryQuery query, CancellationToken cancellationToken)
    {
        var category = await repository.GetAsync(new CategoryByIdSpecification(query.Id));

        if (category is null)
        {
            return Result.Failure<CategoryResponse>(DomainErrors.General.NotFound(nameof(category)));
        }

        return Result.Success(category.ToResponse());
    }
}
