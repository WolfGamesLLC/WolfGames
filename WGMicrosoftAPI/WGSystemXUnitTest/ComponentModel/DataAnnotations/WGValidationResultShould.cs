using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using WGSystem.ComponentModel.DataAnnotations;

namespace WGSystem.XUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the WGValidationResult proxy
    /// </summary>
    public class WGValidationResultShould
    {
        private readonly string ERROR_MESSAGE = "Error Message";

        [Fact]
        public void CreateWithNoArguments()
        {
            Assert.NotNull(new WGValidationResult(ERROR_MESSAGE));
        }
    }
}
