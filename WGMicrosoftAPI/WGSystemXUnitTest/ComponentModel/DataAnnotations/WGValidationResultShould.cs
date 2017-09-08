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
        /// <summary>
        /// Generic string for use with testing
        /// </summary>
        private readonly string ERROR_MESSAGE = "Error Message";

        /// <summary>
        /// Test that the object is created when passed a string
        /// </summary>
        [Fact]
        public void CreateWithStringArgument()
        {
            Assert.NotNull(new WGValidationResult(ERROR_MESSAGE));
        }

        /// <summary>
        /// Test that ArgumentNullException is thrown when the object is created with null
        /// </summary>
        [Fact]
        public void ThrowArgumentNullExceptionWhenCreatedWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => new WGValidationResult(null));
        }
    }
}
