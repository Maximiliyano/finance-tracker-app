using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Categories.Response;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Categories.Queries.GetAll;

internal sealed class GetAllCategoryQueryHandler(ICategoryRepository repository)
    : IQueryHandler<GetAllCategoryQuery, IEnumerable<CategoryResponse>>
{
    public async Task<Result<IEnumerable<CategoryResponse>>> Handle(GetAllCategoryQuery query, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync(query.Type);
        var categoryResponses = categories.ToResponses();
        
        return Result.Success(categoryResponses);
    }
}
