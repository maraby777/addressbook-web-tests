using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsLoggedIn());
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            app.Auth.Logout();

            AccountData account = new AccountData("admin", "1234512");
            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
