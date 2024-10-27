using FinanceTracker.Application.Capitals.Commands.Update;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Capitals.Commands;

public sealed class UpdateCapitalCommandHandlerTests
{
    private readonly ICapitalRepository _repositoryMock = Substitute.For<ICapitalRepository>();
    private readonly IUnitOfWork _unitOfWorkMock = Substitute.For<IUnitOfWork>();

    private readonly UpdateCapitalCommandHandler _handler;

    public UpdateCapitalCommandHandlerTests()
    {
        _handler = new UpdateCapitalCommandHandler(_repositoryMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenCapitalNotFound()
    {
        // Arrange
        var command = new UpdateCapitalCommand(1);

        _repositoryMock.GetAsync(Arg.Any<CapitalByIdSpecification>()).Returns((Capital)null);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(e => e == DomainErrors.General.NotFound("capital"));

        _repositoryMock.DidNotReceive().Update(Arg.Any<Capital>());

        await _repositoryMock.Received(1).GetAsync(Arg.Any<CapitalByIdSpecification>());
        await _unitOfWorkMock.DidNotReceive().SaveChangesAsync(Arg.Any<CancellationToken>());
    }

    [Theory]
    [InlineData("New Name", 200f, "EUR")]
    [InlineData("Modified Name", 150f, null)]
    [InlineData(null, 150f, null)]
    [InlineData(null, null, "UAH")]
    [InlineData("Updated Name", null, "USD")]
    [InlineData("Refreshed Name", null, null)]
    public async Task Handle_ShouldUpdateCapitalSuccessfully(string? name, float? balance, string? currency)
    {
        // Arrange
        var oldName = "Old Name";
        var oldBalance = 100f;
        var capital = new Capital(1) { Name = oldName, Balance = oldBalance, Currency = CurrencyType.USD };
        var command = new UpdateCapitalCommand(
            1,
            name,
            balance,
            currency);

        _repositoryMock.GetAsync(Arg.Any<CapitalByIdSpecification>()).Returns(capital);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

        capital.Name.Should().Be(name ?? oldName);
        capital.Balance.Should().Be(balance ?? oldBalance);
        capital.Currency.Should().Be(currency is not null
            ? Enum.Parse<CurrencyType>(currency)
            : CurrencyType.USD);

        _repositoryMock.Received(1).Update(capital);

        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
}
