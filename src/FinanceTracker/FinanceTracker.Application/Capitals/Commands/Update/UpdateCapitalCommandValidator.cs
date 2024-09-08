using FinanceTracker.Application.Abstractions;
using FinanceTracker.Application.Capitals.Specifications;
using FinanceTracker.Domain.Constants;
using FinanceTracker.Domain.Errors;
using FinanceTracker.Domain.Repositories;
using FluentValidation;

namespace FinanceTracker.Application.Capitals.Commands.Update;

internal sealed class UpdateCapitalCommandValidator : AbstractValidator<UpdateCapitalCommand>
{
    public UpdateCapitalCommandValidator(ICapitalRepository repository)
    {
        RuleFor(c => c.Id)
            .MustAsync(async (id, _) => await repository.AnyAsync(new CapitalByIdSpecification(id)))
            .WithError(ValidationErrors.Capital.AlreadyExists);

        RuleFor(c => c.Balance)
            .GreaterThanOrEqualTo(ValidationConstants.ZeroValue);

        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(ValidationConstants.MaxLenghtName);
    }
}