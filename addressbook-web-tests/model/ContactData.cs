using System;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhone;

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

        public string Address { get; set; }

        public string Nickname { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }

        public string AllPhone 
        { 
            get 
            {
                if (allPhone != null)
                {
                    return allPhone;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim(); ;
                }
            } 
            set 
            {
                allPhone = value;
            } 
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "")
                .Replace("-", "")
                .Replace("(", "")
                .Replace(")", "") + "\r\n";
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
            return " Name = " + FirstName;
        }
    }
}
