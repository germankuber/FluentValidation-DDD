using System.Collections.Generic;
using System.Linq;
using Bank.Core.Validators;
using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace Bank.Core
{
    public class Phone : ValueObject
    {
        private Phone(string phone)
        {
            Value = phone;
        }

        public string Value { get; }

        //TODO 01 - Create Factory
        public static Result<Phone> Create(string phone)
        {
            var newPhone = new Phone(phone);
            var result = ValidatePhone(newPhone);
            if (!result.IsValid)
                string.Join(',', result.Errors.Select(x => x.ErrorMessage));

            return newPhone;
        }

        private static ValidationResult ValidatePhone(Phone phone)
        {
            return new PhoneValidator().Validate(phone);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}