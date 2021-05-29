using Bank.Core;
using Xunit;

namespace Bank.UnitTests
{
    public class PhoneShould
    {
        [Fact]
        public void Throw_Exceptions()
        {
            var phone = Phone.Create("");
        }
    }
}