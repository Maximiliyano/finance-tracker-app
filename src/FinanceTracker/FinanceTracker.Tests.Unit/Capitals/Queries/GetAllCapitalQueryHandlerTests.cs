using FinanceTracker.Application.Capitals.Queries.GetAll;
using FinanceTracker.Application.Capitals.Responses;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using FluentAssertions.Execution;
using NSubstitute;

namespace FinanceTracker.UnitTests.Capitals.Queries;

public sealed class GetAllCapitalQueryHandlerTests
{
    private readonly ICapitalRepository _repositoryMock = Substitute.For<ICapitalRepository>();

    private readonly GetAllCapitalsQueryHandler _handler;

    public GetAllCapitalQueryHandlerTests()
    {
        _handler = new GetAllCapitalsQueryHandler(_repositoryMock);
    }

    [Fact]
    public async Task Handle_ShouldGetAllExistingCapitals_ReturnsList()
    {
        // Arrange
        const int capitalId = 1;

        var query = new GetAllCapitalsQuery();
        var capitals = new List<Capital> { new(capitalId) };
        var capitalResponses = capitals
            .Select(x => new CapitalResponse(
                x.Id,
                x.Name,
                x.Balance,
                x.Currency.ToString(),
                x.TotalIncome,
                x.TotalExpense,
                x.TotalTransferIn,
                x.TotalTransferOut));

        _repositoryMock.GetAllAsync().Returns(capitals);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(capitalResponses);

            await _repositoryMock.Received(1).GetAllAsync();
        }
    }

    [Fact]
    public async Task Handle_ShouldGetAllCapitals_ReturnsEmptyList()
    {
        // Arrange
        var query = new GetAllCapitalsQuery();
        var capitals = new List<Capital>();
        var capitalResponses = capitals.Select(_ => new CapitalResponse());

        _repositoryMock.GetAllAsync().Returns(capitals);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        using (new AssertionScope())
        {
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().BeEquivalentTo(capitalResponses);

            await _repositoryMock.Received(1).GetAllAsync();
        }
    }
}
