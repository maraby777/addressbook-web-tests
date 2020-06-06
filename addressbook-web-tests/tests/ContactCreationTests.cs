using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactpDataProvider()
        {
            List<ContactData> contact = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new ContactData(GenerateRandomString(10))
                {
                    FirstName = GenerateRandomString(7),
                    Lastname = GenerateRandomString(7),
                    NickName = GenerateRandomString(5),
                    Address = GenerateRandomString(100),
                    Email = GenerateRandomString(70),
                    Homepage = GenerateRandomString(20)

                });
            }
            return contact;
        }

    [Test, TestCaseSource("RandomContactpDataProvider")]
    public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.ContactHelper.GetContactList();

            app.ContactHelper.Create(contact);

            List<ContactData> newContacts = app.ContactHelper.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }
    }
}

