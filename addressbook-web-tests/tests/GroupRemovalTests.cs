using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

    [Test]
    public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];

            app.GroupHelper.Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.GroupHelper.GetGroupCount());

            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
 
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
