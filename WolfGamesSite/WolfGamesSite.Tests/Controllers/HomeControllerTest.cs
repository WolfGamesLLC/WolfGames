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
        ViewResult viewResult;

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
            viewResult = Controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult);
        }

        [TestMethod]
        public void About()
        {
            // Arrange

            // Act
            viewResult = Controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("About Wolf Games.", viewResult.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange

            // Act
            viewResult = Controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(viewResult);
        }
    }
}
