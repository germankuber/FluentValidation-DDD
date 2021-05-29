using System.Text.RegularExpressions;
using FluentValidation;

namespace Bank.Core.Validators
{
    public class PhoneValidator : AbstractValidator<Phone>
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone).NotNull();
            RuleFor(phone => phone.Value)
                .NotNull()
                .NotEmpty()
                .MinimumLength(12)
                .Matches(p => new Regex(@"^[2-9][0-9]{9}$"));
        }
    }
}