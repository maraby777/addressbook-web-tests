using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using addressbook_web_tests.tests;
using addressbook_web_tests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeData = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2]; //contact.xxx or group.xxx
            string format = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();
            StreamWriter writer = new StreamWriter(filename);

            if (typeData == "contact")
            {

                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData()
                    {
                        FirstName = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(10),
                        Middlename = TestBase.GenerateRandomString(10),
                        NickName = TestBase.GenerateRandomString(10),
                        Company = TestBase.GenerateRandomString(10),
                        Title = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),

                        HomePhone = TestBase.GenerateRandomInt(9),//GenerateRandomInt(9),
                        WorkPhone = TestBase.GenerateRandomInt(9),//GenerateRandomInt(9),
                        MobilePhone = TestBase.GenerateRandomInt(9),//GenerateRandomInt(9),

                        Fax = TestBase.GenerateRandomString(10),
                        Email = TestBase.GenerateRandomString(10),
                        Email2 = TestBase.GenerateRandomString(10),
                        Email3 = TestBase.GenerateRandomString(10),
                        Homepage = TestBase.GenerateRandomString(10),
                        Address2 = TestBase.GenerateRandomString(10),

                        HomePhone2 = TestBase.GenerateRandomInt(9),//GenerateRandomInt(9),

                        Notes = TestBase.GenerateRandomString(100)
                    });
                }

                if (format == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
                writer.Close();
            }
            else if (typeData == "group")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }

                if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, filename);
                }
                else
                {
                    if (format == "csv")
                    {
                        writeGroupsToCvsFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXmlFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJsonFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format " + format);
                    }
                    writer.Close();
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized data type " + typeData);
            }
        }


        //GROUP
        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeGroupsToCvsFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        //CONTACT
        //static void writeContactToExcelFile(List<ContactData> contacts, string filename)
        //{
        //    Excel.Application app = new Excel.Application();
        //    app.Visible = true;
        //    Excel.Workbook wb = app.Workbooks.Add();
        //    Excel.Worksheet sheet = wb.ActiveSheet;

        //    int row = 1;
        //    foreach (ContactData contact in contacts)
        //    {
        //        sheet.Cells[row, 1] = contact.FirstName;
        //        sheet.Cells[row, 2] = contact.Lastname;
        //        sheet.Cells[row, 3] = contact.Middlename;
        //        sheet.Cells[row, 4] = contact.NickName;
        //        sheet.Cells[row, 5] = contact.Company;
        //        sheet.Cells[row, 6] = contact.Title;
        //        sheet.Cells[row, 7] = contact.HomePhone;
        //        sheet.Cells[row, 8] = contact.WorkPhone;
        //        sheet.Cells[row, 9] = contact.MobilePhone;
        //        sheet.Cells[row, 10] = contact.Fax;
        //        sheet.Cells[row, 11] = contact.Email;
        //        sheet.Cells[row, 12] = contact.Email2;
        //        sheet.Cells[row, 13] = contact.Email3;
        //        sheet.Cells[row, 14] = contact.Homepage;
        //        sheet.Cells[row, 15] = contact.Address2;
        //        sheet.Cells[row, 15] = contact.HomePhone2;
        //        sheet.Cells[row, 16] = contact.Notes;
        //        row++;
        //    }
        //    string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
        //    File.Delete(fullPath);
        //    wb.SaveAs(fullPath);

        //    wb.Close();
        //    app.Visible = false;
        //    app.Quit();
        //}

        //static void writeContactsToCvsFile(List<ContactData> contacts, StreamWriter writer)
        //{
        //    foreach (ContactData contact in contacts)
        //    {
        //        writer.WriteLine(String.Format("${0},${1},${2}",
        //            contact.FirstName,
        //            contact.Lastname,
        //            contact.Middlename,
        //            contact.NickName,
        //            contact.Company,
        //            contact.Title,
        //            contact.Address,
        //            contact.HomePhone,
        //            contact.WorkPhone,
        //            contact.MobilePhone,
        //            contact.Fax,
        //            contact.Email,
        //            contact.Email2,
        //            contact.Email3,
        //            contact.Homepage,
        //            contact.Address2,
        //            contact.HomePhone2,
        //            contact.Notes));
        //    }
        //}

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}