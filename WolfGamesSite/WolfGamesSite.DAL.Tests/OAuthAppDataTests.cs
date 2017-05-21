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

        [TestMethod()]
        public void ShouldNotEqualNullObject()
        {
            string id = "id";
            string secret = "secret";

            OAuthAppData l = new OAuthAppData(id, secret);
            Assert.IsFalse(l.Equals(null));
        }

        [TestMethod()]
        public void EqualsTrueTest()
        {
            string id = "id";
            string secret = "secret";

            OAuthAppData l = new OAuthAppData(id, secret);
            OAuthAppData r = new OAuthAppData(id, secret);
            Assert.AreEqual(l, r);
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            string id = "id";
            string secret = "secret";
            int hash = id.GetHashCode() + secret.GetHashCode();

            OAuthAppData o = new OAuthAppData(id, secret);

            Assert.AreEqual(hash, o.GetHashCode());
        }
    }
}