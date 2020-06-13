using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void TheRemoveContactTest()
        {
            app.ContactHelper.ContactPrepare();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemovalContact = oldContacts[0];

            app.ContactHelper.Remove(toBeRemovalContact);
           
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);       
        }
    }
}
