using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        private bool acceptNextAlert = true;
            
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomeWorkMobileHome2Phone = allPhones,
                AllEmails = allEmails
            };
        }

        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            OpenContactsDetails(index);


            string contentDetails = driver.FindElement(By.CssSelector("div#content")).Text;



            return Regex.Replace(contentDetails, "[0-]|[-()]|[\\s]|(\\r\\n)|(\\.)|(M:)|(H:)|(W:)|(F:)|(P:)|(Anniversary)|(Homepage:)|(Birthday)", "");
        }

        public ContactHelper OpenContactsDetails(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");


            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string phone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");


             
            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                NickName = nickName,
                Company = company,
                Title = title,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homepage,
                BDay = bday,
                BMonth = bmonth,
                BYear = byear,
                ADay = aday,
                AMonth = amonth,
                AYear = ayear,
                Address2 = address2,
                HomePhone2 = phone2,
                Notes= notes
            };
        }

        public ContactHelper Create(ContactData contact)
        {
            AddNewContact();
            FillContactForm(contact);
            SubmitNewContact();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.GoToHomePage();

            ContactPrepare();
            InitContactModification(v);
            RemoveContact();
            return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.GoToHomePage();

            ContactPrepare();
            InitContactModification(v);
            //EditContact();
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public void ContactPrepare()
        {
            if (IsContactPresent() != true)
            {
                ContactData contact = new ContactData("IsContactPresent_first_name");
                contact.FirstName = "IsContactPresent_firstname";
                contact.Middlename = "IsContactPresent_middlename";
                contact.Lastname = "IsContactPresent_lastname";
                contact.HomePhone = "IsContactPresent_home";
                contact.MobilePhone = "IsContactPresent_111222333";
                contact.Email = "IsContactPresent_test@test.com";
                contact.NickName = "IsContactPresent_nickname";

                Create(contact);
            }
        }

        public ContactHelper RemoveContact()
        {
            acceptNextAlert = true;
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }


        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("email"), contact.Email);
            return this;
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        //private ContactHelper EditContact()
        //{
        //    driver.FindElement(By.XPath("//td[8]/a/img")).Click();
        //    //driver.FindElement(By.XPath("(//img[@alt='Edit'])[2]")).Click();
        //    return this;
        //}

        private bool IsContactPresent()
        {
            return IsElementPresent(By.Name("selected[]"));
        }
        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                manager.Navigator.GoToHomePage();

                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(cells[1].Text, cells[2].Text));
                }
            }
            return new List<ContactData>(contactCache);


        }

        public int GetNumberOfResults()
        {
            manager.Navigator.GoToHomePage();

            string text = driver.FindElement(By.TagName("lable")).Text;

            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
