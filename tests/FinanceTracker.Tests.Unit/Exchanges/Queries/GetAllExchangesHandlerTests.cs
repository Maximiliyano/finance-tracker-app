using FinanceTracker.Application.Exchanges;
using FinanceTracker.Application.Exchanges.Queries.GetAll;
using FinanceTracker.Application.Exchanges.Service;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Results;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Exchanges.Queries;

public sealed class GetAllExchangesHandlerTests
{
    private readonly IExchangeHttpService _exchangeHttpServiceMock = Substitute.For<IExchangeHttpService>();

    private readonly GetAllExchangeQueryHandler _handler;

    public GetAllExchangesHandlerTests()
    {
        _handler = new GetAllExchangeQueryHandler(_exchangeHttpServiceMock);
    }

    [Fact]
    public async Task Handle_GetAllExchanges_ShouldReturnAll()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;
        var exchange = new Exchange(1)
        {
            NationalCurrencyCode = CurrencyType.UAH.ToString(),
            TargetCurrencyCode = CurrencyType.USD.ToString(),
            Buy = 46f,
            Sale = 45f
        };
        var exchanges = new List<Exchange> { exchange };
        var command = new GetAllExchangeQuery();

        _exchangeHttpServiceMock.GetCurrencyAsync().Returns(exchanges);

        var responses = exchanges.ToResponses();

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

        result.Value.Should().BeEquivalentTo(responses, o => o
            .Excluding(e => e.UpdatedAt));

        result.Value.First().UpdatedAt.Should().BeCloseTo(utcNow, TimeSpan.FromSeconds(1));

        await _exchangeHttpServiceMock.Received(1).GetCurrencyAsync();
    }

    [Fact]
    public async Task Handle_GetAllExchangesWhenServiceFails_ShouldReturnFailureHttpExecution()
    {
        // Arrange
        var query = new GetAllExchangeQuery();

        _exchangeHttpServiceMock.GetCurrencyAsync().Returns(Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.HttpExecution));

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(e => e == DomainErrors.Exchange.HttpExecution);

        await _exchangeHttpServiceMock.Received(1).GetCurrencyAsync();
    }

    [Fact]
    public async Task Handle_GetAllExchangesWhenServiceFails_ShouldReturnFailureSerialization()
    {
        // Arrange
        var query = new GetAllExchangeQuery();

        _exchangeHttpServiceMock.GetCurrencyAsync().Returns(Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.Serialization));

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(e => e == DomainErrors.Exchange.Serialization);

        await _exchangeHttpServiceMock.Received(1).GetCurrencyAsync();
    }
}
