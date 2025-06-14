using Deed.Domain.Constants;
using Deed.Domain.Results;
using FluentValidation;

namespace Deed.Application.Abstractions;

public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> ruleBuilder, Error error)
    {
        if (error is null)
        {
            throw new ArgumentNullException(nameof(error), ValidationConstants.ErrorIsRequired);
        }

        return ruleBuilder
            .WithErrorCode(error.Code)
            .WithMessage(error.Message);
    }
}
