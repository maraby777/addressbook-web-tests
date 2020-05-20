using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.GroupHelper.InitGroupCreation();

            GroupData group = new GroupData("name_");
            group.Header = "Header_";
            group.Footer = "Footer_";
            app.GroupHelper.FillGroupForm(group);
            //alternatiwa
            //FillGroupForm(new GroupData("name_", "aaa", "bbb"));//, "header_", "footer_") ;

            app.GroupHelper.SubmitGroupCreation();
            app.Navigator.GoToGroupPage();
            app.Auth.Logout();
        }
    }
}
