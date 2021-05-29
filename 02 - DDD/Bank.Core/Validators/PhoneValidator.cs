using System.Text.RegularExpressions;
using FluentValidation;

namespace Bank.Core.Validators
{
    public class PhoneValidator : AbstractValidator<Phone>
    {
        //TODO 02 - Create a validator
        public PhoneValidator()
        {
            RuleFor(phone => phone).NotNull();
            RuleFor(phone => phone.Value)
                .NotNull()
                .NotEmpty()
                .MinimumLength(12)
                .Matches(p => new Regex(@"^[2-9][0-9]{9}$"));
        }

        //TODO 03 - Cascade Mode
        //public PhoneValidator()
        //{
        //    RuleFor(phone => phone).NotNull();
        //    RuleFor(phone => phone.Value)
        //        .Cascade(CascadeMode.Stop)
        //        .NotNull()
        //        .NotEmpty()
        //        .MinimumLength(12)
        //        .Matches(p => new Regex(@"^[2-9][0-9]{9}$"));
        //}
    }


  
}