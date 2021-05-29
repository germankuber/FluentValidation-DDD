using System.Collections.Generic;
using FluentValidation;

namespace Bank.Core.Validators
{
    public class ListAccountsValidator : AbstractValidator<List<Account>>
    {
        public ListAccountsValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .ForEach(x =>
                {
                    x.NotNull();
                    x.SetValidator(new AccountValidator());
                });
        }
    }
}