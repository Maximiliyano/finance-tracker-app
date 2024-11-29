using FinanceTracker.Application.Categories.Commands.Update;
using FinanceTracker.Application.Categories.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Categories.Commands;

public sealed class UpdateCategoryQueryHandlerTests
{
    private readonly ICategoryRepository _repositoryMock = Substitute.For<ICategoryRepository>();
    private readonly IUnitOfWork _unitOfWorkMock = Substitute.For<IUnitOfWork>();

    private readonly UpdateCategoryCommandHandler _handler;

    public UpdateCategoryQueryHandlerTests()
    {
        _handler = new UpdateCategoryCommandHandler(_repositoryMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenCategoryNotFound()
    {
        // Arrange
        var command = new UpdateCategoryCommand(1);

        _repositoryMock.GetAsync(Arg.Any<CategoryByIdSpecification>()).Returns((Category)null);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(e => e == DomainErrors.General.NotFound("category"));

        await _repositoryMock.Received(1).GetAsync(Arg.Any<CategoryByIdSpecification>());
        await _unitOfWorkMock.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());

        _repositoryMock.DidNotReceive().Update(Arg.Any<Category>());
    }

    [Fact]
    public async Task Handle_ShouldReturnSuccess_WhenCategoryHaveNothingToUpdate()
    {
        // Arrange
        const int id = 1;

        var category = new Category(id) { Name = "Test", Type = CategoryType.Expenses };
        var command = new UpdateCategoryCommand(id);

        _repositoryMock.GetAsync(Arg.Any<CategoryByIdSpecification>()).Returns(category);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

        await _repositoryMock.Received(1).GetAsync(Arg.Any<CategoryByIdSpecification>());
        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());

        _repositoryMock.Received(1).Update(category);
    }

    [Theory]
    [InlineData("New Category", CategoryType.Expenses, 1.0f, PerPeriodType.Daily)]
    [InlineData(null, CategoryType.Incomes, 1.0f, PerPeriodType.Weekly)]
    [InlineData("New Category", null, 1.0f, PerPeriodType.Daily)]
    [InlineData("New Category", CategoryType.Expenses, null, PerPeriodType.Monthly)]
    [InlineData("New Category", CategoryType.Expenses, null, PerPeriodType.Yearly)]
    [InlineData("New Category", CategoryType.Incomes, 1.0f, null)]
    [InlineData(null, null, null, null)]
    [InlineData("", CategoryType.Incomes, 0f, PerPeriodType.Weekly)]
    [InlineData("New Category", CategoryType.Expenses, -10.0f, PerPeriodType.Monthly)]
    [InlineData("New Category", CategoryType.Expenses, -10.0f, PerPeriodType.Yearly)]

    public async Task Handle_ShouldUpdateCategorySuccessfully(
        string? name,
        CategoryType? type,
        float? plannedPeriodAmount,
        PerPeriodType? perPeriodType)
    {
        // Arrange
        const int id = 1;
        const string oldName = "Old Category";
        const CategoryType oldType = CategoryType.Expenses;
        const float oldPlannedPeriodAmount = 1.2f;
        const PerPeriodType oldPerPeriodType = PerPeriodType.Daily;

        var category = new Category(id)
        {
            Name = oldName,
            Type = oldType,
            PlannedPeriodAmount = oldPlannedPeriodAmount,
            Period = oldPerPeriodType
        };

        var command = new UpdateCategoryCommand(id, name, plannedPeriodAmount, perPeriodType, type);

        _repositoryMock.GetAsync(Arg.Any<CategoryByIdSpecification>()).Returns(category);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

        category.Name.Should().Be(name ?? oldName);
        category.Type.Should().Be(type ?? oldType);
        category.Period.Should().Be(perPeriodType ?? oldPerPeriodType);
        category.PlannedPeriodAmount.Should().Be(plannedPeriodAmount ?? oldPlannedPeriodAmount);

        await _repositoryMock.Received(1).GetAsync(Arg.Any<CategoryByIdSpecification>());
        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());

        _repositoryMock.Received(1).Update(category);
    }
}
