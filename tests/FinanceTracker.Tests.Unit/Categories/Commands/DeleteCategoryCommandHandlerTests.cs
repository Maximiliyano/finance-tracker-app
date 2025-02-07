using FinanceTracker.Application.Categories.Commands.Delete;
using FinanceTracker.Application.Categories.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Categories.Commands;

public sealed class DeleteCategoryCommandHandlerTests
{
    private readonly ICategoryRepository _repositoryMock = Substitute.For<ICategoryRepository>();
    private readonly IUnitOfWork _unitOfWorkMock = Substitute.For<IUnitOfWork>();

    private readonly DeleteCategoryCommandHandler _handler;

    public DeleteCategoryCommandHandlerTests()
    {
        _handler = new DeleteCategoryCommandHandler(_repositoryMock, _unitOfWorkMock);
    }

    [Theory]
    [InlineData(CategoryType.Incomes, "IncomesWithHighAmountOfDollars", 0f, PerPeriodType.None)]
    [InlineData(CategoryType.Expenses, "E", 100f, PerPeriodType.Daily)]
    public async Task Handle_ShouldDeleteCategory_ReturnSuccess(
        CategoryType type,
        string name,
        float periodAmount,
        PerPeriodType periodType)
    {
        // Arrange
        var category = new Category(1)
        {
            Name = name,
            Type = type,
            PlannedPeriodAmount = periodAmount,
            Period = periodType
        };
        var command = new DeleteCategoryCommand(1);

        _repositoryMock.GetAsync(Arg.Any<CategoryByIdSpecification>())
            .Returns(category);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

        _repositoryMock.Received(1).Delete(category);

        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldDeleteNotFoundCategory_ReturnFailure()
    {
        // Arrange
        var command = new DeleteCategoryCommand(1);

        _repositoryMock.GetAsync(Arg.Any<CategoryByIdSpecification>())
            .Returns((Category)null);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(x => x == DomainErrors.General.NotFound("category"));

        _repositoryMock.Received(0).Delete(Arg.Any<Category>());

        await _unitOfWorkMock.Received(0).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
