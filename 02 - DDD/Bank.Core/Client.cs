using CSharpFunctionalExtensions;

using System;
using System.Text.RegularExpressions;
using FluentValidation.Validators;

namespace Bank.Core
{
    public class Client : Entity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public Phone Phone { get; set; }

        public Client(string name, string surName, string email, Phone phone)
        {
            Validate(name, surName, email);

            Name = name;
            SurName = surName;
            Email = email;
            Phone = phone;
        }

        private void Validate(string name, string surName, string email)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.Match(email).Success)
                throw new ArgumentException("The Email is invalid", nameof(email));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name can't be empty", nameof(email));

            if (string.IsNullOrEmpty(surName))
                throw new ArgumentException("SurName can't be empty", nameof(surName));



        }
    }
}
