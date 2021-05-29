using System.Linq;
using FluentValidation;

namespace Bank.Core.Validators
{
    public class AccountAddOthersOtherValidationValidator : AbstractValidator<Account>
    {
        public AccountAddOthersOtherValidationValidator(Client other)
        {
            RuleFor(client => client.Others)
                .Must(c => c.Any(x => x.Id == other.Id))
                .NotNullEmpty("You already are a other");
        }
    }
}