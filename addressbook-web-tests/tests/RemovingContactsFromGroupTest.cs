using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    public class RemovingContactsFromGroupTest : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            app.GroupHelper.IsAnyGroup();
            app.ContactHelper.IsAnyContact();

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.ContactHelper.AddContactToGroup(contact, group);

            app.ContactHelper.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
