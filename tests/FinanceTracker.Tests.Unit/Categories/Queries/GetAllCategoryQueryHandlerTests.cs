using FinanceTracker.Application.Categories.Queries.GetAll;
using FinanceTracker.Application.Categories.Response;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Categories.Queries;

public sealed class GetAllCategoryQueryHandlerTests
{
    private readonly ICategoryRepository _repositoryMock = Substitute.For<ICategoryRepository>();

    private readonly GetAllCategoryQueryHandler _handler;

    public GetAllCategoryQueryHandlerTests()
    {
        _handler = new GetAllCategoryQueryHandler(_repositoryMock);
    }

    [InlineData(CategoryType.Expenses)]
    [InlineData(CategoryType.Incomes)]
    [InlineData(null)]
    [Theory]
    public async Task Handle_ShouldGetAllExistingCategories_ReturnsList(CategoryType? type)
    {
        // Arrange
        var query = new GetAllCategoryQuery(type);
        var categories = new List<Category>
        {
            new()
            {
                Name = "Category",
                Type = type ?? CategoryType.Expenses
            }
        };
        var responses = categories.Select(x =>
            new CategoryResponse(x.Id, x.Name, x.Type, x.Period, x.PlannedPeriodAmount));

        _repositoryMock.GetAllAsync(type).Returns(categories);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(responses);

        await _repositoryMock.Received(1).GetAllAsync(type);
    }

    [Fact]
    public async Task Handle_ShouldGetAllCategories_ReturnsEmptyList()
    {
        // Arrange
        var query = new GetAllCategoryQuery();

        _repositoryMock.GetAllAsync(null).Returns([]);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(Enumerable.Empty<CategoryResponse>());

        await _repositoryMock.Received(1).GetAllAsync(null);
    }
}
