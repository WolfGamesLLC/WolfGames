using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WGSystem.ComponentModel.DataAnnotations;

namespace WGSystemXUnitTest.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Test suite for the WGBasicValidation implementation of the model validation client interface
    /// </summary>
    public class WGBasicValidationXUnitTestSuite
    {
        /// <summary>
        /// Test that a WGBasicValidation object created with an object that does not 
        /// implement IWGValidation throws an InvalidTypeException
        /// </summary>
        [Fact]
        public void ShouldThrowInvalidTypeException()
        {
            Assert.Throws<ArgumentException>(() => new WGBasicValidation(null));
        }

        /// <summary>
        /// Test that a WGBasicValidation object can be created
        /// </summary>
        [Fact]
        public void ShouldCreateWGBasicValidation()
        {
            Assert.NotNull(new WGBasicValidation(new WGAspNetCore2Validation()));
        }
    }
}
