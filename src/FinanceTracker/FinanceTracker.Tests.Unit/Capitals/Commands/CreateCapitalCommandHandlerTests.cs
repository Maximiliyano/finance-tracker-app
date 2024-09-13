using FinanceTracker.Application.Capitals.Commands.Create;
using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using FluentAssertions;
using NSubstitute;

namespace FinanceTracker.UnitTests.Capitals.Commands;

public sealed class CreateCapitalCommandHandlerTests
{
    private readonly ICapitalRepository _repositoryMock = Substitute.For<ICapitalRepository>();
    private readonly IUnitOfWork _unitOfWorkMock = Substitute.For<IUnitOfWork>();
    
    private readonly CreateCapitalCommandHandler _handler;
    
    public CreateCapitalCommandHandlerTests()
    {
        _handler = new CreateCapitalCommandHandler(_repositoryMock, _unitOfWorkMock);
    }

    [Fact]
    public async Task Handle_CreateValidCapital_ReturnsId()
    {
        // Arrange
        var command = new CreateCapitalCommand("FancyName", 1000);
        var capital = new Capital
        {
            Name = command.Name,
            Balance = command.Balance
        };
        
        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(capital.Id);

        _repositoryMock.Received().Create(Arg.Is<Capital>(c => c.Id == capital.Id));
        
        await _unitOfWorkMock.Received().SaveChangesAsync();
    }
}
