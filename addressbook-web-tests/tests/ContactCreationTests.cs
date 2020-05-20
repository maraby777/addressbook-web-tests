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
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.ContactHelper.AddNewContact();

            ContactData contact = new ContactData("first_name");
            contact.FirstName = "firstname";
            contact.Middlename = "middlename";
            contact.Lastname = "lastname";
            contact.Home = "home";
            contact.Mobile = "111222333";
            contact.Email = "test@test.com";
            contact.Nickname = "nickname";

            app.ContactHelper.FillContactForm(contact);
            app.ContactHelper.SubmitNewContact();
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        } 
    }
}
