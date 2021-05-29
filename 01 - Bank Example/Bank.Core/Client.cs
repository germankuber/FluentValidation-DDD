using CSharpFunctionalExtensions;

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Bank.Core
{
    public class Client : Entity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Client(string name, string surName, string email, string phone)
        {
            Validate(name, surName, email, phone);

            Name = name;
            SurName = surName;
            Email = email;
            Phone = phone;
        }

        private void Validate(string name, string surName, string email, string phone)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.Match(email).Success)
                throw new ArgumentException("The Email is invalid", nameof(email));

            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name can't be empty", nameof(email));

            if (string.IsNullOrEmpty(surName))
                throw new ArgumentException("SurName can't be empty", nameof(surName));

            ValidateEmail(phone);
        }

        private void ValidateEmail(string phone)
        {
            Regex regexPhone = new Regex(@"^[2-9][0-9]{9}$");

            if (string.IsNullOrEmpty(phone)
               ||
               phone.Length < 12
               ||
               regexPhone.Match(phone).Success)
                throw new ArgumentException("Phone can't be empty", nameof(phone));
        }
    }
}
