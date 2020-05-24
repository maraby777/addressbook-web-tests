using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
    [Test]
    public void ContactCreationTest()
        {
            ContactData contact = new ContactData("first_name");
            contact.FirstName = "firstname";
            contact.Middlename = "middlename";
            contact.Lastname = "lastname";
            contact.Home = "home";
            contact.Mobile = "111222333";
            contact.Email = "test@test.com";
            contact.Nickname = "nickname";

            app.ContactHelper.Create(contact);
        }


        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.FirstName = "";
            contact.Middlename = "";
            contact.Lastname = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Email = "";
            contact.Nickname = "nickname";

            app.ContactHelper.Create(contact);
        }
    }
}

