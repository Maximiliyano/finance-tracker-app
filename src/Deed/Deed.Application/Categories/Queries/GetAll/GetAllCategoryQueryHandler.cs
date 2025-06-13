using Deed.Application.Abstractions.Messaging;
using Deed.Application.Categories.Response;
using Deed.Domain.Repositories;
using Deed.Domain.Results;

namespace Deed.Application.Categories.Queries.GetAll;

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
