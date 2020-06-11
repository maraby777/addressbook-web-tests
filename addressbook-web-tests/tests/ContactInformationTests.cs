using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.ContactHelper.GetContactInformationFromTable(0);
            ContactData fromForm = app.ContactHelper.GetContactInformationFromEditForm(0);
            //verification

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address.Trim());
            Assert.AreEqual(fromTable.HomeWorkMobileHome2Phone, 
                fromForm.HomeWorkMobileHome2Phone);
            Assert.AreEqual(fromTable.AllEmails, fromTable.AllEmails);

        }

        [Test]
        public void TestDetailContactInformation()
        {
            ContactData fromForm = app.ContactHelper.GetContactInformationFromEditForm(0);
            string fromDetails = app.ContactHelper.GetContactInformationFromDetails(0);

            string allDetailFromForm = fromForm.FullName + fromForm.AllDetails;

            Assert.AreEqual(allDetailFromForm, fromDetails);

        }
    }
}
