
using CSharpFunctionalExtensions;

using System;
using System.Collections.Generic;
using System.Linq;
using Bank.Core.Validators;
using FluentValidation;

namespace Bank.Core
{
    public class Account : Entity
    {
        public Client Owner { get; }
        public List<Client> Others { get; private set; } = new();

        public Account(Client owner)
        {
            Owner = owner;
        }

        public void AddOther(Client other)
        {
            if (other.Name.Trim().Length > 100)
                throw new ArgumentException("The length of the name should be less than 100", nameof(other));

            if (Others.Any(x => x.Id == other.Id))
                throw new ArgumentException("You already are a other", nameof(other));

            Others.Add(other);
        }
    }
    public class AccountAddOthersOtherValidationValidator : AbstractValidator<Account>
    {
        public AccountAddOthersOtherValidationValidator(Client other)
        {
            RuleFor(client => client.Others)
                .Must(c => c.Any(x => x.Id == other.Id))
                .NotNullEmpty("You already are a other");
        }
    }

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
