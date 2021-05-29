using System.Collections.Generic;
using Bank.Core;
using Xunit;

namespace Bank.UnitTests
{
    public class BankShould
    {
        [Fact]
        public void Throw_Exceptions()
        {

            new Core.Bank(new List<Account>())
                .CreateAccount(new Client("Client 1", "Client 1 Ext", "Email@email.com",  Phone.Create("145984345345435752")));
        }
    }
}
