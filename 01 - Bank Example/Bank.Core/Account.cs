
using CSharpFunctionalExtensions;

using System;
using System.Collections.Generic;
using System.Linq;

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
}
