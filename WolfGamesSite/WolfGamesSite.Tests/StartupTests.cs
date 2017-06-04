using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfGamesSite;
using WolfGamesSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Builder;

namespace WolfGamesSite.Tests
{
    [TestClass()]
    public class StartupTests
    {
        private Startup startUp;

        [TestInitialize]
        public void Setup()
        {
            startUp = new Startup();
        }

        [TestMethod()]
        public void StartupTest()
        {
            OAuthAppData expectedOAuth = new OAuthAppData("130984234045601", "91d4430603418cb03bd86065fc4babeb");
            Assert.AreEqual(expectedOAuth, startUp.Authorization);
        }

        [TestMethod()]
        public void ConfigureAuthTest()
        {
            AppBuilder builder = new AppBuilder();
            startUp.ConfigureAuth(builder);

            Assert.AreEqual(3, builder.Properties.Count);
        }
    }
}