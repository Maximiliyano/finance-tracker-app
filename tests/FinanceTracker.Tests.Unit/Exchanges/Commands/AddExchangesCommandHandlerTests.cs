using FinanceTracker.Application.Exchanges;
using FinanceTracker.Application.Exchanges.Commands.AddRange;
using FinanceTracker.Application.Exchanges.Responses;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Exchanges.Commands;

public sealed class AddExchangesCommandHandlerTests
{
    private readonly IExchangeRepository _exchangeRepositoryMock = Substitute.For<IExchangeRepository>();
    private readonly IUnitOfWork _unitOfWorkMock = Substitute.For<IUnitOfWork>();

    private readonly AddExchangesCommandHandler _handler;

    public AddExchangesCommandHandlerTests()
    {
        _handler = new AddExchangesCommandHandler(_exchangeRepositoryMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_AddExchanges_ShouldReturnSuccess()
    {
        // Arrange
        var command = new AddExchangesCommand([
            new ExchangeResponse(CurrencyType.UAH.ToString(), CurrencyType.USD.ToString(), 40.0f, 41.0f, null)
        ]);

        var entities = command.Exchanges.ToEntities();

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

        _exchangeRepositoryMock.Received(1).AddRange(Arg.Is<IEnumerable<Exchange>>(ex =>
            ex.Count() == entities.Count() &&
            ex.All(e => entities.Any(expected => expected.Id == e.Id))));

        await _unitOfWorkMock.Received(1).SaveChangesAsync();
    }
}
