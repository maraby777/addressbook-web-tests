using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Xml.Serialization;
using Newtonsoft.Json;

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
                contact.Add(new ContactData()
                {
                    FirstName = GenerateRandomString(10),
                    Lastname = GenerateRandomString(7),
                    NickName = GenerateRandomString(5),
                    Company = GenerateRandomString(7),
                    Title = GenerateRandomString(7),
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(9),//GenerateRandomInt(8),
                    WorkPhone = GenerateRandomString(9),//GenerateRandomInt(8),
                    MobilePhone = GenerateRandomString(9),//GenerateRandomInt(8),
                    Fax = GenerateRandomString(9),
                    Email = GenerateRandomString(10),
                    Email2 = GenerateRandomString(13),
                    Email3 = GenerateRandomString(13),
                    Homepage = GenerateRandomString(20),
                    Address2 = GenerateRandomString(100),
                    HomePhone2 = GenerateRandomString(9),//GenerateRandomInt(8),
                    Notes = GenerateRandomString(100)
                });
            }
            return contact;
        }

        //public static IEnumerable<ContactData> ContactDataFromCsvFile()
        //{
        //    List<ContactData> contacts = new List<ContactData>();
        //    string[] lines = File.ReadAllLines(@"contact.csv");
        //    foreach (string l in lines)
        //    {
        //        string[] parts = l.Split(',');
        //        contacts.Add(new ContactData()
        //        {
        //            FirstName = parts[0],
        //            Lastname = parts[1],
        //            Middlename = parts[2],
        //            NickName = parts[3],
        //            Company = parts[4],
        //            Title = parts[5],
        //            Address = parts[6],
        //            HomePhone= parts[7],
        //            WorkPhone = parts[8],
        //            MobilePhone = parts[9],
        //            Fax = parts[10],
        //            Email = parts[11],
        //            Email2 = parts[12],
        //            Email3 = parts[13],
        //            Homepage = parts[14],
        //            Address2 = parts[15],
        //            HomePhone2 = parts[16],
        //            Notes = parts[17]
        //        });
        //    }
        //    return contacts;
        //}

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(File.ReadAllText(@"contact.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contact.xml"));
        }

        //public static IEnumerable<ContactData> ContactDataFromExcelFile()
        //{

        //    List<ContactData> contacts = new List<ContactData>();
        //    Excel.Application app = new Excel.Application();
        //    Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contact.xlsx"));
        //    Excel.Worksheet sheet = wb.ActiveSheet;
        //    Excel.Range range = sheet.UsedRange;

        //    for (int i = 1; i <= range.Rows.Count; i++)
        //    {
        //        contacts.Add(new ContactData()
        //        {
        //            FirstName = range.Cells[i, 1].Value,
        //            Lastname = range.Cells[i, 2].Value,
        //            Middlename = range.Cells[i, 3].Value,
        //            Company = range.Cells[i, 4].Value,
        //            Title = range.Cells[i, 5].Value,
        //            Address = range.Cells[i, 6].Value,
        //            HomePhone = range.Cells[i, 7].Value,
        //            WorkPhone = range.Cells[i, 8].Value,
        //            MobilePhone = range.Cells[i, 9].Value,
        //            Fax = range.Cells[i, 10].Value,
        //            Email = range.Cells[i, 11].Value,
        //            Email2 = range.Cells[i, 12].Value,
        //            Email3 = range.Cells[i, 13].Value,
        //            Homepage = range.Cells[i, 14].Value,
        //            Address2 = range.Cells[i, 15].Value,
        //            HomePhone2 = range.Cells[i, 16].Value,
        //            Notes = range.Cells[i, 17].Value
        //        });
        //    }

        //    wb.Close();
        //    app.Visible = false;
        //    app.Quit();
        //    return contacts;
        //}

    [Test, TestCaseSource("ContactDataFromXmlFile")]
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

