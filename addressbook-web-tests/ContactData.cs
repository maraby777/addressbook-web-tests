using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class ContactData
    {

        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string home;
        private string mobile;
        private string email;

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get 
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }

        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }

        public string Home
        {
            get
            {
                return home;
            }
            set
            {
                home = value;
            }
        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
    }
}
