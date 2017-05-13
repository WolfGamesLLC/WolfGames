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

        [TestMethod]
        public void Index()
        {
            // Arrange
            Controller = new HomeController();

            // Act
            ViewResult result = Controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            Controller = new HomeController();

            // Act
            ViewResult result = Controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("About Wolf Games.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            Controller = new HomeController();

            // Act
            ViewResult result = Controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
