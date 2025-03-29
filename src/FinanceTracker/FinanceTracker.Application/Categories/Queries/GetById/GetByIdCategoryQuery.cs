using FinanceTracker.Application.Abstractions.Messaging;
using FinanceTracker.Application.Categories.Response;

namespace FinanceTracker.Application.Categories.Queries.GetById;

public sealed record GetByIdCategoryQuery(
    int Id)
    : IQuery<CategoryResponse>;
