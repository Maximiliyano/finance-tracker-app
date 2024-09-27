using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FinanceTracker.Domain.Results;

namespace FinanceTracker.Application.Capitals.Commands.Update;

internal sealed class UpdateCapitalCommandHandler(ICapitalRepository repository, IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateCapitalCommand>
{
    public async Task<Result> Handle(UpdateCapitalCommand request, CancellationToken cancellationToken)
    {
        var capital = await repository.GetAsync(new CapitalByIdSpecification(request.Id));

        if (capital is null)
        {
            return Result.Failure(DomainErrors.General.NotFound);
        }
        
        capital.Name = request.Name != null && request.Name != capital.Name ? request.Name : capital.Name;
        if (request.Balance.HasValue && 
            Math.Abs(request.Balance.Value - capital.Balance) > 0.000)
        {
            capital.Balance = request.Balance.Value;
        }
        capital.Currency = request.Currency != null && request.Currency != capital.Currency ? request.Currency : capital.Currency;

        repository.Update(capital);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
