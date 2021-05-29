
using CSharpFunctionalExtensions;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank.Core
{
    public class Bank : Entity
    {
        public List<Account> Accounts { get; private set; } = new();
        public void CreateAccount(Client owner)
        {
            if (Accounts.Count(x => x.Owner.Id == owner.Id) > 2)
                throw new ArgumentException("The same client cannot have more than 2 accounts", nameof(owner));

            Accounts.Add(new Account(owner));
        }

    }
}
