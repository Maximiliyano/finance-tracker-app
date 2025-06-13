using Deed.Application.Capitals.Specifications;
using Deed.Application.Abstractions;
using Deed.Domain.Constants;
using Deed.Domain.Enums;
using Deed.Domain.Errors;
using Deed.Domain.Repositories;
using FluentValidation;

namespace Deed.Application.Capitals.Commands.Update;

internal sealed class UpdateCapitalCommandValidator : AbstractValidator<UpdateCapitalCommand>
{
    public UpdateCapitalCommandValidator(ICapitalRepository repository)
    {
        RuleFor(c => c.Balance)
            .GreaterThanOrEqualTo(ValidationConstants.ZeroValue);

        RuleFor(c => c.Name)
            .MustAsync(async (name, _) => !await repository
                .AnyAsync(new CapitalByNameSpecification(name!)))
            .When(c => !string.IsNullOrEmpty(c.Name))
            .WithError(ValidationErrors.General.NameAlreadyExists)
            .MaximumLength(ValidationConstants.MaxLenghtName);

        RuleFor(c => c.Currency)
            .Must(currency => !int.TryParse(currency, out _) && Enum.TryParse<CurrencyType>(currency, out _))
            .When(c => !string.IsNullOrEmpty(c.Currency))
            .WithError(ValidationErrors.Capital.InvalidCurrencyType);
    }
}
