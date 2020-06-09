using System;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhone;
        private string allEmails;
        private string allDetails;
        private string bDate;
        private string aDate;

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

        public string FirstName { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }
        
        public string NickName { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }


        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }

        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }


        public string Address2 { get; set; }

        public string HomePhone2 { get; set; }

        public string Notes { get; set; }

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
                    return (CleanUpData(FirstName + Middlename + Lastname
                        + NickName + Title + Company + Address
                        + HomeWorkMobileHome2Phone
                        + AllEmails
                        + BDate
                        + ADate
                        + Address2 + Notes))
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
                    return (CleanUpDate(BDay) 
                        + CleanUpDate(BMonth) 
                        + CleanUpDate(BYear))
                        .Trim();
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
                if (aDate != null)
                {
                    return bDate;
                }
                else
                {
                    return (CleanUpDate(ADay) 
                        + CleanUpDate(AMonth) 
                        + CleanUpDate(AYear))
                        .Trim();
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

        private string CleanUpData(string data)
        {
            if (data == null || data == "")
            {
                return "";
            }
            return Regex.Replace(data, "[0-]|[\\s]|(\\r\\n)|(\\.)|(Homepage:)|(Birthday )|(Anniversary )", "");
        }

        private string CleanUpDate(string date)
        {
            if (date == null || date == "")
            {
                return "";
            }
            return Regex.Replace(date, "[0-]|[\\s]|(\\.)|(\\r\\n)", "");
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
                return Regex.Replace(email, "(\\r\\n)", "");
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
    }
}
