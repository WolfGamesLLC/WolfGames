using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using WGSystem.ComponentModel.DataAnnotations;

namespace WGSystem.XUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the WGValidationResult adaptor
    /// </summary>
    public class WGValidationResultShould
    {
        [Fact]
        public void CreateWithNoArguments()
        {
            Assert.NotNull(new WGValidationResult());
        }
    }
}
