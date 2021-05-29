using System.Linq;
using CSharpFunctionalExtensions;
using FluentValidation;
using FluentValidation.Results;

namespace Bank.Core
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> NotNullEmpty<T, TProperty>(
            this IRuleBuilder<T, TProperty> ruleBuilder,
            string message)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage(_ => message);
        }

        //TODO 03 - DRY
        public static Result<T> ValidateWithResult<T>(this AbstractValidator<T> validator, T entity)
        {
            return ValidateResult(entity, validator.Validate(entity));
        }

        private static Result<T> ValidateResult<T>(T entity, ValidationResult result)
        {
            return !result.IsValid
                ? Result.Failure<T>(string.Join(',', result.Errors.Select(x => x.ErrorMessage)))
                : entity;
        }
    }
}