using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfGamesSite;
using WolfGamesSite.Controllers;

namespace WolfGamesSite.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController Controller;
        ViewResult Result;

        [TestInitialize]
        public void TestSetup()
        {
            Controller = new HomeController();
        }

        [TestMethod]
        public void Index()
        {
            // Arrange

            // Act
            Result = Controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(Result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange

            // Act
            Result = Controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("About Wolf Games.", Result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange

            // Act
            Result = Controller.Contact() as ViewResult;

            // Assert
            Assert.AreEqual("We love to hear from you.", Result.ViewBag.Message);
        }
    }
}
