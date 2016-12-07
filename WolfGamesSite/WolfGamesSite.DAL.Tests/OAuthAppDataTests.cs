using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfGamesSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfGamesSite.DAL.Tests
{
    [TestClass()]
    public class OAuthAppDataTests
    {
        [TestMethod()]
        public void OAuthAppDataTest()
        {
            string id = "id";
            string secret = "secret";

            OAuthAppData o = new OAuthAppData(id, secret);
            Assert.AreEqual(id, o.Id);
            Assert.AreEqual(secret, o.Secret);
        }
    }
}