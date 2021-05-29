using System.Collections.Generic;
using Bank.Core.Validators;
using CSharpFunctionalExtensions;

using FluentValidation;

namespace Bank.Core
{
    public class Phone : ValueObject
    {
        //TODO 01 - Implement Value Object
        public string Value { get; }

        public Phone(string phone)
        {
            Value = phone;
            ValidatePhone();
        }

        private void ValidatePhone()
            => new PhoneValidator().Validate(this,
                                             options => options.ThrowOnFailures());

        //private void ValidatePhone(string phone)
        //{
        //    Regex regexPhone = new Regex(@"^[2-9][0-9]{9}$");

        //    if (string.IsNullOrEmpty(phone)
        //        ||
        //        phone.Length < 12
        //        ||
        //        regexPhone.Match(phone).Success)
        //        throw new ArgumentException("Phone can't be empty", nameof(phone));
        //}
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}