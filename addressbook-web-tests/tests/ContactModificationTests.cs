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
            newData.HomePhone = "home_modify";
            newData.MobilePhone = "111222333_modify";
            newData.Email = "test@test.com_modify";
            newData.NickName = "nickname_modify";

            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Modify(0, newData);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
        }
    }
}
