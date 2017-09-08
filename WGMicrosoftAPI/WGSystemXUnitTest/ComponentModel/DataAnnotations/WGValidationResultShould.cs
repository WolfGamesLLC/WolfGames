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
        /// The test object
        /// </summary>
        private IWGValidationResult Result;

        /// <summary>
        /// Construct the default test object
        /// </summary>
        public WGValidationResultShould()
        {
            Result = new WGValidationResult(ERROR_MESSAGE);
        }

        /// <summary>
        /// Test that the object is created when passed a string
        /// </summary>
        [Fact]
        public void CreateWithStringArgument()
        {
            Assert.NotNull(new WGValidationResult(ERROR_MESSAGE));
        }

        /// <summary>
        /// Test that the object is created with null
        /// </summary>
        [Fact]
        public void CreateWithNull()
        {
            Assert.NotNull(new WGValidationResult(null));
        }

        /// <summary>
        /// Test that the object error message is null when created with null
        /// </summary>
        [Fact]
        public void CreateSetErrorMessageNull()
        {
            Assert.Null(new WGValidationResult(null).ErrorMessage);
        }

        /// <summary>
        /// Test the ErrorMessage get property
        /// </summary>
        [Fact]
        public void ReturnErrorMessage()
        {
            Assert.Equal(ERROR_MESSAGE, Result.ErrorMessage);
        }

        /// <summary>
        /// Test the ErrorMessage set property
        /// </summary>
        [Fact]
        public void SetErrorMessage()
        {
            string errorMessage = "New Error Message";
            Result.ErrorMessage = errorMessage;
            Assert.Equal(errorMessage, Result.ErrorMessage);
        }
    }
}
