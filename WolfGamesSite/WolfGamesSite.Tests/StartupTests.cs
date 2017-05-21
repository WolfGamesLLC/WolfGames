using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfGamesSite;
using WolfGamesSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfGamesSite.Tests
{
    [TestClass()]
    public class StartupTests
    {
        [TestMethod()]
        public void StartupTest()
        {
            OAuthAppData expectedOAuth = new OAuthAppData("130984234045601", "91d4430603418cb03bd86065fc4babeb");
            Startup startUp = new Startup();
            Assert.AreEqual(expectedOAuth, startUp.Authorization);
        }

        [TestMethod()]
        public void ConfigurationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ConfigureAuthTest()
        {
            Assert.Fail();
        }
    }
}