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
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void TheRemoveContactTest()
        {
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Remove(0);
            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);       
        }
    }
}
