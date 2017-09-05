using System;
using WolfGamesSite.DAL.Models;
using Xunit;

namespace WolfGamesSite.DAL.XUnitTest
{
    public class ApplicationUserModelTestSuite
    {
        [Fact]
        public void ShouldCreateAnApplicationUser()
        {
            Assert.NotNull(new ApplicationUser());
        }
    }
}
