using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("name_modify");
            newData.Header = null;
            newData.Footer = "Footer_modify";

            app.GroupHelper.Modify(1, newData);
        }

    }
}
