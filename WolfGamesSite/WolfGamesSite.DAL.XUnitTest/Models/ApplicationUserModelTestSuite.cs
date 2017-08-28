using System;
using WolfGamesSite.Models;
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
