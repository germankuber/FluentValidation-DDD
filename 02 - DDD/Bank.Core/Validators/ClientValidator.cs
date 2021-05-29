using FluentValidation;

namespace Bank.Core.Validators
{
    public class ClientValidator : AbstractValidator<Client>
    {
        //TODO 04 - Create a validator CLient
        //public ClientValidator()
        //{
        //    RuleFor(client => client.Name)
        //        .NotNull()
        //        .NotEmpty()
        //        .WithMessage(c => "Name can't be empty");

        //    RuleFor(client => client.SurName)
        //        .NotNull()
        //        .NotEmpty()
        //        .WithMessage(c => "SurName can't be empty");
        //    RuleFor(client => client.Email)
        //        .NotNull()
        //        .NotEmpty()
        //        .Matches(p => new Regex(@"^[2-9][0-9]{9}$"))
        //        .WithMessage("The Email is invalid");
        //}

        //TODO 05 - Refactor
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


            //RuleFor(x => x.Phone)
            //    .NotNull()
            //    .SetValidator(new PhoneValidator())
            //    .When(x => x.Email != null);

            //RuleFor(x => x.Email)
            //    .NotNull()
            //    .When(x => x.Phone != null);
        }
    }
}