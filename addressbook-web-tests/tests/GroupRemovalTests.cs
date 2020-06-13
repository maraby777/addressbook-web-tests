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
    public class GroupRemovalTests : GroupTestBase
    {

    [Test]
    public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];   //сохраняем группу с индексом 0 в переменную

            app.GroupHelper.Remove(toBeRemoved); // удаляю группу с индексом 0 (Id = 88)

            Assert.AreEqual(oldGroups.Count - 1, app.GroupHelper.GetGroupCount()); // сравниваю количество групп: (старый список-1) и новый

            List<GroupData> newGroups = GroupData.GetAll(); // новый список групп

            oldGroups.RemoveAt(0);  // удаляю в старом списке групп элемент с индексом 0

            Assert.AreEqual(oldGroups, newGroups); //сравниваю новый и (старый - один элемент) списки

            //foreach (GroupData group in newGroups)   
            //{
            //    Assert.AreEqual(group.Id, toBeRemoved.Id);  //сравниваю элемент с нулевым индексом в новом списке (Id = 89 ) и удаленный элемент (Id = 88)
            //}
        }
    }
}
