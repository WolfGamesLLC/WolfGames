using System;
using System.Collections.Generic;
using System.Text;
using WolfGamesSite.Models;
using Xunit;

namespace WolfGamesSite.DAL.XUnitTest.Models
{
    public class ErrorViewModelTestSuite
    {
        [Fact]
        public void ShouldCreateAnErrorViewModel()
        {
            Assert.NotNull(new ErrorViewModel());
        }

        [Fact]
        public void ShouldSetRequestId()
        {
            string expected = "RequestId";
            ErrorViewModel view = new ErrorViewModel();
            view.RequestId = expected;
            Assert.Equal(expected, view.RequestId );
        }
    }
}
