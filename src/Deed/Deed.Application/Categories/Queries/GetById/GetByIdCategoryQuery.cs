using Deed.Application.Abstractions.Messaging;
using Deed.Application.Categories.Response;

namespace Deed.Application.Categories.Queries.GetById;

public sealed record GetByIdCategoryQuery(
    int Id)
    : IQuery<CategoryResponse>;
