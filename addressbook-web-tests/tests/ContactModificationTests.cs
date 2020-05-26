using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{   
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactData newData = new ContactData("first_name_modify");
            newData.FirstName = "firstname_modify";
            newData.Middlename = "middlename_modify";
            newData.Lastname = "lastname_modify";
            newData.Home = "home_modify";
            newData.Mobile = "111222333_modify";
            newData.Email = "test@test.com_modify";
            newData.Nickname = "nickname_modify";

            app.ContactHelper.Modify(2, newData);
        }
    }
}
