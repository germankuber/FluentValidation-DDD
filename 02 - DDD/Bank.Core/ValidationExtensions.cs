using FluentValidation;

namespace Bank.Core
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> NotNullEmpty<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, string message)
        {
            return ruleBuilder
                .NotNull()
                .NotEmpty()
                .WithMessage(_ => message);
        }
    }
}