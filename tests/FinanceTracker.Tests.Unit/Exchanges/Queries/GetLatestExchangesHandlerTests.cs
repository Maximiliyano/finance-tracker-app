using FinanceTracker.Application.Exchanges;
using FinanceTracker.Application.Exchanges.Queries.GetLatest;
using FinanceTracker.Application.Exchanges.Service;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Providers;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Exchanges.Queries;

public sealed class GetLatestExchangesHandlerTests
{
    private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();
    private readonly IExchangeHttpService _serviceMock = Substitute.For<IExchangeHttpService>();
    private readonly IExchangeRepository _repositoryMock = Substitute.For<IExchangeRepository>();
    private readonly IUnitOfWork _unitOfWorkMock = Substitute.For<IUnitOfWork>();

    private readonly GetLatestExchangeQueryHandler _handler;

    public GetLatestExchangesHandlerTests()
    {
        _handler = new GetLatestExchangeQueryHandler(_dateTimeProvider, _serviceMock, _repositoryMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_GetLatestExchanges_ShouldReturnEmpty()
    {
        // Arrange
        var query = new GetLatestExchangeQuery();

        _serviceMock.GetCurrencyAsync().Returns(Result.Success<IEnumerable<Exchange>>([]));
        _repositoryMock.GetAllAsync().Returns([]);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEmpty();
    }

    [Fact]
    public async Task Handle_ShouldReturnExchangesCreatedToday_WhenGetLatest()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;
        var exchanges = new List<Exchange>
        {
            new()
            {
                NationalCurrencyCode = "",
                TargetCurrencyCode = "",
                Buy = 0,
                Sale = 0,
                CreatedAt = utcNow
            },
            new()
            {
                NationalCurrencyCode = "",
                TargetCurrencyCode = "",
                Buy = 0,
                Sale = 0,
                CreatedAt = utcNow
            }
        };
        var responses = exchanges.ToResponses();
        var query = new GetLatestExchangeQuery();

        _repositoryMock.GetAllAsync().Returns(exchanges);
        _dateTimeProvider.UtcNow.Returns(utcNow);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(responses);

        _repositoryMock.DidNotReceive().RemoveRange(Arg.Any<IEnumerable<Exchange>>());
        _repositoryMock.DidNotReceive().AddRange(Arg.Any<IEnumerable<Exchange>>());

        await _unitOfWorkMock.DidNotReceive().SaveChangesAsync();
        await _serviceMock.DidNotReceive().GetCurrencyAsync();
    }

    [Fact]
    public async Task Handle_ShouldReturnExchangesCreatedDayBefore_WhenGetLatest()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;
        var utcPast = utcNow.AddDays(-1);
        var exchanges = new List<Exchange>
        {
            new()
            {
                NationalCurrencyCode = "Old",
                TargetCurrencyCode = "Old",
                Buy = 2,
                Sale = 3,
                CreatedAt = utcPast
            },
            new()
            {
                NationalCurrencyCode = "Old",
                TargetCurrencyCode = "Old",
                Buy = 1,
                Sale = 4,
                CreatedAt = utcPast
            }
        };
        var newExchanges = new List<Exchange>
        {
            new()
            {
                NationalCurrencyCode = "",
                TargetCurrencyCode = "",
                Buy = 0,
                Sale = 0,
                CreatedAt = utcNow
            },
            new()
            {
                NationalCurrencyCode = "",
                TargetCurrencyCode = "",
                Buy = 0,
                Sale = 0,
                CreatedAt = utcNow
            }
        };
        var responses = newExchanges.ToResponses();
        var query = new GetLatestExchangeQuery();

        _repositoryMock.GetAllAsync().Returns(exchanges);
        _serviceMock.GetCurrencyAsync().Returns(newExchanges);
        _dateTimeProvider.UtcNow.Returns(utcNow);

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(responses);

        _repositoryMock.Received(1).RemoveRange(exchanges);
        _repositoryMock.Received(1).AddRange(Arg.Is<IEnumerable<Exchange>>(x => x.Any(c => c.CreatedAt == utcNow)));

        await _unitOfWorkMock.Received(1).SaveChangesAsync();
        await _serviceMock.Received(1).GetCurrencyAsync();
    }

    [Fact]
    public async Task Handle_GetLatestExchanges_ShouldReturnLatest()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;
        var exchange = new Exchange
        {
            NationalCurrencyCode = "UAH",
            TargetCurrencyCode = "USD",
            Buy = 40.1f,
            Sale = 39.9f
        };
        var exchanges = new List<Exchange> { exchange };
        var query = new GetLatestExchangeQuery();

        _repositoryMock.GetAllAsync().Returns(exchanges);

        var responses = exchanges.ToResponses();

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(responses, o => o
            .Excluding(e => e.UpdatedAt));

        result.Value.First().UpdatedAt.Should().BeCloseTo(utcNow, TimeSpan.FromSeconds(1));

        await _repositoryMock.Received(1).GetAllAsync();
        await _serviceMock.DidNotReceive().GetCurrencyAsync();
        await _unitOfWorkMock.DidNotReceive().SaveChangesAsync();
    }

    [Fact]
    public async Task Handle_ShouldFetchAndSaveExchanges_WhenRepositoryIsEmpty()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;
        var query = new GetLatestExchangeQuery();
        var exchangesFromService = new List<Exchange>
        {
            new()
            {
                NationalCurrencyCode = "USD",
                TargetCurrencyCode = "UAH",
                Buy = 41.2f,
                Sale = 39f,
            },
            new()
            {
                NationalCurrencyCode = "EUR",
                TargetCurrencyCode = "UAH",
                Buy = 43f,
                Sale = 41.2f,
            }
        };

        _repositoryMock.GetAllAsync().Returns([]);
        _serviceMock.GetCurrencyAsync().Returns(Result.Success<IEnumerable<Exchange>>(exchangesFromService));

        var responses = exchangesFromService.ToResponses();

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(responses, o => o
            .Excluding(r => r.UpdatedAt));

        result.Value.ToArray()[0].UpdatedAt.Should().BeCloseTo(utcNow, TimeSpan.FromSeconds(1));
        result.Value.ToArray()[1].UpdatedAt.Should().BeCloseTo(utcNow, TimeSpan.FromSeconds(1));

        _repositoryMock.Received(1).AddRange(Arg.Is<IEnumerable<Exchange>>(x => x.SequenceEqual(exchangesFromService)));

        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenServiceExecutionFails()
    {
        // Arrange
        var query = new GetLatestExchangeQuery();

        _repositoryMock.GetAllAsync().Returns([]);
        _serviceMock.GetCurrencyAsync().Returns(Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.HttpExecution));

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(e => e == DomainErrors.Exchange.HttpExecution);

        _repositoryMock.DidNotReceive().AddRange(Arg.Any<IEnumerable<Exchange>>());

        await _serviceMock.Received(1).GetCurrencyAsync();
        await _unitOfWorkMock.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenServiceSerializationFails()
    {
        // Arrange
        var query = new GetLatestExchangeQuery();

        _repositoryMock.GetAllAsync().Returns([]);
        _serviceMock.GetCurrencyAsync().Returns(Result.Failure<IEnumerable<Exchange>>(DomainErrors.Exchange.Serialization));

        // Act
        var result = await _handler.Handle(query, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(e => e == DomainErrors.Exchange.Serialization);

        _repositoryMock.DidNotReceive().AddRange(Arg.Any<IEnumerable<Exchange>>());

        await _serviceMock.Received(1).GetCurrencyAsync();
        await _unitOfWorkMock.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
