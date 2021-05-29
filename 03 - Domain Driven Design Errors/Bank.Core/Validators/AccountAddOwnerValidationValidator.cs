using FluentValidation;

namespace Bank.Core.Validators
{
    public class AccountAddOwnerValidationValidator : AbstractValidator<Client>
    {
        public AccountAddOwnerValidationValidator()
        {
            RuleFor(client => client.Name)
                .Must(c => c.Trim().Length > 100)
                .NotNullEmpty("The length of the name should be less than 100");
        }
    }
}