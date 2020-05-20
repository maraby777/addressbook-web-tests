using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests :TestBase
    {

    [Test]
    public void GroupRemovalTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupPage();
            app.GroupHelper.SelectGroup(1);
            app.GroupHelper.RemoveGroup();
            app.Navigator.GoToGroupPage();
        }
    }
}
