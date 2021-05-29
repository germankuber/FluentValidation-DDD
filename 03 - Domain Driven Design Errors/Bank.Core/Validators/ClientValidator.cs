using FluentValidation;

namespace Bank.Core.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
   
        public ClientValidator()
        {
            RuleFor(client => client.Name)
                .NotNullEmpty("Name can't be empty");

            RuleFor(client => client.SurName)
                .NotNullEmpty("SurName can't be empty");

            RuleFor(client => client.Email)
                .NotNullEmpty("Name can't be empty")
                .EmailAddress();

            When(x => x.Email == null, () =>
            {
                RuleFor(x => x.Phone)
                    .NotNull()
                    .SetValidator(new PhoneValidator());
            });
            When(x => x.Phone == null, () =>
            {
                RuleFor(x => x.Email).NotNull();
            });

        }
    }
}