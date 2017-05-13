using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfGamesSite.API;
using WolfGamesSite.API.Controllers;

namespace WolfGamesSite.API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerAPITest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
