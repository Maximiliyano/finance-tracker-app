using FinanceTracker.Application.Expenses;
using FinanceTracker.Application.Expenses.Queries.GetAll;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Expenses.Queries;

public sealed class GetAllExpensesQueryHandlerTests
{
    private readonly IExpenseRepository _expenseRepositoryMock = Substitute.For<IExpenseRepository>();

    private readonly GetAllExpensesQueryHandler _handler;

    public GetAllExpensesQueryHandlerTests()
    {
        _handler = new GetAllExpensesQueryHandler(_expenseRepositoryMock);
    }

    [Fact]
    public async Task Handle_GetAllExpenses_ShouldReturnAll()
    {
        // Arrange
        var entity = new Expense
        {
            Amount = 1,
            PaymentDate = DateTimeOffset.UtcNow,
            CategoryId = 1,
            Category = new Category
            {
                Name = "TestCategory",
                Type = CategoryType.Expenses
            },
            CapitalId = 1,
            Capital = new Capital
            {
                Name = "TestCapital",
                Balance = 0,
                Currency = CurrencyType.UAH
            }
        };
        var entities = new List<Expense> { entity };
        var query = new GetAllExpensesQuery();

        _expenseRepositoryMock.GetAllAsync().Returns(entities);

        var response = entity.ToResponse();

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().OnlyContain(x => x == response);
    }
}
