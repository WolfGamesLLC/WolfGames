using System;
using Xunit;
using WolfGamesSite;
using Moq;
using WolfGamesSite.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WolfGamesSite.XUnitTest
{
    public class HomeControllerShould
    {
        [Fact]
        public void IndexReturnsViewResult()
        {
            var result = new HomeController().Index();
            Assert.IsType<ViewResult>(result);
        }
    }
}
