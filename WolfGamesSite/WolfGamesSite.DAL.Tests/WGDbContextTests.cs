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
    public class WGDbContextTests
    {
        [TestMethod()]
        public void WGDbContextTest()
        {
            WGDbContext c = new WGDbContext();
            Assert.AreEqual(WGDbContext.DefaultConnection, WGDbContext.DefaultConnection);
        }
    }
}