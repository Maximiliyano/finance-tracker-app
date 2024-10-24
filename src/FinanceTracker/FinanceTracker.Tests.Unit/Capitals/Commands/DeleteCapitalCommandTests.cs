using FinanceTracker.Domain.Entities;
using FinanceTracker.Domain.Repositories;
using NSubstitute;

namespace FinanceTracker.UnitTests.Capitals.Commands;

public sealed class DeleteCapitalCommandTests
{
    private readonly ICapitalRepository _capitalRepository = Substitute.For<ICapitalRepository>();
    
    [Fact]
    public void Delete() 
    {
        // Arrange
        var capital = new Capital();
        
        _capitalRepository.Delete(capital);
        
        // Act
        // Assert
        _capitalRepository.Received().Delete(Arg.Any<Capital>());
    }
};
