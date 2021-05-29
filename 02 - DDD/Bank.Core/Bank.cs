
using CSharpFunctionalExtensions;

using System;
using System.Collections.Generic;
using System.Linq;
using Bank.Core.Validators;
using FluentValidation;

namespace Bank.Core
{
    public class Bank : Entity
    {
        public List<Account> Accounts { get; }

        public Bank(List<Account> accounts)
        {
            Accounts = accounts;
            new BankValidator().Validate(this,
                options => options.ThrowOnFailures());
        }
        public void CreateAccount(Client owner)
        {
            if (Accounts.Count(x => x.Owner.Id == owner.Id) > 2)
                throw new ArgumentException("The same client cannot have more than 2 accounts", nameof(owner));

            Accounts.Add(new Account(owner));
        }

    }
}
