using FinanceTracker.Application.Capitals.Queries.GetById;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Capitals.Queries;

public sealed class GetByIdCapitalQueryHandlerTests
{
    private readonly ICapitalRepository _repositoryMock = Substitute.For<ICapitalRepository>();

    private readonly GetByIdCapitalQueryHandler _handler;

    public GetByIdCapitalQueryHandlerTests()
    {
        _handler = new GetByIdCapitalQueryHandler(_repositoryMock);
    }

    [Fact]
    public async Task Handle_ShouldReturnCapital_WhenCapitalExists()
    {
        // Arrange
        const int id = 1;

        var capital = new Capital(id) { Name = "New Capital", Balance = 100, Currency = CurrencyType.UAH };
        var query = new GetByIdCapitalQuery(id);

        _repositoryMock.GetAsync(Arg.Any<CapitalByIdSpecification>()).Returns(capital);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

        result.Value.Id.Should().Be(id);
        result.Value.Name.Should().Be(capital.Name);
        result.Value.Balance.Should().Be(capital.Balance);
        result.Value.Currency.Should().Be(capital.Currency.ToString());

        await _repositoryMock.Received(1).GetAsync(Arg.Any<CapitalByIdSpecification>());
    }

    [Fact]
    public async Task Handle_ShouldReturnNotFound_WhenCapitalNotFound()
    {
        // Arrange
        _repositoryMock.GetAsync(Arg.Any<CapitalByIdSpecification>())
                       .Returns((Capital)null);

        var query = new GetByIdCapitalQuery(-1);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(e => e == DomainErrors.General.NotFound("capital"));

        await _repositoryMock.Received(1).GetAsync(Arg.Any<CapitalByIdSpecification>());
    }
}
