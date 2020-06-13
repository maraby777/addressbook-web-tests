using addressbook_web_tests.model;
using LinqToDB.Mapping;
using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhone;
        private string allEmails;
        private string allDetails;
        private string bDate;
        private string aDate;
        private string aDay;
        private string bDay;
        private string aMonth;
        private string bMonth;
        private string fullName;

        public ContactData()
        {
        }

        public ContactData(string firstname)
        {
            FirstName = firstname;
        }

        public ContactData(string firstname, string lastname)
        {
            FirstName = firstname;
            Lastname = lastname;
        }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string BDay
        {
            get
            {
                if (bDay == null || bDay == "0")
                {
                    return "";
                }
                else
                {
                    return bDay;
                }
            }
            set
            {
                bDay = value;
            }
        }

        [Column(Name = "bmonth")]
        public string BMonth
        {
            get
            {
                if (bMonth == null || bMonth == "-")
                {
                    return "";
                }
                else
                {
                    return bMonth;
                }
            }
            set
            {
                bMonth = value;
            }
        }

        [Column(Name = "byear")]
        public string BYear { get; set; }

        [Column(Name = "aday")]
        public string ADay
        {
            get
            {
                if (aDay == null || aDay == "0")
                {
                    return "";
                }
                else 
                {
                    return aDay;
                }
            }
            set
            {
                aDay = value;
            }
        }

        [Column(Name = "amonth")]
        public string AMonth
        {
            get
            {
                if (aMonth == null || aMonth == "-")
                {
                    return "";
                }
                else
                {
                    return aMonth;
                }
            }
            set
            {
                aMonth = value;
            }
        }

        [Column(Name = "ayear")]
        public string AYear { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "phone2")]
        public string HomePhone2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                {

                    return AddCaret((CleanUpFullName(FirstName)
                        + CleanUpFullName(Middlename)
                        + CleanUpFullName(Lastname))
                        .Trim());
                }
            }
            set
            {
                fullName = value;
            }
        }

        public string AllDetails
        {
            get 
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return (AddCaret((FullName)
                        + AddCaret(NickName)
                        + AddCaret(Title) 
                        + AddCaret(Company) 
                        + AddCaret(AddCaret(Address)))

                        + AddCaret(SetHomePhoneLikeOnDetailsPage(HomePhone)
                            + SetMobilePhoneLikeOnDetailsPage(MobilePhone)
                            + SetWorkPhoneLikeOnDetailsPage(WorkPhone)
                            + SetFaxPhoneLikeOnDetailsPage(Fax))
                        
                        + AddCaret(Email) + AddCaret(Email2)  + AddCaret(Email3)
                        + AddCaret(SetHomepageLikeOnDetailsPage(Homepage))

                        + AddCaret(SetBirthdayLikeOnDetailsPage(BDay, BMonth, BYear)
                                + SetAnniversaryLikeOnDetailsPage(ADay, AMonth, AYear))

                        + AddCaret(AddCaret(Address2))
                        + AddCaret(SetHomePhone2LikeOnDetailsPage(HomePhone2))
                        + AddCaret(Notes)
                        )
                        .Trim();
                }
            }
            set
            {
                allDetails = value;
            }
        }

        public string BDate
        {
            get
            {
                if (bDate != null)
                {
                    return bDate;
                }
                else
                {
                    return (BDay + BMonth + BYear).Trim();
                }
            }
            set 
            {
                bDate = value;
            }
        }

        public string ADate
        {
            get
            {
                if (aDate != null )
                {
                    return aDate;
                }
                else
                {

                   return (ADay + AMonth + AYear).Trim();
                }
            }
            set
            {
                aDate = value;
            }
        }

        public string HomeWorkMobileHome2Phone 
        { 
            get 
            {
                if (allPhone != null)
                {
                    return allPhone;
                }
                else
                {
                    return (CleanUp(HomePhone) 
                        + CleanUp(MobilePhone) 
                        + CleanUp(WorkPhone)
                        + CleanUp(HomePhone2))
                        .Trim();
                }
            } 
            set 
            {
                allPhone = value;
            } 
        }

        public string AllEmails
        {
            get 
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmail(Email) 
                        + CleanUpEmail(Email2) 
                        + CleanUpEmail(Email3))
                        .Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        private string SetHomePhoneLikeOnDetailsPage(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "H: " + phone + "\r\n";
        }

        private string SetWorkPhoneLikeOnDetailsPage(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "W: " + phone + "\r\n";
        }

        private string SetMobilePhoneLikeOnDetailsPage(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "M: " + phone + "\r\n";
        }

        private string SetFaxPhoneLikeOnDetailsPage(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "F: " + phone + "\r\n";
        }

        private string SetHomePhone2LikeOnDetailsPage(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return "P: " + phone + "\r\n";
        }

        //DATE
        private string SetBirthdayLikeOnDetailsPage(string day, string month, string year)
        {
            if (day == "" && month == "" && year == "")
            {
                return "";
            }
            return "Birthday" + FormateDayForEditePage(day)  + month + " " + year +"\r\n";
        }

        private string SetAnniversaryLikeOnDetailsPage(string day, string month, string year)
        {
            if (day == "" && month == "" && year == "")
            {
                return "";
            }
            return "Anniversary" + FormateDayForEditePage(day) + month + " " + year + "\r\n";
        }

        private string FormateDayForEditePage(string day)
        {
            if (day == null || day == "" || day == "0") 
            {
                return ""; 
            }
            return day + ". ";
        }

        private string SetHomepageLikeOnDetailsPage(string page)
        {
            if (page == null || page == "")
            {
                return "";
            }
            return  "Homepage:" + "\r\n" + page + "\r\n";
        }

        private string CleanUpFullName(string name)
        {

            if (name == null || name == "")
            {
                return "";
            }
            return name + " ";
        }

        private string AddCaret(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return data + "\r\n";
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("-", "") + "\r\n";

        }

        private string CleanUpEmail(string email)
        {
            {
                if (email == null || email == "") 
                    {
                        {
                            return ""; 
                        }
                    }
                return email;
                //ToDo Check if email addresses are valid
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName 
                && Lastname == other.Lastname);
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compareResult = Lastname.CompareTo(other.Lastname);

            if (compareResult == 0)
            {
                return Lastname.CompareTo(other.Lastname);
            }

            return compareResult;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }

        public override string ToString()
        {
            return " FirstName = " + FirstName
                + "\n Lastname =" + Lastname
                + "\n Nickname = " + NickName
                + "\n Address = " + Address
                + "\n Email = " + Email
                + "\n Homepage = " + Homepage;
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {

                return (from c in db.Contacts
                        .Where(x => x.Deprecated == "0000-00-00 00:00:00") 
                        select c).ToList();
            }
        }
    }
}
