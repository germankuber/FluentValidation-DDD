using System.Linq;
using Bank.Core.Validators;
using CSharpFunctionalExtensions;
using FluentValidation.Results;

namespace Bank.Core
{
    public class Client : Entity
    {
        private Client(string name, string surName, string email, Phone phone)
        {
            Name = name;
            SurName = surName;
            Email = email;
            Phone = phone;
        }

        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }

        public Phone Phone { get; set; }

        //TODO 02 - Create Factory
        public static Result<Client> Create(string name, string surName, string email, Phone phone)
        {
            var newPhone = new Client(name, surName, email, phone);
            var result = ValidatePhone(newPhone);
            if (!result.IsValid)
                return Result.Failure<Client>(string.Join(',', result.Errors.Select(x => x.ErrorMessage)));

            return newPhone;
        }

        private static ValidationResult ValidatePhone(Client client)
        {
            return new ClientValidator().Validate(client);
        }


        //public static Result<Client> Create(string name, string surName, string email, Phone phone)
        //    => new ClientValidator().ValidateWithResult(new Client(name, surName, email, phone));
    }
}