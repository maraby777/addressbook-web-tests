using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class AccountData
    {
        private string username;
        private string password;

        //konstruktor
        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public string Username
        {
            get
            { 
                return username;
            }
            set 
            {
                username = value;
            }
        }

        public string Password
        {
            get 
            {
                return password;
            }
            set 
            {
                password = value;
            }
        }
    }
}
