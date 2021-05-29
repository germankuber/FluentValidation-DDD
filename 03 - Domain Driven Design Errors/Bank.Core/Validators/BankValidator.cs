using FluentValidation;

namespace Bank.Core.Validators
{
    public class BankValidator : AbstractValidator<Bank>
    {
        public BankValidator()
        {
            RuleFor(x => x.Accounts)
                .NotNull()
                .NotEmpty()
                .SetValidator(new ListAccountsValidator());
        }
    }
}