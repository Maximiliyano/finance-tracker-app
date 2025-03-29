using FinanceTracker.Application.Capitals.Commands.Delete;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Enums;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Capitals.Commands;

public sealed class DeleteCapitalCommandHandlerTests
{
    private readonly ICapitalRepository _capitalRepositoryMock = Substitute.For<ICapitalRepository>();
    private readonly IUnitOfWork _unitOfWorkMock = Substitute.For<IUnitOfWork>();

    private readonly DeleteCapitalCommandHandler _handler;

    public DeleteCapitalCommandHandlerTests()
    {
        _handler = new DeleteCapitalCommandHandler(_capitalRepositoryMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_ShouldDeleteCapital_ReturnSuccess()
    {
        // Arrange
        var capital = new Capital(1)
        {
            Name = "Dollars",
            Balance = 100,
            Currency = CurrencyType.USD
        };
        var command = new DeleteCapitalCommand(1);

        _capitalRepositoryMock.GetAsync(Arg.Any<CapitalByIdSpecification>())
            .Returns(capital);

        // Act
        Result result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();

        _capitalRepositoryMock.Received(1).Delete(capital);

        await _unitOfWorkMock.Received(1).SaveChangesAsync(Arg.Any<CancellationToken>());
    }

    [Fact]
    public async Task Handle_ShouldDeleteNotFoundCapital_ReturnFailure()
    {
        // Arrange
        var command = new DeleteCapitalCommand(1);

        _capitalRepositoryMock.GetAsync(Arg.Any<CapitalByIdSpecification>())
            .Returns((Capital)null);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().OnlyContain(x => x == DomainErrors.General.NotFound("capital"));

        _capitalRepositoryMock.Received(0).Delete(Arg.Any<Capital>());

        await _unitOfWorkMock.Received(0).SaveChangesAsync(Arg.Any<CancellationToken>());
    }
};
